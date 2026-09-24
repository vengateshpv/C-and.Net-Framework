using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDIApplication
{
    public class MainForm : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newMenu;
        private ToolStripMenuItem exitMenu;

        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem dialogMenu;

        public MainForm()
        {
            // MDI Parent settings
            Text = "My MDI Application";
            Width = 900;
            Height = 600;
            IsMdiContainer = true;

            // Create MenuStrip
            menuStrip = new MenuStrip();

            // File menu
            fileMenu = new ToolStripMenuItem("File");

            newMenu = new ToolStripMenuItem("New");
            exitMenu = new ToolStripMenuItem("Exit");

            fileMenu.DropDownItems.Add(newMenu);
            fileMenu.DropDownItems.Add(exitMenu);

            // Tools menu
            toolsMenu = new ToolStripMenuItem("Tools");

            dialogMenu = new ToolStripMenuItem("Custom Dialog");

            toolsMenu.DropDownItems.Add(dialogMenu);

            // Add menus
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(toolsMenu);

            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;

            // Events
            newMenu.Click += NewMenu_Click;
            exitMenu.Click += ExitMenu_Click;
            dialogMenu.Click += DialogMenu_Click;
        }

        private void NewMenu_Click(object? sender, EventArgs e)
        {
            ChildForm child = new ChildForm();

            child.MdiParent = this;

            child.Show();
        }

        private void DialogMenu_Click(object? sender, EventArgs e)
        {
            CustomDialog dialog = new CustomDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Name: " + dialog.StudentName +
                    "\nAge: " + dialog.StudentAge,
                    "Student Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void ExitMenu_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}