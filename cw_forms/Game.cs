using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace CodeWars.Forms
{
    public partial class CwForm : Form
    {
        public static List<Bullet> BulletList; // aktivní projektily
        public static List<Player> PlayerList; // aktivní hráči

        public CwForm()
        {
            InitializeComponent();

            // přiřazení elementů formuláře do vzoru robota
            var robot = new EntireRobot(robot1_name, robot1_body, robot1_gun, robot1_radar, healthBar1, healthCurr1);

            PlayerList = new List<Player>();
            for (var i = 0; i < CwMenu.PlayerCount; i++)
                PlayerList.Add(new Player(this, robot, 100));
            for (var i = PlayerList.Count - 1; i >= 0; i--)
            {
                Parse.SendGrammar(CwMenu.Code[i], PlayerList[i]);
                Engine.Prepare(PlayerList[i].ComplexQueue);
            }

            BulletList = new List<Bullet>();
        }

        public PictureBox GetBullet()
        {
            return aBullet;
        }

        public void ToggleDebug()
        {
            debug_x.Visible = true;
            debug_y.Visible = true;
            orient.Visible = true;
            bulletCount.Visible = true;
            lastSpottedX.Visible = true;
            lastSpottedY.Visible = true;
        }

        private void Debug() // info o směru pohybu, orientaci a počtu aktivních projektilů
        {
            debug_x.Text = "X axis movement = " + PlayerList[0].GetAttrib("xSpeed");
            debug_y.Text = "Y axis movement = " + PlayerList[0].GetAttrib("ySpeed");
            orient.Text = "Orientation = " + PlayerList[0].GetAttrib("bodyOrientation");
            bulletCount.Text = BulletList.Count.ToString();
            lastSpottedX.Text = "Last spotted X = " + PlayerList[0].GetAttrib("lastSpottedX");
            lastSpottedY.Text = "Last spotted Y = " + PlayerList[0].GetAttrib("lastSpottedY");
        }

        //Engine engine;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // v každém ticku provedeme jednu instrukci pro každého aktivního hráče
            Debug();
            if (Engine.RunSimulation(PlayerList))
            {
                var result = Engine.GetTickCount() == 15000
                    ? MessageBox.Show("Vypršel čas!", "Konec hry")
                    : MessageBox.Show("Vítěz\nHráč " + PlayerList[0].GetAttrib("name"), "Konec hry");
                if (result == DialogResult.OK)
                    Environment.Exit(0);
            }

            // zkontrolujeme pohyb aktivních projektilů
            for (var i = BulletList.Count - 1; i >= 0; i--)
                if (BulletList[i].ProcessMove())
                {
                    BulletList[i].ResetBullet();
                    BulletList.RemoveAt(i);
                }
        }

        public struct EntireRobot // outline pro robota, který se předá jednotlivým instancím
        {
            private Label _name;
            private PictureBox _body, _gun, _radar, _healthBar, _healthRemaining;

            public PictureBox GetPictureBox(string attribName)
            {
                return (PictureBox) GetType().GetField(attribName, BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(this);
            }

            public EntireRobot(Label name, PictureBox body, PictureBox gun, PictureBox radar, PictureBox healthBar,
                PictureBox healthRemaining)
            {
                _name = name;
                _body = body;
                _gun = gun;
                _radar = radar;
                _healthBar = healthBar;
                _healthRemaining = healthRemaining;
            }
        }

        public class WorldInfo // hranice okna pro případnou změnu velikosti formuláře
        {
            // A whole new world, a dazzling place I never knew
            public const int TopOfTheWorld = 20;
            public const int BottomOfTheWorld = 600;
            public const int LeftOfTheWorld = 20;
            public const int RightOfTheWorld = 805;
        }
    }
}