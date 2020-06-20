namespace CodeWars.Forms
{
    partial class CwForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.debug_x = new System.Windows.Forms.Label();
            this.debug_y = new System.Windows.Forms.Label();
            this.orient = new System.Windows.Forms.Label();
            this.bulletCount = new System.Windows.Forms.Label();
            this.lastSpottedX = new System.Windows.Forms.Label();
            this.lastSpottedY = new System.Windows.Forms.Label();
            this.robot1_name = new System.Windows.Forms.Label();
            this.healthCurr1 = new System.Windows.Forms.PictureBox();
            this.healthBar1 = new System.Windows.Forms.PictureBox();
            this.aBullet = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.robot1_radar = new System.Windows.Forms.PictureBox();
            this.robot1_gun = new System.Windows.Forms.PictureBox();
            this.robot1_body = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.healthCurr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robot1_radar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robot1_gun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robot1_body)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // debug_x
            // 
            this.debug_x.AutoSize = true;
            this.debug_x.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.debug_x.ForeColor = System.Drawing.SystemColors.ControlText;
            this.debug_x.Location = new System.Drawing.Point(12, 9);
            this.debug_x.Name = "debug_x";
            this.debug_x.Size = new System.Drawing.Size(66, 13);
            this.debug_x.TabIndex = 3;
            this.debug_x.Text = "X movement";
            this.debug_x.Visible = false;
            // 
            // debug_y
            // 
            this.debug_y.AutoSize = true;
            this.debug_y.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.debug_y.ForeColor = System.Drawing.SystemColors.ControlText;
            this.debug_y.Location = new System.Drawing.Point(12, 32);
            this.debug_y.Name = "debug_y";
            this.debug_y.Size = new System.Drawing.Size(66, 13);
            this.debug_y.TabIndex = 4;
            this.debug_y.Text = "Y movement";
            this.debug_y.Visible = false;
            // 
            // orient
            // 
            this.orient.AutoSize = true;
            this.orient.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.orient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.orient.Location = new System.Drawing.Point(12, 58);
            this.orient.Name = "orient";
            this.orient.Size = new System.Drawing.Size(58, 13);
            this.orient.TabIndex = 6;
            this.orient.Text = "Orientation";
            this.orient.Visible = false;
            // 
            // bulletCount
            // 
            this.bulletCount.AutoSize = true;
            this.bulletCount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bulletCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bulletCount.Location = new System.Drawing.Point(12, 84);
            this.bulletCount.Name = "bulletCount";
            this.bulletCount.Size = new System.Drawing.Size(58, 13);
            this.bulletCount.TabIndex = 8;
            this.bulletCount.Text = "Proj. count";
            this.bulletCount.Visible = false;
            // 
            // lastSpottedX
            // 
            this.lastSpottedX.AutoSize = true;
            this.lastSpottedX.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lastSpottedX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lastSpottedX.Location = new System.Drawing.Point(12, 109);
            this.lastSpottedX.Name = "lastSpottedX";
            this.lastSpottedX.Size = new System.Drawing.Size(67, 13);
            this.lastSpottedX.TabIndex = 11;
            this.lastSpottedX.Text = "lastSpottedX";
            this.lastSpottedX.Visible = false;
            // 
            // lastSpottedY
            // 
            this.lastSpottedY.AutoSize = true;
            this.lastSpottedY.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lastSpottedY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lastSpottedY.Location = new System.Drawing.Point(12, 132);
            this.lastSpottedY.Name = "lastSpottedY";
            this.lastSpottedY.Size = new System.Drawing.Size(67, 13);
            this.lastSpottedY.TabIndex = 12;
            this.lastSpottedY.Text = "lastSpottedY";
            this.lastSpottedY.Visible = false;
            // 
            // robot1_name
            // 
            this.robot1_name.AutoSize = true;
            this.robot1_name.Location = new System.Drawing.Point(76, 395);
            this.robot1_name.Name = "robot1_name";
            this.robot1_name.Size = new System.Drawing.Size(0, 13);
            this.robot1_name.TabIndex = 13;
            // 
            // healthCurr1
            // 
            this.healthCurr1.BackColor = System.Drawing.Color.White;
            this.healthCurr1.Location = new System.Drawing.Point(43, 395);
            this.healthCurr1.Name = "healthCurr1";
            this.healthCurr1.Size = new System.Drawing.Size(100, 15);
            this.healthCurr1.TabIndex = 10;
            this.healthCurr1.TabStop = false;
            this.healthCurr1.Visible = false;
            // 
            // healthBar1
            // 
            this.healthBar1.BackColor = System.Drawing.Color.DimGray;
            this.healthBar1.Location = new System.Drawing.Point(43, 416);
            this.healthBar1.Name = "healthBar1";
            this.healthBar1.Size = new System.Drawing.Size(100, 15);
            this.healthBar1.TabIndex = 9;
            this.healthBar1.TabStop = false;
            this.healthBar1.Visible = false;
            // 
            // aBullet
            // 
            this.aBullet.BackColor = System.Drawing.Color.Transparent;
            this.aBullet.Image = global::CodeWars.Forms.Properties.Resources.projectile;
            this.aBullet.Location = new System.Drawing.Point(757, 534);
            this.aBullet.Name = "aBullet";
            this.aBullet.Size = new System.Drawing.Size(15, 15);
            this.aBullet.TabIndex = 7;
            this.aBullet.TabStop = false;
            this.aBullet.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // robot1_radar
            // 
            this.robot1_radar.BackColor = System.Drawing.Color.Transparent;
            this.robot1_radar.Image = global::CodeWars.Forms.Properties.Resources.robot_radar;
            this.robot1_radar.Location = new System.Drawing.Point(240, 448);
            this.robot1_radar.Name = "robot1_radar";
            this.robot1_radar.Size = new System.Drawing.Size(60, 60);
            this.robot1_radar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.robot1_radar.TabIndex = 2;
            this.robot1_radar.TabStop = false;
            this.robot1_radar.Visible = false;
            // 
            // robot1_gun
            // 
            this.robot1_gun.BackColor = System.Drawing.Color.Transparent;
            this.robot1_gun.Image = global::CodeWars.Forms.Properties.Resources.robot_gun;
            this.robot1_gun.Location = new System.Drawing.Point(149, 437);
            this.robot1_gun.Name = "robot1_gun";
            this.robot1_gun.Size = new System.Drawing.Size(85, 85);
            this.robot1_gun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.robot1_gun.TabIndex = 1;
            this.robot1_gun.TabStop = false;
            this.robot1_gun.Visible = false;
            // 
            // robot1_body
            // 
            this.robot1_body.BackColor = System.Drawing.SystemColors.Desktop;
            this.robot1_body.Image = global::CodeWars.Forms.Properties.Resources.robot_body;
            this.robot1_body.Location = new System.Drawing.Point(58, 437);
            this.robot1_body.Name = "robot1_body";
            this.robot1_body.Size = new System.Drawing.Size(85, 85);
            this.robot1_body.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.robot1_body.TabIndex = 0;
            this.robot1_body.TabStop = false;
            this.robot1_body.Visible = false;
            // 
            // CwForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.robot1_name);
            this.Controls.Add(this.lastSpottedY);
            this.Controls.Add(this.lastSpottedX);
            this.Controls.Add(this.healthCurr1);
            this.Controls.Add(this.healthBar1);
            this.Controls.Add(this.bulletCount);
            this.Controls.Add(this.aBullet);
            this.Controls.Add(this.orient);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.debug_y);
            this.Controls.Add(this.debug_x);
            this.Controls.Add(this.robot1_radar);
            this.Controls.Add(this.robot1_gun);
            this.Controls.Add(this.robot1_body);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CwForm";
            this.Text = "CodeWars";
            ((System.ComponentModel.ISupportInitialize)(this.healthCurr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robot1_radar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robot1_gun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robot1_body)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox robot1_body;
        private System.Windows.Forms.PictureBox robot1_gun;
        private System.Windows.Forms.PictureBox robot1_radar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label debug_x;
        private System.Windows.Forms.Label debug_y;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label orient;
        private System.Windows.Forms.Label bulletCount;
        private System.Windows.Forms.PictureBox aBullet;
        private System.Windows.Forms.PictureBox healthBar1;
        private System.Windows.Forms.PictureBox healthCurr1;
        private System.Windows.Forms.Label lastSpottedX;
        private System.Windows.Forms.Label lastSpottedY;
        private System.Windows.Forms.Label robot1_name;
    }
}

