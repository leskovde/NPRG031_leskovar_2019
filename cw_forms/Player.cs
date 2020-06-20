using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace CodeWars.Forms
{
    // vzorová třída pro případnou variabilitu robotů
    public class Player
    {
        private readonly Bitmap _bitmapBody, _bitmapGun, _bitmapRadar;

        // reprezentace ve Forms
        private readonly PictureBox _body, _gun, _radar, _healthBar, _healthRemaining;

        // atributy jako např. zdraví, rychlost, ...

        private readonly int _maxHealth;

        private readonly int _name;
        private readonly Point _spawnPoint; // souřadnice, na kterých se ve formuláři instance třídy objeví

        // fronta složitých instrukcí daného robota
        public Queue<Instruction> ComplexQueue;

        private int _currHealth,
            _maxSpeed,
            _xSpeed,
            _ySpeed,
            _bodyOrientation,
            _gunOrientation,
            _radarOrientation,
            //projDamage,
            _lastSpottedX,
            _lastSpottedY,
            _lastSpottedOrientation;

        // fronta jednoduchých instrukcí daného robota
        public Queue<Instruction> InstructionQueue;

        // konstruktor pro vytvoření a vykreslení instance do formuláře
        public Player(Control form, CwForm.EntireRobot robot, int health)
        {
            var r = new Random();

            _maxHealth = health;
            _currHealth = health;
            _maxSpeed = 3;

            // pro další vývoj je zde možnost nastavení zbylých atributů

            // dynamické vytvoření prvků formuláře a přiřazení ze vzoru
            var nameLabel = new Label();

            _body = PicBoxAssign(form, robot, "_body");
            _gun = PicBoxAssign(form, robot, "_gun");
            _radar = PicBoxAssign(form, robot, "_radar");
            _healthBar = PicBoxAssign(form, robot, "_healthBar");
            _healthRemaining = PicBoxAssign(form, robot, "_healthRemaining");

            // vytvoření náhodného bodu, na kterém se instance při začátku hry objeví
            while (true)
            {
                var finalPoint = true;
                _spawnPoint = new Point(
                    r.Next(CwForm.WorldInfo.LeftOfTheWorld, CwForm.WorldInfo.RightOfTheWorld - _body.Size.Width),
                    r.Next(CwForm.WorldInfo.TopOfTheWorld, CwForm.WorldInfo.BottomOfTheWorld - _body.Size.Height));
                foreach (var others in CwForm.PlayerList) // pokud jsou roboti příliš blízko, generujeme nový bod
                    if (Math.Abs(_spawnPoint.X - others._spawnPoint.X) < 250 &&
                        Math.Abs(_spawnPoint.Y - others._spawnPoint.Y) < 250)
                        finalPoint = false;

                if (!finalPoint) continue;
                // pokud je bod ve vzdálenosti alespoň 250 jednotek od všech ostatních robotů, nastavíme jeho pozici
                _body.Location = _spawnPoint;
                break;
            }

            // ukotvení jednotlivých prvků k sobě, aby se společně hýbaly, navíc řeší překrytí prvků
            // (které původně nemohou být vidět přes neprůhledné pozadí)
            _healthBar.Location = new Point(_body.Location.X - 20, _body.Location.Y - 20);
            _bitmapBody = (Bitmap) _body.Image;
            _bitmapGun = (Bitmap) _gun.Image;
            _bitmapRadar = (Bitmap) _radar.Image;

            _body.Controls.Add(_gun);
            _gun.Location = new Point(0, 0);
            _gun.BackColor = Color.Transparent;

            _gun.Controls.Add(_radar);
            _radar.Location = new Point(12, 12);
            _radar.BackColor = Color.Transparent;

            _healthBar.Controls.Add(_healthRemaining);
            _healthRemaining.Location = new Point(0, 0);

            _name = CwForm.PlayerList.Count + 1;
            _healthRemaining.Controls.Add(nameLabel);
            nameLabel.Location = new Point(0, 0);
            nameLabel.Text = "P" + _name;
            //nameLabel.ForeColor = Color.Black;
            nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);
            nameLabel.BackColor = Color.Transparent;

            InstructionQueue = new Queue<Instruction>();
            ComplexQueue = new Queue<Instruction>();
        }

        private static PictureBox PicBoxAssign(Control form, CwForm.EntireRobot robot, string componentName)
        {
            var component = new PictureBox
            {
                Size = robot.GetPictureBox(componentName).Size,
                Image = robot.GetPictureBox(componentName).Image,
                SizeMode = robot.GetPictureBox(componentName).SizeMode,
                BackColor = robot.GetPictureBox(componentName).BackColor
            };
            //component.Image = (Image)SetColor((Bitmap)component.Image, true); // obarvení náhodnou barvou
            form.Controls.Add(component);
            return component;
        }

        public static Bitmap SetColor(Bitmap bmp, bool newInstance) // obarvení libovolné bitmapy
        {
            var r = new Random(); // barvíme náhodně
            Image image = bmp;
            var imageAttributes = new ImageAttributes();

            // matice přebarvení - zajímá nás hlavní diagonála
            float[][] colorMatrixElements =
            {
                new[] {(float) (2 * r.NextDouble()), 0, 0, 0, 0}, // červená
                new[] {0, (float) (2 * r.NextDouble()), 0, 0, 0}, // zelená
                new[] {0, 0, (float) (2 * r.NextDouble()), 0, 0}, // modrá
                new[] {0, 0, 0, (float) (2 * r.NextDouble()), 0}, // alpha kanál
                new[] {.2f, .2f, .2f, 0, 1}
            };

            if (!newInstance) // pro případ, že funkci voláme eventem gameOver - barvíme černě
            {
                colorMatrixElements[0][0] = 0;
                colorMatrixElements[1][1] = 0;
                colorMatrixElements[2][2] = 0;
                colorMatrixElements[3][3] = 2;
            }

            var colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            var rect = new Rectangle(Point.Empty, image.Size);
            var drawingTool = Graphics.FromImage(image);

            // vykreslení obrazu s barvami škálovanými podle daných faktorů
            drawingTool.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
            drawingTool.Dispose();
            return (Bitmap) image;
        }

        public static Bitmap RotateImg(Bitmap bmp, float angle) // otočení libovolné bitmapy
        {
            // jelikož Forms nenabízí možnost rotovat podle daného úhlu, musíme aplikovat matici transformace
            var bitmapWidth = bmp.Width;
            var bitmapHeight = bmp.Height;
            var tempImg = new Bitmap(bitmapWidth, bitmapHeight);
            var drawingTool = Graphics.FromImage(tempImg);
            drawingTool.DrawImageUnscaled(bmp, 1, 1);
            drawingTool.Dispose();
            var path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, bitmapWidth, bitmapHeight));
            var mtrx = new Matrix();
            mtrx.Rotate(angle);
            var rct = path.GetBounds(mtrx);
            var newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height));

            drawingTool = Graphics.FromImage(newImg);
            drawingTool.TranslateTransform(-rct.X, -rct.Y);
            drawingTool.RotateTransform(angle);
            drawingTool.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawingTool.DrawImageUnscaled(tempImg, 0, 0);
            drawingTool.Dispose();
            tempImg.Dispose();
            return newImg;
        }

        public int GetAttrib(string attribName)
        {
            if (attribName != null)
                return (int) GetType().GetField(attribName, BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(this);
            return 0;
        }

        public PictureBox GetBody()
        {
            return _body;
        }

        // provedení samotných instrukcí pak probíhá pomocí následujících metod
        // řešení není obecné, v tomto konkrétním případě funguje, jelikož jen měníme atributy objektu
        public void MoveForward(int speed)
        {
            _xSpeed = (int) Math.Round(speed * Math.Cos(Program.DegreeToRad(_bodyOrientation)));
            _ySpeed = (int) Math.Round(speed * Math.Sin(Program.DegreeToRad(_bodyOrientation)));

            // ošetření vyjíždění z mapy, při překročení hranice získáme hodnotu hranice
            _body.Location = new Point(Math.Max(CwForm.WorldInfo.LeftOfTheWorld,
                    Math.Min(CwForm.WorldInfo.RightOfTheWorld, _body.Location.X + _xSpeed)),
                Math.Max(CwForm.WorldInfo.TopOfTheWorld,
                    Math.Min(CwForm.WorldInfo.BottomOfTheWorld, _body.Location.Y - _ySpeed)));

            _healthBar.Location = new Point(_body.Location.X - 20, _body.Location.Y - 20);
            UpdateRadar();
        }

        public void MoveBackwards(int speed)
        {
            MoveForward(-speed);
        }

        public void RotateVehicle(int degree)
        {
            _bodyOrientation += degree;
            _bodyOrientation %= 360;
            _body.Image = RotateImg(_bitmapBody, -_bodyOrientation);
            UpdateRadar();
        }

        public void DecreaseHealth(int value)
        {
            _currHealth -= value;
            _healthRemaining.Width = _currHealth;

            // při prohře vložíme na první místo fronty vhodnou událost
            if (_currHealth <= 0)
            {
                InstructionQueue.Clear();
                InstructionQueue.Enqueue(new GameOver(0, this));
            }

            UpdateRadar();
        }

        public void ResetGunOrientation()
        {
            _gunOrientation = 0;
        }

        public void RotateGun(int degree)
        {
            _gunOrientation += degree;
            _gunOrientation %= 360;
            _gun.Image = RotateImg(_bitmapGun, -_gunOrientation);
            UpdateRadar();
        }

        public void Fire(int energy)
        {
            var x = _body.Location.X + _body.Size.Width / 2;
            var y = _body.Location.Y + _body.Size.Height / 2;
            CwForm.BulletList.Add(
                new Bullet(Program.Form, Program.Form.GetBullet(), x, y, _gunOrientation, energy, this));
            // projektil vznikne u upevnění děla a má za vzor prvek aBullet - visualní reprezentace projektilu
        }

        public void RotateRadar(int degree)
        {
            _radarOrientation += degree;
            _radarOrientation %= 360;
            _radar.Image = RotateImg(_bitmapRadar, -_radarOrientation);
            UpdateRadar();
        }

        public void UpdateRadar() // poskytuje hráči informace o nepříteli
        {
            for (var i = CwForm.PlayerList.Count - 1; i >= 0; i--)
            {
                if (CwForm.PlayerList[i] == this)
                    continue; // projdeme všechny roboty kromě sebe sama
                var xCurrentPoint = _body.Location.X + _body.Size.Width / 2;
                var yCurrentPoint = _body.Location.Y + _body.Size.Height / 2;
                var xEnemyCenter = CwForm.PlayerList[i]._body.Location.X + CwForm.PlayerList[i]._body.Size.Width / 2;
                var yEnemyCenter = CwForm.PlayerList[i]._body.Location.Y + CwForm.PlayerList[i]._body.Size.Height / 2;
                var xDirection = (int) Math.Round(10 * Math.Cos(Program.DegreeToRad(_radarOrientation)));
                var yDirection = (int) Math.Round(10 * Math.Sin(Program.DegreeToRad(_radarOrientation)));
                while (true)
                {
                    // pro každého se zeptáme, zda leží nejvýše 60 jednotek
                    // od přímky určené středem hráčova vozidla a orientací radaru
                    if (Math.Abs(xCurrentPoint - xEnemyCenter) < 60 && Math.Abs(yCurrentPoint - yEnemyCenter) < 60)
                    {
                        _lastSpottedX = xEnemyCenter;
                        _lastSpottedY = yEnemyCenter;
                        _lastSpottedOrientation = _radarOrientation;
                        break;
                    }

                    xCurrentPoint -= xDirection;
                    yCurrentPoint -= yDirection;
                    if (yCurrentPoint >= CwForm.WorldInfo.BottomOfTheWorld ||
                        yCurrentPoint <= CwForm.WorldInfo.TopOfTheWorld)
                        break;
                    if (xCurrentPoint >= CwForm.WorldInfo.RightOfTheWorld ||
                        xCurrentPoint <= CwForm.WorldInfo.LeftOfTheWorld)
                        break;
                }
            } // ve výsledku získáme pozici robota, který je ve směru radaru nejdále od hráče
        } // tu uložíme do atributů lastSpottedX/Y a pokud se žádný takový nenajde, pak atributy neměníme

        public void GameOver()
        {
            _currHealth = 0;
            _healthRemaining.Width = 0;
            _maxSpeed = 0;
            _body.Image = SetColor((Bitmap) _body.Image, false);
        }
    }
}