using System;
using System.Drawing;
using System.Windows.Forms;

namespace MdiApplicationDemo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MdiParentForm());
        }
    }

    // 1. The MDI Parent Form
    public class MdiParentForm : Form
    {
        private int childFormNumber = 1;

        public MdiParentForm()
        {
            this.Text = "MDI Application with Menu";
            this.Width = 1024;
            this.Height = 768;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // This is the crucial property that turns this form into an MDI container
            this.IsMdiContainer = true; 

            InitializeMenu();
        }

        private void InitializeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();

            // --- File Menu ---
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("&New Document");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("E&xit");

            // Attach events and shortcuts
            newMenuItem.Click += NewMenuItem_Click;
            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            exitMenuItem.Click += (s, e) => this.Close();

            // Build File Menu
            fileMenu.DropDownItems.Add(newMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitMenuItem);

            // --- Window Menu ---
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("&Window");
            ToolStripMenuItem cascadeMenuItem = new ToolStripMenuItem("&Cascade");
            ToolStripMenuItem tileVerticalMenuItem = new ToolStripMenuItem("Tile &Vertical");
            ToolStripMenuItem tileHorizontalMenuItem = new ToolStripMenuItem("Tile &Horizontal");

            // Use the built-in LayoutMdi method to arrange child windows
            cascadeMenuItem.Click += (s, e) => this.LayoutMdi(MdiLayout.Cascade);
            tileVerticalMenuItem.Click += (s, e) => this.LayoutMdi(MdiLayout.TileVertical);
            tileHorizontalMenuItem.Click += (s, e) => this.LayoutMdi(MdiLayout.TileHorizontal);

            // Build Window Menu
            windowMenu.DropDownItems.Add(cascadeMenuItem);
            windowMenu.DropDownItems.Add(tileVerticalMenuItem);
            windowMenu.DropDownItems.Add(tileHorizontalMenuItem);

            // Add top-level menus to the MenuStrip
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(windowMenu);

            // Automatically list all open MDI child windows under the "Window" menu
            menuStrip.MdiWindowListItem = windowMenu; 

            // Add MenuStrip to the form
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void NewMenuItem_Click(object? sender, EventArgs e)
        {
            // Create a new instance of the child form
            MdiChildForm childForm = new MdiChildForm();
            
            // Link it to the parent container
            childForm.MdiParent = this;
            childForm.Text = $"Document {childFormNumber++}";
            
            // Display the child
            childForm.Show();
        }
    }

    // 2. The MDI Child Form
    public class MdiChildForm : Form
    {
        public MdiChildForm()
        {
            this.Width = 400;
            this.Height = 300;

            // Add a text box so it behaves like a text editor document
            RichTextBox richTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.None
            };

            this.Controls.Add(richTextBox);
        }
    }
}