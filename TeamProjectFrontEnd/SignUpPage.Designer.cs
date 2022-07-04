namespace TeamProjectFrontEnd
{
    partial class SignUpPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpPage));
            this.finishBtn = new System.Windows.Forms.Button();
            this.pwdCheckTBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pwdCheckLb = new System.Windows.Forms.Label();
            this.pwdLb = new System.Windows.Forms.Label();
            this.idLb = new System.Windows.Forms.Label();
            this.idCheckBtn = new System.Windows.Forms.Button();
            this.pwdTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.empNoTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // finishBtn
            // 
            this.finishBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.finishBtn.FlatAppearance.BorderSize = 0;
            this.finishBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSalmon;
            this.finishBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSalmon;
            this.finishBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.finishBtn.Location = new System.Drawing.Point(201, 502);
            this.finishBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(286, 62);
            this.finishBtn.TabIndex = 6;
            this.finishBtn.Text = "작성완료";
            this.finishBtn.UseVisualStyleBackColor = false;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // pwdCheckTBox
            // 
            this.pwdCheckTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pwdCheckTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pwdCheckTBox.Location = new System.Drawing.Point(266, 400);
            this.pwdCheckTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pwdCheckTBox.Name = "pwdCheckTBox";
            this.pwdCheckTBox.Size = new System.Drawing.Size(191, 21);
            this.pwdCheckTBox.TabIndex = 5;
            this.pwdCheckTBox.UseSystemPasswordChar = true;
            this.pwdCheckTBox.TextChanged += new System.EventHandler(this.pwdCheckedTBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(161, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "비밀번호 확인";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.pwdCheckLb);
            this.groupBox1.Controls.Add(this.pwdLb);
            this.groupBox1.Controls.Add(this.idLb);
            this.groupBox1.Controls.Add(this.idCheckBtn);
            this.groupBox1.Controls.Add(this.finishBtn);
            this.groupBox1.Controls.Add(this.pwdCheckTBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pwdTBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.idTBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nameTBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.empNoTBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(334, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(686, 625);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "계 정 생 성";
            // 
            // pwdCheckLb
            // 
            this.pwdCheckLb.AutoSize = true;
            this.pwdCheckLb.BackColor = System.Drawing.Color.White;
            this.pwdCheckLb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pwdCheckLb.Location = new System.Drawing.Point(266, 434);
            this.pwdCheckLb.Name = "pwdCheckLb";
            this.pwdCheckLb.Size = new System.Drawing.Size(11, 15);
            this.pwdCheckLb.TabIndex = 14;
            this.pwdCheckLb.Text = " ";
            // 
            // pwdLb
            // 
            this.pwdLb.AutoSize = true;
            this.pwdLb.BackColor = System.Drawing.Color.White;
            this.pwdLb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pwdLb.Location = new System.Drawing.Point(266, 348);
            this.pwdLb.Name = "pwdLb";
            this.pwdLb.Size = new System.Drawing.Size(187, 15);
            this.pwdLb.TabIndex = 13;
            this.pwdLb.Text = "8~20자 이내의 영문 + 숫자 조합";
            // 
            // idLb
            // 
            this.idLb.AutoSize = true;
            this.idLb.BackColor = System.Drawing.Color.White;
            this.idLb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.idLb.Location = new System.Drawing.Point(266, 264);
            this.idLb.Name = "idLb";
            this.idLb.Size = new System.Drawing.Size(175, 15);
            this.idLb.TabIndex = 12;
            this.idLb.Text = "6~15자 이내의 영문 또는 숫자";
            // 
            // idCheckBtn
            // 
            this.idCheckBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.idCheckBtn.FlatAppearance.BorderSize = 0;
            this.idCheckBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSalmon;
            this.idCheckBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSalmon;
            this.idCheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idCheckBtn.Location = new System.Drawing.Point(470, 230);
            this.idCheckBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idCheckBtn.Name = "idCheckBtn";
            this.idCheckBtn.Size = new System.Drawing.Size(114, 26);
            this.idCheckBtn.TabIndex = 3;
            this.idCheckBtn.Text = "중복 체크";
            this.idCheckBtn.UseVisualStyleBackColor = false;
            this.idCheckBtn.Click += new System.EventHandler(this.idCheckBtn_Click);
            // 
            // pwdTBox
            // 
            this.pwdTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pwdTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pwdTBox.Location = new System.Drawing.Point(266, 314);
            this.pwdTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pwdTBox.Name = "pwdTBox";
            this.pwdTBox.Size = new System.Drawing.Size(191, 21);
            this.pwdTBox.TabIndex = 4;
            this.pwdTBox.UseSystemPasswordChar = true;
            this.pwdTBox.TextChanged += new System.EventHandler(this.pwdTBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(161, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "비밀번호";
            // 
            // idTBox
            // 
            this.idTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.idTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.idTBox.Location = new System.Drawing.Point(266, 230);
            this.idTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idTBox.Name = "idTBox";
            this.idTBox.Size = new System.Drawing.Size(191, 21);
            this.idTBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(161, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "아이디";
            // 
            // nameTBox
            // 
            this.nameTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameTBox.Location = new System.Drawing.Point(266, 151);
            this.nameTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(191, 21);
            this.nameTBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(161, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "이름";
            // 
            // empNoTBox
            // 
            this.empNoTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.empNoTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.empNoTBox.Location = new System.Drawing.Point(266, 76);
            this.empNoTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.empNoTBox.Name = "empNoTBox";
            this.empNoTBox.Size = new System.Drawing.Size(191, 21);
            this.empNoTBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(161, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "사원번호";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1353, 795);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1217, 724);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "뒤로가기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SignUpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 795);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SignUpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUpPage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

            this.Text = "회원가입";
        }

        #endregion

        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.TextBox pwdCheckTBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label pwdLb;
        private System.Windows.Forms.Label idLb;
        private System.Windows.Forms.TextBox pwdTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox idTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox empNoTBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button idCheckBtn;
        private System.Windows.Forms.Label pwdCheckLb;
        private System.Windows.Forms.Button button1;
    }
}