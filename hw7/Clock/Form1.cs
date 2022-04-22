namespace Clock;

using System.Runtime.InteropServices;
public partial class Form1 : Form
{
    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool ReleaseCapture();

    private static (int, int) SecMinCurrentCoords(int secMinCurrent, int arrowLength, int cX, int cY)
    {
        secMinCurrent *= 6;
        var xResult = cX + ((secMinCurrent >= 0 && secMinCurrent <= 180) ? (int)(arrowLength * Math.Sin(Math.PI * secMinCurrent / 180)) :
            -(int)(arrowLength * -Math.Sin(Math.PI * secMinCurrent / 180)));
        var yResult = cY - ((secMinCurrent >= 0 && secMinCurrent <= 180) ? (int)(arrowLength * Math.Cos(Math.PI * secMinCurrent / 180)) :
            (int)(arrowLength * Math.Cos(Math.PI * secMinCurrent / 180)));
        return (xResult, yResult);
    }

    private static (int, int) HCurrentCoords(int hCurrent, int mCurrent, int hLength, int cX, int cY)
    {
        var timeCurrent = (int)(hCurrent * 30 + mCurrent * 0.5);
        var xResult = cX + ((timeCurrent >= 0 && timeCurrent <= 180) ? (int)(hLength * Math.Sin(Math.PI * timeCurrent / 180)) :
            -(int)(hLength * -Math.Sin(Math.PI * timeCurrent / 180)));
        var yResult = cY - ((timeCurrent >= 0 && timeCurrent <= 180) ? (int)(hLength * Math.Cos(Math.PI * timeCurrent / 180)) :
            -(int)(hLength * Math.Cos(Math.PI * timeCurrent / 180)));
        return (xResult, yResult);
    }

    private (int, int) center = (160, 160);
    private int secondArrow = 100;
    private int minuteArrow = 90;
    private int hourArrow = 75;

    public Form1()
    {
        this.TransparencyKey = this.BackColor;
        InitializeComponent();
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        ReleaseCapture();
        PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        int s = DateTime.Now.Second;
        int m = DateTime.Now.Minute;
        int h = DateTime.Now.Hour;
        (int, int) arrowCoords;

        Graphics graphics = pictureBox1.CreateGraphics();

        // Стираем стрелки
        arrowCoords = SecMinCurrentCoords(s, secondArrow, center.Item1, center.Item2);
        graphics.DrawLine(new Pen(Color.White, 30f), new Point(center.Item1, center.Item2),
            new Point(arrowCoords.Item1, arrowCoords.Item2));

        arrowCoords = SecMinCurrentCoords(m, minuteArrow, center.Item1, center.Item2);
        graphics.DrawLine(new Pen(Color.White, 30f), new Point(center.Item1, center.Item2), 
            new Point(arrowCoords.Item1, arrowCoords.Item2));

        arrowCoords = HCurrentCoords(h % 12, m, hourArrow, center.Item1, center.Item2);
        graphics.DrawLine(new Pen(Color.White, 30f), new Point(center.Item1, center.Item2), 
            new Point(arrowCoords.Item1, arrowCoords.Item2));

        // Рисуем стрелки
        graphics.DrawLine(new Pen(Color.Gray, 4f), new Point(center.Item1, center.Item2), 
            new Point(arrowCoords.Item1, arrowCoords.Item2));

        arrowCoords = SecMinCurrentCoords(m, minuteArrow, center.Item1, center.Item2);
        graphics.DrawLine(new Pen(Color.Black, 3f), new Point(center.Item1, center.Item2),
            new Point(arrowCoords.Item1, arrowCoords.Item2));

        arrowCoords = SecMinCurrentCoords(s, secondArrow, center.Item1, center.Item2);
        graphics.DrawLine(new Pen(Color.DarkOrange, 2f), new Point(center.Item1, center.Item2), 
            new Point(arrowCoords.Item1, arrowCoords.Item2));
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        timer1.Tick += new EventHandler(this.timer1_Tick);
        timer1.Start();
    }
}
