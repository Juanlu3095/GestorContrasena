namespace GestorContrasena.Views
{
    partial class Register
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelRegister = new Label();
            labelName = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            RegisterButton = new Button();
            NameInput = new TextBox();
            EmailInput = new TextBox();
            PasswordInput = new TextBox();
            SuspendLayout();
            // 
            // labelRegister
            // 
            labelRegister.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRegister.Location = new Point(270, 38);
            labelRegister.Name = "labelRegister";
            labelRegister.Size = new Size(256, 36);
            labelRegister.TabIndex = 0;
            labelRegister.Text = "Formulario de registro";
            labelRegister.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(245, 156);
            labelName.Name = "labelName";
            labelName.Size = new Size(53, 15);
            labelName.TabIndex = 1;
            labelName.Text = "Nombre";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(245, 204);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(245, 246);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(69, 15);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Contraseña";
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(335, 326);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(116, 23);
            RegisterButton.TabIndex = 4;
            RegisterButton.Text = "Registrarse";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterAction;
            // 
            // NameInput
            // 
            NameInput.Location = new Point(335, 153);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(203, 23);
            NameInput.TabIndex = 5;
            // 
            // EmailInput
            // 
            EmailInput.Location = new Point(335, 201);
            EmailInput.Name = "EmailInput";
            EmailInput.Size = new Size(203, 23);
            EmailInput.TabIndex = 6;
            // 
            // PasswordInput
            // 
            PasswordInput.Location = new Point(335, 243);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.PasswordChar = '*';
            PasswordInput.Size = new Size(203, 23);
            PasswordInput.TabIndex = 7;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PasswordInput);
            Controls.Add(EmailInput);
            Controls.Add(NameInput);
            Controls.Add(RegisterButton);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(labelName);
            Controls.Add(labelRegister);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Register";
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRegister;
        private Label labelName;
        private Label labelEmail;
        private Label labelPassword;
        private Button RegisterButton;
        private TextBox NameInput;
        private TextBox EmailInput;
        private TextBox PasswordInput;
    }
}
