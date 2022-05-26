namespace FindPair;

using System;
using System.Windows.Forms;
using System.Collections.Generic;

/// <summary>
/// Класс таблицы с кнопками и значениями
/// </summary>
public class MyTable
{
    private readonly int size;
    private bool IsFirstButtonChosen = false;
    private Button ? firstButton;
    private Button? secondButton;
    private int firstButtonValue;
    private int secondButtonValue;

    /// <summary>
    /// Массив с кнопками
    /// </summary>
    public Button[,] buttonArray;

    /// <summary>
    /// Массив со значениями кнопок
    /// </summary>
    public int[,] valueArray;
     
    /// <summary>
    /// Перемешиваем значения с помощью рандома
    /// </summary>
    public static void Shuffle(int size, Button[,] buttonArray, int[,] valueArray)
    {
        var shuffleList = new List<int>();
        for (int i = 0; i < size * size / 2; ++i)
        {
            shuffleList.Add(i);
            shuffleList.Add(i);
        }
        var rand = new Random();
        int n = shuffleList.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            var value = shuffleList[k];
            shuffleList[k] = shuffleList[n];
            shuffleList[n] = value;
        }
        var current = 0;
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                buttonArray[i, j] = new Button();
                buttonArray[i, j].Location = new Point(i * 40, j * 40);
                buttonArray[i, j].Size = new Size(40, 40);
                buttonArray[i, j].Tag = (i, j);

                valueArray[i, j] = shuffleList[current];
                current++;
            }
        }
    }

    /// <summary>
    /// Сама таблица
    /// </summary>
    public MyTable(int size)
    {
        if (size % 2 != 0 || size <= 0)
        {
            throw new NotSupportedException("Size must be an even number!");
        }

        this.size = size;
        buttonArray = new Button[size, size];
        valueArray = new int[size, size];
        Shuffle(size, buttonArray, valueArray);
    }

    /// <summary>
    /// Функция нажатия на кнопку
    /// </summary>
    /// <param name="tag">Тэг, чтобы понять, на какую именно кнопку нажали</param>
    public void Click(string tag)
    {
        var a = tag.Split(", ");
        var i = Convert.ToInt32(a[0].Split('(')[1]);
        var j = Convert.ToInt32(a[1].Split(')')[0]);
        switch (IsFirstButtonChosen)
        {
            case false:
                {
                    if (firstButton != null && secondButton != null && firstButtonValue != secondButtonValue)
                    {
                        firstButton.Text = string.Empty;
                        secondButton.Text = string.Empty;
                    }
                    firstButton = buttonArray[i, j];
                    firstButtonValue = valueArray[i, j];
                    firstButton.Text = valueArray[i, j].ToString();
                    IsFirstButtonChosen = true;
                    break;
                }
            case true:
                {
                    secondButton = buttonArray[i, j];
                    secondButtonValue = valueArray[i, j];
                    secondButton.Text = valueArray[i, j].ToString();

                    if (secondButton == firstButton)
                    {
                        break;
                    }
                    if (firstButton != secondButton && firstButtonValue == secondButtonValue)
                    {
                        firstButton.Enabled = false;
                        secondButton.Enabled = false;
                    }
                    IsFirstButtonChosen = false;
                    break;
                }
        }
    }

    /// <summary>
    /// Проверка на то, выиглал ли пользователь
    /// </summary>
    public bool IsUserWin()
    {
        foreach (var button in buttonArray)
        {
            if (button.Enabled)
            {
                return false;
            }
        }
        return true;
    }
}
