namespace GestorContrasena.Views.Passwords
{
    partial class PasswordCreate
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
            labelPasswordCreate = new Label();
            NameLabel = new Label();
            ValueLabel = new Label();
            ServiceLabel = new Label();
            ObservationsLabel = new Label();
            NameInput = new TextBox();
            ValueInput = new TextBox();
            ServiceInput = new TextBox();
            ObservationsInput = new RichTextBox();
            SubmitButton = new Button();
            SuspendLayout();
            // 
            // labelPasswordCreate
            // 
            labelPasswordCreate.AutoSize = true;
            labelPasswordCreate.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPasswordCreate.Location = new Point(325, 36);
            labelPasswordCreate.Name = "labelPasswordCreate";
            labelPasswordCreate.Size = new Size(183, 28);
            labelPasswordCreate.TabIndex = 1;
            labelPasswordCreate.Text = "Nueva contraseña";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(187, 100);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(51, 15);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "Nombre";
            // 
            // ValueLabel
            // 
            ValueLabel.AutoSize = true;
            ValueLabel.Location = new Point(187, 138);
            ValueLabel.Name = "ValueLabel";
            ValueLabel.Size = new Size(33, 15);
            ValueLabel.TabIndex = 3;
            ValueLabel.Text = "Valor";
            // 
            // ServiceLabel
            // 
            ServiceLabel.AutoSize = true;
            ServiceLabel.Location = new Point(187, 177);
            ServiceLabel.Name = "ServiceLabel";
            ServiceLabel.Size = new Size(48, 15);
            ServiceLabel.TabIndex = 4;
            ServiceLabel.Text = "Servicio";
            // 
            // ObservationsLabel
            // 
            ObservationsLabel.AutoSize = true;
            ObservationsLabel.Location = new Point(187, 217);
            ObservationsLabel.Name = "ObservationsLabel";
            ObservationsLabel.Size = new Size(84, 15);
            ObservationsLabel.TabIndex = 5;
            ObservationsLabel.Text = "Observaciones";
            // 
            // NameInput
            // 
            NameInput.Location = new Point(325, 97);
            NameInput.Name = "NameInput";
            NameInput.PlaceholderText = "Término para identificar el elemento...";
            NameInput.Size = new Size(314, 23);
            NameInput.TabIndex = 6;
            // 
            // ValueInput
            // 
            ValueInput.Location = new Point(325, 135);
            ValueInput.Name = "ValueInput";
            ValueInput.PlaceholderText = "La contraseña a guardar...";
            ValueInput.Size = new Size(314, 23);
            ValueInput.TabIndex = 7;
            // 
            // ServiceInput
            // 
            ServiceInput.Location = new Point(325, 174);
            ServiceInput.Name = "ServiceInput";
            ServiceInput.PlaceholderText = "La plataforma en la que se usa la contraseña...";
            ServiceInput.Size = new Size(314, 23);
            ServiceInput.TabIndex = 8;
            // 
            // ObservationsInput
            // 
            ObservationsInput.Location = new Point(325, 217);
            ObservationsInput.Name = "ObservationsInput";
            ObservationsInput.Size = new Size(314, 169);
            ObservationsInput.TabIndex = 10;
            ObservationsInput.Text = "";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(325, 401);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(92, 23);
            SubmitButton.TabIndex = 11;
            SubmitButton.Text = "Guardar";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += CreatePasswordAction;
            // 
            // PasswordCreate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SubmitButton);
            Controls.Add(ObservationsInput);
            Controls.Add(ServiceInput);
            Controls.Add(ValueInput);
            Controls.Add(NameInput);
            Controls.Add(ObservationsLabel);
            Controls.Add(ServiceLabel);
            Controls.Add(ValueLabel);
            Controls.Add(NameLabel);
            Controls.Add(labelPasswordCreate);
            Name = "PasswordCreate";
            Text = "Nueva contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPasswordCreate;
        private Label NameLabel;
        private Label ValueLabel;
        private Label ServiceLabel;
        private Label ObservationsLabel;
        private TextBox NameInput;
        private TextBox ValueInput;
        private TextBox ServiceInput;
        private RichTextBox ObservationsInput;
        private Button SubmitButton;
    }
}