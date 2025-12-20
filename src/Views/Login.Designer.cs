namespace GestorContrasena.Views
{
    partial class Login
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
            labelLogin = new Label();
            labelEmail = new Label();
            EmailInput = new TextBox();
            labelPassword = new Label();
            PasswordInput = new TextBox();
            LoginButton = new Button();
            linkLabelRegister = new LinkLabel();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.Location = new Point(293, 37);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(256, 36);
            labelLogin.TabIndex = 1;
            labelLogin.Text = "Inicio de sesión";
            labelLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(247, 171);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email";
            // 
            // EmailInput
            // 
            EmailInput.Location = new Point(339, 168);
            EmailInput.Name = "EmailInput";
            EmailInput.Size = new Size(203, 23);
            EmailInput.TabIndex = 7;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(247, 231);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(67, 15);
            labelPassword.TabIndex = 8;
            labelPassword.Text = "Contraseña";
            // 
            // PasswordInput
            // 
            PasswordInput.Location = new Point(339, 228);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.PasswordChar = '*';
            PasswordInput.Size = new Size(203, 23);
            PasswordInput.TabIndex = 9;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(350, 334);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(116, 23);
            LoginButton.TabIndex = 10;
            LoginButton.Text = "Iniciar sesión";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginAction;
            // 
            // linkLabelRegister
            // 
            linkLabelRegister.AutoSize = true;
            linkLabelRegister.LinkArea = new LinkArea(19, 35);
            linkLabelRegister.Location = new Point(318, 276);
            linkLabelRegister.Name = "linkLabelRegister";
            linkLabelRegister.Size = new Size(195, 21);
            linkLabelRegister.TabIndex = 11;
            linkLabelRegister.TabStop = true;
            linkLabelRegister.Text = "¿No tienes cuenta? Regístrate aquí.";
            linkLabelRegister.UseCompatibleTextRendering = true;
            linkLabelRegister.LinkClicked += ToRegisterAction;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabelRegister);
            Controls.Add(LoginButton);
            Controls.Add(PasswordInput);
            Controls.Add(labelPassword);
            Controls.Add(EmailInput);
            Controls.Add(labelEmail);
            Controls.Add(labelLogin);
            Name = "Login";
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin;
        private Label labelEmail;
        private TextBox EmailInput;
        private Label labelPassword;
        private TextBox PasswordInput;
        private Button LoginButton;
        private LinkLabel linkLabelRegister;
    }
}