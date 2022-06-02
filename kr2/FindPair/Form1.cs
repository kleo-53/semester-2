namespace FindPair;

using System.Windows.Forms;

/// <summary>
/// Собственно, форма
/// </summary>
public partial class Form1 : Form
{
    private int size;
    private MyTable table;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="size"></param>
    public Form1(int size)
    {
        table = new MyTable(size);
        this.size = size;
        InitializeButtons();
        InitializeComponent(size);
    }

    /// <summary>
    /// Делаем кнопки
    /// </summary>
    public void InitializeButtons()
    {
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                Controls.Add(table.buttonArray[i, j]);
                table.buttonArray[i, j].MouseClick += new MouseEventHandler(S_MouseClick!);
            }
        }
    }

    private void S_MouseClick(object sender, MouseEventArgs e)
    {
        var button = (Button)sender;
        table.Click(button.Tag.ToString()!);
        if (table.IsUserWin())
        {
            MessageBox.Show("Congratulations! You win!");
        }
    }
}
