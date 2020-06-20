using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace CodeWars.Forms
{
    public partial class CwForm : Form
    {
        public static List<Bullet> bulletList; // aktivní projektily
        public static List<Player> playerList; // aktivní hráči

        public CwForm()
        {
            InitializeComponent();

            // přiřazení elementů formuláře do vzoru robota
            var robot = new EntireRobot(robot1_name, robot1_body, robot1_gun, robot1_radar, healthBar1, healthCurr1);

            playerList = new List<Player>();
            for (var i = 0; i < CwMenu.playerCount; i++)
                new Player(this, robot, 100);
            for (var i = playerList.Count - 1; i >= 0; i--)
            {
                Parse.SendGrammar(CwMenu.code[i], playerList[i]);
                Engine.Prepare(playerList[i].complexQueue);
            }

            bulletList = new List<Bullet>();
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
            debug_x.Text = "X axis movement = " + playerList[0].GetAttrib("xSpeed");
            debug_y.Text = "Y axis movement = " + playerList[0].GetAttrib("ySpeed");
            orient.Text = "Orientation = " + playerList[0].GetAttrib("bodyOrientation");
            bulletCount.Text = bulletList.Count.ToString();
            lastSpottedX.Text = "Last spotted X = " + playerList[0].GetAttrib("lastSpottedX");
            lastSpottedY.Text = "Last spotted Y = " + playerList[0].GetAttrib("lastSpottedY");
        }

        //Engine engine;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // v každém ticku provedeme jednu instrukci pro každého aktivního hráče
            Debug();
            if (Engine.RunSimulation(playerList))
            {
                var result = Engine.GetTickCount() == 15000
                    ? MessageBox.Show("Vypršel čas!", "Konec hry")
                    : MessageBox.Show("Vítěz\nHráč " + playerList[0].GetAttrib("name"), "Konec hry");
                if (result == DialogResult.OK)
                    Environment.Exit(0);
            }

            // zkontrolujeme pohyb aktivních projektilů
            for (var i = bulletList.Count - 1; i >= 0; i--)
                if (bulletList[i].ProcessMove())
                {
                    bulletList[i].ResetBullet();
                    bulletList.RemoveAt(i);
                }
        }

        public struct EntireRobot // outline pro robota, který se předá jednotlivým instancím
        {
            private Label name;
            private PictureBox body, gun, radar, healthBar, healthRemaining;

            public PictureBox GetPictureBox(string attribName)
            {
                return (PictureBox) GetType().GetField(attribName, BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(this);
            }

            public EntireRobot(Label name, PictureBox body, PictureBox gun, PictureBox radar, PictureBox healthBar,
                PictureBox healthRemaining)
            {
                this.name = name;
                this.body = body;
                this.gun = gun;
                this.radar = radar;
                this.healthBar = healthBar;
                this.healthRemaining = healthRemaining;
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