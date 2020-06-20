using System;
using System.Windows.Forms;

namespace CodeWars.Forms
{
    public partial class CwMenu : Form
    {
        public static int PlayerCount = 1;
        public static string[] Code = new string[4];

        public CwMenu()
        {
            InitializeComponent();
            player1codeSpace.Visible = true;
            player1Name.Visible = true;
            player2codeSpace.Visible = false;
            player2Name.Visible = false;
            player3codeSpace.Visible = false;
            player3Name.Visible = false;
            player4codeSpace.Visible = false;
            player4Name.Visible = false;
        }

        private void NoOfPlayers1_CheckedChanged(object sender, EventArgs e)
        {
            player1codeSpace.Visible = true;
            player1Name.Visible = true;
            player2codeSpace.Visible = false;
            player2Name.Visible = false;
            player2codeSpace.Clear();
            player3codeSpace.Visible = false;
            player3Name.Visible = false;
            player3codeSpace.Clear();
            player4codeSpace.Visible = false;
            player4Name.Visible = false;
            player4codeSpace.Clear();
            PlayerCount = 1;
        }

        private void NoOfPlayers2_CheckedChanged(object sender, EventArgs e)
        {
            player1codeSpace.Visible = true;
            player1Name.Visible = true;
            player2codeSpace.Visible = true;
            player2Name.Visible = true;
            player3codeSpace.Visible = false;
            player3Name.Visible = false;
            player3codeSpace.Clear();
            player4codeSpace.Visible = false;
            player4Name.Visible = false;
            player4codeSpace.Clear();
            PlayerCount = 2;
        }

        private void NoOfPlayers3_CheckedChanged(object sender, EventArgs e)
        {
            player1codeSpace.Visible = true;
            player1Name.Visible = true;
            player2codeSpace.Visible = true;
            player2Name.Visible = true;
            player3codeSpace.Visible = true;
            player3Name.Visible = true;
            player4codeSpace.Visible = false;
            player4Name.Visible = false;
            player4codeSpace.Clear();
            PlayerCount = 3;
        }

        private void NoOfPlayers4_CheckedChanged(object sender, EventArgs e)
        {
            player1codeSpace.Visible = true;
            player1Name.Visible = true;
            player2codeSpace.Visible = true;
            player2Name.Visible = true;
            player3codeSpace.Visible = true;
            player3Name.Visible = true;
            player4codeSpace.Visible = true;
            player4Name.Visible = true;
            PlayerCount = 4;
        }

        private void MenuStart_Click(object sender, EventArgs e)
        {
            Code[0] = player1codeSpace.Text;
            Code[1] = player2codeSpace.Text;
            Code[2] = player3codeSpace.Text;
            Code[3] = player4codeSpace.Text;
            Program.Form = new CwForm();
            if (debugCheck.Checked)
                Program.Form.ToggleDebug();
            Hide();
            Program.Form.ShowDialog();
            Close();
        }

        private void MenuDemo_Click(object sender, EventArgs e)
        {
            noOfPlayers2.Checked = true;
            player1codeSpace.Text = "TurnRight(45);\nRotateRadarLeft(360);\nRotateGunLeft(var);\n" +
                                    "Forward(50);\nRotateRadarLeft(360);\nRotateGunLeft(var);\n" +
                                    "Fire(1);\n";
            player2codeSpace.Text = "RotateRadarLeft(180);\nTurnLeft(180);\nForward(100);" +
                                    "RotateGunLeft(var);\nFire(1);\nTurnRight(20);\n";
        }
    }
}