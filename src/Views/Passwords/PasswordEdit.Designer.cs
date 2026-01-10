namespace GestorContrasena.Views.Passwords
{
    internal partial class PasswordEdit
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
            SubmitButton = new Button();
            ObservationsInput = new RichTextBox();
            ServiceInput = new TextBox();
            ValueInput = new TextBox();
            NameInput = new TextBox();
            ObservationsLabel = new Label();
            ServiceLabel = new Label();
            ValueLabel = new Label();
            NameLabel = new Label();
            labelPasswordCreate = new Label();
            SuspendLayout();
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(312, 396);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(92, 23);
            SubmitButton.TabIndex = 21;
            SubmitButton.Text = "Guardar";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += EditPassword;
            // 
            // ObservationsInput
            // 
            ObservationsInput.Location = new Point(312, 212);
            ObservationsInput.Name = "ObservationsInput";
            ObservationsInput.Size = new Size(314, 169);
            ObservationsInput.TabIndex = 20;
            ObservationsInput.Text = "";
            // 
            // ServiceInput
            // 
            ServiceInput.Location = new Point(312, 169);
            ServiceInput.Name = "ServiceInput";
            ServiceInput.PlaceholderText = "La plataforma en la que se usa la contraseña...";
            ServiceInput.Size = new Size(314, 23);
            ServiceInput.TabIndex = 19;
            // 
            // ValueInput
            // 
            ValueInput.Location = new Point(312, 130);
            ValueInput.Name = "ValueInput";
            ValueInput.PlaceholderText = "La contraseña a guardar...";
            ValueInput.Size = new Size(314, 23);
            ValueInput.TabIndex = 18;
            // 
            // NameInput
            // 
            NameInput.Location = new Point(312, 92);
            NameInput.Name = "NameInput";
            NameInput.PlaceholderText = "Término para identificar el elemento...";
            NameInput.Size = new Size(314, 23);
            NameInput.TabIndex = 17;
            // 
            // ObservationsLabel
            // 
            ObservationsLabel.AutoSize = true;
            ObservationsLabel.Location = new Point(174, 212);
            ObservationsLabel.Name = "ObservationsLabel";
            ObservationsLabel.Size = new Size(84, 15);
            ObservationsLabel.TabIndex = 16;
            ObservationsLabel.Text = "Observaciones";
            // 
            // ServiceLabel
            // 
            ServiceLabel.AutoSize = true;
            ServiceLabel.Location = new Point(174, 172);
            ServiceLabel.Name = "ServiceLabel";
            ServiceLabel.Size = new Size(48, 15);
            ServiceLabel.TabIndex = 15;
            ServiceLabel.Text = "Servicio";
            // 
            // ValueLabel
            // 
            ValueLabel.AutoSize = true;
            ValueLabel.Location = new Point(174, 133);
            ValueLabel.Name = "ValueLabel";
            ValueLabel.Size = new Size(33, 15);
            ValueLabel.TabIndex = 14;
            ValueLabel.Text = "Valor";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(174, 95);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(51, 15);
            NameLabel.TabIndex = 13;
            NameLabel.Text = "Nombre";
            // 
            // labelPasswordCreate
            // 
            labelPasswordCreate.AutoSize = true;
            labelPasswordCreate.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPasswordCreate.Location = new Point(312, 31);
            labelPasswordCreate.Name = "labelPasswordCreate";
            labelPasswordCreate.Size = new Size(178, 28);
            labelPasswordCreate.TabIndex = 12;
            labelPasswordCreate.Text = "Editar contraseña";
            // 
            // PasswordEdit
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
            Name = "PasswordEdit";
            Text = "Editar contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SubmitButton;
        private RichTextBox ObservationsInput;
        private TextBox ServiceInput;
        private TextBox ValueInput;
        private TextBox NameInput;
        private Label ObservationsLabel;
        private Label ServiceLabel;
        private Label ValueLabel;
        private Label NameLabel;
        private Label labelPasswordCreate;
    }
}