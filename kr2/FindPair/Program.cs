namespace FindPair;

/// <summary>
/// “ут определ€етс€ размер пол€ и количество кнопок
/// </summary>
public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        if (args.Length == 1 && int.TryParse(args[0], out int size))
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(size));
        }
    }
}
