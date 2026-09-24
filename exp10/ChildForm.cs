using System.Drawing;
using System.Windows.Forms;

namespace MDIApplication
{
    public class ChildForm : Form
    {
        public ChildForm()
        {
            Text = "Child Form";
            Width = 500;
            Height = 300;

            Label label = new Label();

            label.Text = "This is an MDI Child Form";
            label.Font = new Font("Arial", 18);
            label.AutoSize = true;
            label.Location = new Point(100, 100);

            Controls.Add(label);
        }
    }
}