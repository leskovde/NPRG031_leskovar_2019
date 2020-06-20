namespace CodeWars.Forms
{
    partial class CwMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1codeSpace = new System.Windows.Forms.RichTextBox();
            this.player2codeSpace = new System.Windows.Forms.RichTextBox();
            this.player3codeSpace = new System.Windows.Forms.RichTextBox();
            this.player4codeSpace = new System.Windows.Forms.RichTextBox();
            this.player1Name = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.Label();
            this.player3Name = new System.Windows.Forms.Label();
            this.player4Name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.noOfPlayers1 = new System.Windows.Forms.RadioButton();
            this.noOfPlayers2 = new System.Windows.Forms.RadioButton();
            this.noOfPlayers3 = new System.Windows.Forms.RadioButton();
            this.noOfPlayers4 = new System.Windows.Forms.RadioButton();
            this.menuStart = new System.Windows.Forms.Button();
            this.menuDemo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.debugCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // player1codeSpace
            // 
            this.player1codeSpace.Location = new System.Drawing.Point(11, 112);
            this.player1codeSpace.Name = "player1codeSpace";
            this.player1codeSpace.Size = new System.Drawing.Size(200, 270);
            this.player1codeSpace.TabIndex = 2;
            this.player1codeSpace.Text = "";
            // 
            // player2codeSpace
            // 
            this.player2codeSpace.Location = new System.Drawing.Point(231, 112);
            this.player2codeSpace.Name = "player2codeSpace";
            this.player2codeSpace.Size = new System.Drawing.Size(200, 270);
            this.player2codeSpace.TabIndex = 3;
            this.player2codeSpace.Text = "";
            // 
            // player3codeSpace
            // 
            this.player3codeSpace.Location = new System.Drawing.Point(451, 112);
            this.player3codeSpace.Name = "player3codeSpace";
            this.player3codeSpace.Size = new System.Drawing.Size(200, 270);
            this.player3codeSpace.TabIndex = 4;
            this.player3codeSpace.Text = "";
            // 
            // player4codeSpace
            // 
            this.player4codeSpace.Location = new System.Drawing.Point(671, 112);
            this.player4codeSpace.Name = "player4codeSpace";
            this.player4codeSpace.Size = new System.Drawing.Size(200, 270);
            this.player4codeSpace.TabIndex = 5;
            this.player4codeSpace.Text = "";
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Location = new System.Drawing.Point(91, 96);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(39, 13);
            this.player1Name.TabIndex = 6;
            this.player1Name.Text = "Hráč 1";
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Location = new System.Drawing.Point(324, 96);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(39, 13);
            this.player2Name.TabIndex = 7;
            this.player2Name.Text = "Hráč 2";
            // 
            // player3Name
            // 
            this.player3Name.AutoSize = true;
            this.player3Name.Location = new System.Drawing.Point(535, 96);
            this.player3Name.Name = "player3Name";
            this.player3Name.Size = new System.Drawing.Size(39, 13);
            this.player3Name.TabIndex = 8;
            this.player3Name.Text = "Hráč 3";
            // 
            // player4Name
            // 
            this.player4Name.AutoSize = true;
            this.player4Name.Location = new System.Drawing.Point(760, 96);
            this.player4Name.Name = "player4Name";
            this.player4Name.Size = new System.Drawing.Size(39, 13);
            this.player4Name.TabIndex = 9;
            this.player4Name.Text = "Hráč 4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(36, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Počet hráčů:";
            // 
            // noOfPlayers1
            // 
            this.noOfPlayers1.AutoSize = true;
            this.noOfPlayers1.Checked = true;
            this.noOfPlayers1.Location = new System.Drawing.Point(160, 39);
            this.noOfPlayers1.Name = "noOfPlayers1";
            this.noOfPlayers1.Size = new System.Drawing.Size(31, 17);
            this.noOfPlayers1.TabIndex = 11;
            this.noOfPlayers1.TabStop = true;
            this.noOfPlayers1.Text = "1";
            this.noOfPlayers1.UseVisualStyleBackColor = true;
            this.noOfPlayers1.CheckedChanged += new System.EventHandler(this.NoOfPlayers1_CheckedChanged);
            // 
            // noOfPlayers2
            // 
            this.noOfPlayers2.AutoSize = true;
            this.noOfPlayers2.Location = new System.Drawing.Point(197, 39);
            this.noOfPlayers2.Name = "noOfPlayers2";
            this.noOfPlayers2.Size = new System.Drawing.Size(31, 17);
            this.noOfPlayers2.TabIndex = 12;
            this.noOfPlayers2.Text = "2";
            this.noOfPlayers2.UseVisualStyleBackColor = true;
            this.noOfPlayers2.CheckedChanged += new System.EventHandler(this.NoOfPlayers2_CheckedChanged);
            // 
            // noOfPlayers3
            // 
            this.noOfPlayers3.AutoSize = true;
            this.noOfPlayers3.Location = new System.Drawing.Point(234, 40);
            this.noOfPlayers3.Name = "noOfPlayers3";
            this.noOfPlayers3.Size = new System.Drawing.Size(31, 17);
            this.noOfPlayers3.TabIndex = 13;
            this.noOfPlayers3.Text = "3";
            this.noOfPlayers3.UseVisualStyleBackColor = true;
            this.noOfPlayers3.CheckedChanged += new System.EventHandler(this.NoOfPlayers3_CheckedChanged);
            // 
            // noOfPlayers4
            // 
            this.noOfPlayers4.AutoSize = true;
            this.noOfPlayers4.Location = new System.Drawing.Point(271, 40);
            this.noOfPlayers4.Name = "noOfPlayers4";
            this.noOfPlayers4.Size = new System.Drawing.Size(31, 17);
            this.noOfPlayers4.TabIndex = 14;
            this.noOfPlayers4.Text = "4";
            this.noOfPlayers4.UseVisualStyleBackColor = true;
            this.noOfPlayers4.CheckedChanged += new System.EventHandler(this.NoOfPlayers4_CheckedChanged);
            // 
            // menuStart
            // 
            this.menuStart.Location = new System.Drawing.Point(749, 37);
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(107, 23);
            this.menuStart.TabIndex = 15;
            this.menuStart.Text = "Start";
            this.menuStart.UseVisualStyleBackColor = true;
            this.menuStart.Click += new System.EventHandler(this.MenuStart_Click);
            // 
            // menuDemo
            // 
            this.menuDemo.Location = new System.Drawing.Point(636, 37);
            this.menuDemo.Name = "menuDemo";
            this.menuDemo.Size = new System.Drawing.Size(107, 23);
            this.menuDemo.TabIndex = 16;
            this.menuDemo.Text = "Demo";
            this.menuDemo.UseVisualStyleBackColor = true;
            this.menuDemo.Click += new System.EventHandler(this.MenuDemo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(13, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nápověda:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Forward(<počet pixelů>)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Backwards(<počet pixelů>)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "TurnLeft(<velikost úhlu>)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "TurnRight(<velikost úhlu>)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(194, 498);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "RotateRadarRight(<velikost úhlu>)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(194, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "RotateRadarLeft(<velikost úhlu>)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 453);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "RotateGunRight(<velikost úhlu>)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(194, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "RotateGunLeft(<velikost úhlu>)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 521);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Fire(<1>)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(194, 521);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(228, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Var - úhel, pod nímž byl spatřen poslední robot";
            // 
            // debugCheck
            // 
            this.debugCheck.AutoSize = true;
            this.debugCheck.Location = new System.Drawing.Point(763, 66);
            this.debugCheck.Name = "debugCheck";
            this.debugCheck.Size = new System.Drawing.Size(79, 17);
            this.debugCheck.TabIndex = 28;
            this.debugCheck.Text = "Debug Info";
            this.debugCheck.UseVisualStyleBackColor = true;
            // 
            // cwMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.debugCheck);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuDemo);
            this.Controls.Add(this.menuStart);
            this.Controls.Add(this.noOfPlayers4);
            this.Controls.Add(this.noOfPlayers3);
            this.Controls.Add(this.noOfPlayers2);
            this.Controls.Add(this.noOfPlayers1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.player4Name);
            this.Controls.Add(this.player3Name);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.player4codeSpace);
            this.Controls.Add(this.player3codeSpace);
            this.Controls.Add(this.player2codeSpace);
            this.Controls.Add(this.player1codeSpace);
            this.Name = "CwMenu";
            this.Text = "CodeWars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox player2codeSpace;
        private System.Windows.Forms.RichTextBox player3codeSpace;
        private System.Windows.Forms.RichTextBox player4codeSpace;
        private System.Windows.Forms.Label player1Name;
        private System.Windows.Forms.Label player2Name;
        private System.Windows.Forms.Label player3Name;
        private System.Windows.Forms.Label player4Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton noOfPlayers1;
        private System.Windows.Forms.RadioButton noOfPlayers2;
        private System.Windows.Forms.RadioButton noOfPlayers3;
        private System.Windows.Forms.RadioButton noOfPlayers4;
        private System.Windows.Forms.Button menuStart;
        private System.Windows.Forms.Button menuDemo;
        private System.Windows.Forms.RichTextBox player1codeSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox debugCheck;
    }
}