/* 
     CodeWars 
  	 Denis Leskovar, I. ročník
  	 letní semestr 2018/19 
  	 Programování II NPRG031
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeWars.Forms
{
    public class Bullet
    {
        private readonly int _xSpeed, _ySpeed;
        private readonly PictureBox _bulletPictureBox;
        private readonly Player _originPlayer; // vlastník projektilu

        public Bullet(Control form, PictureBox aBulletModel, int xCoordinate, int yCoordinate,
            int orientation, int speed, Player origin) // na pozici x,y se vytvoří nový prvek formuláře
        {
            // vzhled je nastaven podle vzoru aBulletModel
            _bulletPictureBox = new PictureBox
            {
                Size = aBulletModel.Size,
                Image = aBulletModel.Image,
                BackColor = aBulletModel.BackColor
            };
            form.Controls.Add(_bulletPictureBox);
            _originPlayer = origin;

            // směr pohybu je založen na orientaci děla
            _xSpeed = (int) Math.Round(speed * Math.Cos(Program.DegreeToRad(orientation)));
            _ySpeed = (int) Math.Round(speed * Math.Sin(Program.DegreeToRad(orientation)));
            _bulletPictureBox.Location = new Point(xCoordinate, yCoordinate);
        }

        internal bool ProcessMove()
        {
            // sledujeme pohyb projektilu a měníme jeho pozici
            _bulletPictureBox.Location = new Point(_bulletPictureBox.Location.X + _xSpeed,
                _bulletPictureBox.Location.Y - _ySpeed);
            if (_bulletPictureBox.Location.Y >= CwForm.WorldInfo.BottomOfTheWorld + 100 ||
                _bulletPictureBox.Location.Y <= CwForm.WorldInfo.TopOfTheWorld)
                return true; // vracíme true, pokud se chystáme projektil smazat - zde je mimo svět
            if (_bulletPictureBox.Location.X >= CwForm.WorldInfo.RightOfTheWorld + 100 ||
                _bulletPictureBox.Location.X <= CwForm.WorldInfo.LeftOfTheWorld)
                return true; // opět mimo svět

            for (var i = CwForm.PlayerList.Count - 1; i >= 0; i--)
                if (CwForm.PlayerList[i].GetBody().Bounds.IntersectsWith(_bulletPictureBox.Bounds))
                    if (CwForm.PlayerList[i] != _originPlayer)
                    {
                        CwForm.PlayerList[i].DecreaseHealth(10);
                        return true; // zde kolidoval s cizím hráčem, proto ho smažeme a snížíme zdraví
                    }

            return false; // v ostatních případech necháváme projektil pokračovat v letu
        }

        public void ResetBullet() // odstranění dynamicky generovaných projektilů
        {
            _bulletPictureBox.Controls.Remove(_bulletPictureBox);
            _bulletPictureBox.Dispose();
        }
    }
}