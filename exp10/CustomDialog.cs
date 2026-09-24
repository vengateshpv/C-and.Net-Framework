using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDIApplication
{
    public class CustomDialog : Form
    {
        private TextBox nameTextBox;
        private TextBox ageTextBox;

        private Button okButton;
        private Button cancelButton;

        public string StudentName
        {
            get { return nameTextBox.Text; }
        }

        public string StudentAge
        {
            get { return ageTextBox.Text; }
        }

        public CustomDialog()
        {
            // Dialog settings
            Text = "Student Details";
            Width = 400;
            Height = 250;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // Name label
            Label nameLabel = new Label();

            nameLabel.Text = "Name:";
            nameLabel.Location = new Point(40, 40);
            nameLabel.AutoSize = true;

            // Name textbox
            nameTextBox = new TextBox();

            nameTextBox.Location = new Point(120, 35);
            nameTextBox.Width = 200;

            // Age label
            Label ageLabel = new Label();

            ageLabel.Text = "Age:";
            ageLabel.Location = new Point(40, 80);
            ageLabel.AutoSize = true;

            // Age textbox
            ageTextBox = new TextBox();

            ageTextBox.Location = new Point(120, 75);
            ageTextBox.Width = 200;

            // OK button
            okButton = new Button();

            okButton.Text = "OK";
            okButton.Location = new Point(120, 130);
            okButton.Width = 80;

            // Cancel button
            cancelButton = new Button();

            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(220, 130);
            cancelButton.Width = 80;

            // Button events
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;

            // Add controls
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(ageLabel);
            Controls.Add(ageTextBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);

            // Dialog buttons
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || ageTextBox.Text == "")
            {
                MessageBox.Show(
                    "Please enter Name and Age.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}