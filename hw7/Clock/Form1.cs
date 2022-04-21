namespace Clock;

using System.Runtime.InteropServices;
public partial class Form1 : Form
{
    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool ReleaseCapture();

    public Form1()
    {
        InitializeComponent();
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
    }
}
