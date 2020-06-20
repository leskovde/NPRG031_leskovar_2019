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
        private readonly int xSpeed, ySpeed;
        private readonly PictureBox bulletPictureBox;
        private readonly Player originPlayer; // vlastník projektilu

        public Bullet(Control form, PictureBox aBulletModel, int xCoordinate, int yCoordinate,
            int orientation, int speed, Player origin) // na pozici x,y se vytvoří nový prvek formuláře
        {
            // vzhled je nastaven podle vzoru aBulletModel
            bulletPictureBox = new PictureBox
            {
                Size = aBulletModel.Size,
                Image = aBulletModel.Image,
                BackColor = aBulletModel.BackColor
            };
            form.Controls.Add(bulletPictureBox);
            originPlayer = origin;

            // směr pohybu je založen na orientaci děla
            xSpeed = (int) Math.Round(speed * Math.Cos(Program.DegreeToRad(orientation)));
            ySpeed = (int) Math.Round(speed * Math.Sin(Program.DegreeToRad(orientation)));
            bulletPictureBox.Location = new Point(xCoordinate, yCoordinate);
        }

        internal bool ProcessMove()
        {
            // sledujeme pohyb projektilu a měníme jeho pozici
            bulletPictureBox.Location = new Point(bulletPictureBox.Location.X + xSpeed,
                bulletPictureBox.Location.Y - ySpeed);
            if (bulletPictureBox.Location.Y >= CwForm.WorldInfo.BottomOfTheWorld + 100 ||
                bulletPictureBox.Location.Y <= CwForm.WorldInfo.TopOfTheWorld)
                return true; // vracíme true, pokud se chystáme projektil smazat - zde je mimo svět
            if (bulletPictureBox.Location.X >= CwForm.WorldInfo.RightOfTheWorld + 100 ||
                bulletPictureBox.Location.X <= CwForm.WorldInfo.LeftOfTheWorld)
                return true; // opět mimo svět

            for (var i = CwForm.playerList.Count - 1; i >= 0; i--)
                if (CwForm.playerList[i].GetBody().Bounds.IntersectsWith(bulletPictureBox.Bounds))
                    if (CwForm.playerList[i] != originPlayer)
                    {
                        CwForm.playerList[i].DecreaseHealth(10);
                        return true; // zde kolidoval s cizím hráčem, proto ho smažeme a snížíme zdraví
                    }

            return false; // v ostatních případech necháváme projektil pokračovat v letu
        }

        public void ResetBullet() // odstranění dynamicky generovaných projektilů
        {
            bulletPictureBox.Controls.Remove(bulletPictureBox);
            bulletPictureBox.Dispose();
        }
    }
}