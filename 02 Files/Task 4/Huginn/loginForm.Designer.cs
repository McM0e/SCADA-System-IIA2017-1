namespace Huginn
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lklblNewUser = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkLblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 95);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(325, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(12, 150);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(325, 20);
            this.txtPasswd.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(88, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 55);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Login";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblPasswd
            // 
            this.lblPasswd.AutoSize = true;
            this.lblPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswd.Location = new System.Drawing.Point(8, 127);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(78, 20);
            this.lblPasswd.TabIndex = 3;
            this.lblPasswd.Text = "Password";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 72);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // lklblNewUser
            // 
            this.lklblNewUser.AutoSize = true;
            this.lklblNewUser.Location = new System.Drawing.Point(12, 173);
            this.lklblNewUser.Name = "lklblNewUser";
            this.lklblNewUser.Size = new System.Drawing.Size(54, 13);
            this.lklblNewUser.TabIndex = 5;
            this.lklblNewUser.TabStop = true;
            this.lklblNewUser.Text = "New User";
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(262, 214);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 28);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkLblForgotPassword
            // 
            this.lnkLblForgotPassword.AutoSize = true;
            this.lnkLblForgotPassword.Location = new System.Drawing.Point(251, 173);
            this.lnkLblForgotPassword.Name = "lnkLblForgotPassword";
            this.lnkLblForgotPassword.Size = new System.Drawing.Size(86, 13);
            this.lnkLblForgotPassword.TabIndex = 7;
            this.lnkLblForgotPassword.TabStop = true;
            this.lnkLblForgotPassword.Text = "Forgot Password";
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 254);
            this.Controls.Add(this.lnkLblForgotPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lklblNewUser);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPasswd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.LinkLabel lklblNewUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkLblForgotPassword;
        protected internal System.Windows.Forms.TextBox txtEmail;
    }
}