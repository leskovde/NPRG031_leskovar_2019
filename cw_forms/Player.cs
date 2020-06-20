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
        private readonly Bitmap bitmapBody, bitmapGun, bitmapRadar;

        // reprezentace ve Forms
        private readonly PictureBox body, gun, radar, healthBar, healthRemaining;

        // atributy jako např. zdraví, rychlost, ...

        private readonly int maxHealth;
        private readonly Point spawnPoint; // souřadnice, na kterých se ve formuláři instance třídy objeví

        // fronta složitých instrukcí daného robota
        public Queue<Instruction> complexQueue;

        private int name,
            currHealth,
            maxSpeed,
            xSpeed,
            ySpeed,
            bodyOrientation,
            gunOrientation,
            radarOrientation,
            //projDamage,
            lastSpottedX,
            lastSpottedY,
            lastSpottedOrientation;

        // fronta jednoduchých instrukcí daného robota
        public Queue<Instruction> instructionQueue;

        // konstruktor pro vytvoření a vykreslení instance do formuláře
        public Player(Control form, CwForm.EntireRobot robot, int health)
        {
            var r = new Random();

            maxHealth = health;
            currHealth = health;
            maxSpeed = 3;

            // pro další vývoj je zde možnost nastavení zbylých atributů

            // dynamické vytvoření prvků formuláře a přiřazení ze vzoru
            var nameLabel = new Label();

            body = PicBoxAssign(form, robot, "body");
            gun = PicBoxAssign(form, robot, "gun");
            radar = PicBoxAssign(form, robot, "radar");
            healthBar = PicBoxAssign(form, robot, "healthBar");
            healthRemaining = PicBoxAssign(form, robot, "healthRemaining");

            // vytvoření náhodného bodu, na kterém se instance při začátku hry objeví
            while (true)
            {
                var finalPoint = true;
                spawnPoint = new Point(
                    r.Next(CwForm.WorldInfo.LeftOfTheWorld, CwForm.WorldInfo.RightOfTheWorld - body.Size.Width),
                    r.Next(CwForm.WorldInfo.TopOfTheWorld, CwForm.WorldInfo.BottomOfTheWorld - body.Size.Height));
                foreach (var others in CwForm.playerList) // pokud jsou roboti příliš blízko, generujeme nový bod
                    if (Math.Abs(spawnPoint.X - others.spawnPoint.X) < 250 &&
                        Math.Abs(spawnPoint.Y - others.spawnPoint.Y) < 250)
                        finalPoint = false;

                if (!finalPoint) continue;
                // pokud je bod ve vzdálenosti alespoň 250 jednotek od všech ostatních robotů, nastavíme jeho pozici
                body.Location = spawnPoint;
                break;
            }

            // ukotvení jednotlivých prvků k sobě, aby se společně hýbaly, navíc řeší překrytí prvků
            // (které původně nemohou být vidět přes neprůhledné pozadí)
            healthBar.Location = new Point(body.Location.X - 20, body.Location.Y - 20);
            bitmapBody = (Bitmap) body.Image;
            bitmapGun = (Bitmap) gun.Image;
            bitmapRadar = (Bitmap) radar.Image;

            body.Controls.Add(gun);
            gun.Location = new Point(0, 0);
            gun.BackColor = Color.Transparent;

            gun.Controls.Add(radar);
            radar.Location = new Point(12, 12);
            radar.BackColor = Color.Transparent;

            healthBar.Controls.Add(healthRemaining);
            healthRemaining.Location = new Point(0, 0);

            name = CwForm.playerList.Count + 1;
            healthRemaining.Controls.Add(nameLabel);
            nameLabel.Location = new Point(0, 0);
            nameLabel.Text = "P" + name;
            //nameLabel.ForeColor = Color.Black;
            nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);
            nameLabel.BackColor = Color.Transparent;

            instructionQueue = new Queue<Instruction>();
            complexQueue = new Queue<Instruction>();
            CwForm.playerList.Add(this);
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
            return body;
        }

        // provedení samotných instrukcí pak probíhá pomocí následujících metod
        // řešení není obecné, v tomto konkrétním případě funguje, jelikož jen měníme atributy objektu
        public void MoveForward(int speed)
        {
            xSpeed = (int) Math.Round(speed * Math.Cos(Program.DegreeToRad(bodyOrientation)));
            ySpeed = (int) Math.Round(speed * Math.Sin(Program.DegreeToRad(bodyOrientation)));

            // ošetření vyjíždění z mapy, při překročení hranice získáme hodnotu hranice
            body.Location = new Point(Math.Max(CwForm.WorldInfo.LeftOfTheWorld,
                    Math.Min(CwForm.WorldInfo.RightOfTheWorld, body.Location.X + xSpeed)),
                Math.Max(CwForm.WorldInfo.TopOfTheWorld,
                    Math.Min(CwForm.WorldInfo.BottomOfTheWorld, body.Location.Y - ySpeed)));

            healthBar.Location = new Point(body.Location.X - 20, body.Location.Y - 20);
            UpdateRadar();
        }

        public void MoveBackwards(int speed)
        {
            MoveForward(-speed);
        }

        public void RotateVehicle(int degree)
        {
            bodyOrientation += degree;
            bodyOrientation %= 360;
            body.Image = RotateImg(bitmapBody, -bodyOrientation);
            UpdateRadar();
        }

        public void DecreaseHealth(int value)
        {
            currHealth -= value;
            healthRemaining.Width = currHealth;

            // při prohře vložíme na první místo fronty vhodnou událost
            if (currHealth <= 0)
            {
                instructionQueue.Clear();
                instructionQueue.Enqueue(new GameOver(0, this));
            }

            UpdateRadar();
        }

        public void ResetGunOrientation()
        {
            gunOrientation = 0;
        }

        public void RotateGun(int degree)
        {
            gunOrientation += degree;
            gunOrientation %= 360;
            gun.Image = RotateImg(bitmapGun, -gunOrientation);
            UpdateRadar();
        }

        public void Fire(int energy)
        {
            var x = body.Location.X + body.Size.Width / 2;
            var y = body.Location.Y + body.Size.Height / 2;
            CwForm.bulletList.Add(
                new Bullet(Program.form, Program.form.GetBullet(), x, y, gunOrientation, energy, this));
            // projektil vznikne u upevnění děla a má za vzor prvek aBullet - visualní reprezentace projektilu
        }

        public void RotateRadar(int degree)
        {
            radarOrientation += degree;
            radarOrientation %= 360;
            radar.Image = RotateImg(bitmapRadar, -radarOrientation);
            UpdateRadar();
        }

        public void UpdateRadar() // poskytuje hráči informace o nepříteli
        {
            for (var i = CwForm.playerList.Count - 1; i >= 0; i--)
            {
                if (CwForm.playerList[i] == this)
                    continue; // projdeme všechny roboty kromě sebe sama
                var xCurrentPoint = body.Location.X + body.Size.Width / 2;
                var yCurrentPoint = body.Location.Y + body.Size.Height / 2;
                var xEnemyCenter = CwForm.playerList[i].body.Location.X + CwForm.playerList[i].body.Size.Width / 2;
                var yEnemyCenter = CwForm.playerList[i].body.Location.Y + CwForm.playerList[i].body.Size.Height / 2;
                var xDirection = (int) Math.Round(10 * Math.Cos(Program.DegreeToRad(radarOrientation)));
                var yDirection = (int) Math.Round(10 * Math.Sin(Program.DegreeToRad(radarOrientation)));
                while (true)
                {
                    // pro každého se zeptáme, zda leží nejvýše 60 jednotek
                    // od přímky určené středem hráčova vozidla a orientací radaru
                    if (Math.Abs(xCurrentPoint - xEnemyCenter) < 60 && Math.Abs(yCurrentPoint - yEnemyCenter) < 60)
                    {
                        lastSpottedX = xEnemyCenter;
                        lastSpottedY = yEnemyCenter;
                        lastSpottedOrientation = radarOrientation;
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
            currHealth = 0;
            healthRemaining.Width = 0;
            maxSpeed = 0;
            body.Image = SetColor((Bitmap) body.Image, false);
        }
    }
}