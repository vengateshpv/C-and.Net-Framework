using System;
using System.Windows.Forms;
class CustomerForm : Form
{
    TextBox n = new(), a = new(), p = new();
    CustomerForm()
    {
        Text = "Customer Details";
        Width = 350; Height = 250;
        n.SetBounds(100,30,180,25);
        a.SetBounds(100,70,180,25);
        p.SetBounds(100,110,180,25);
        Controls.AddRange(new Control[] {
            new Label(){Text="Name:",Left=30,Top=30}, n,
            new Label(){Text="Address:",Left=30,Top=70}, a,
            new Label(){Text="Phone:",Left=30,Top=110}, p
        });
        Button s=new(){Text="Submit",Left=70,Top=160};
        Button c=new(){Text="Clear",Left=170,Top=160};
        s.Click+=(x,y)=>MessageBox.Show($"Customer: {n.Text}\nAddress: {a.Text}\nPhone: {p.Text}");
        c.Click+=(x,y)=>{n.Clear();a.Clear();p.Clear();};
        Controls.AddRange(new Control[]{s,c});
    }
    static void Main()=>Application.Run(new CustomerForm());
}
