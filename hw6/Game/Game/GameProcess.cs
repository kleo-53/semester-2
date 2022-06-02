namespace Game;

using System;

/// <summary>
/// Весь процесс игры
/// </summary>
public class GameProcess
{
    /// <summary>
    /// Игровое поле
    /// </summary>
    private bool[][] walls;

    /// <summary>
    /// Координаты персонажа
    /// </summary>
    private (int, int) character;
    private int wallsSize = 10;

    /// <summary>
    /// Конструктор игры
    /// </summary>
    public GameProcess()
    {
        walls = new bool[wallsSize][];
        character = (-1, -1);
        for (int i = 0; i < wallsSize; i++)
        {
            walls[i] = new bool[wallsSize];
        }
    }

    /// <summary>
    /// Переопределение размеров поля
    /// </summary>
    /// <param name="givenSize">Новый размер поля</param>
    public void ResizeMap(int givenSize)
    {
        var newWalls = new bool[givenSize][];
        for (int i = 0; i < givenSize; i++)
        {
            newWalls[i] = new bool[givenSize];
        }
        for (int i = 0; i < wallsSize; ++i)
        {
            for (int j = 0; j < wallsSize; ++j)
            {
                newWalls[i][j] = walls[i][j];
            }
        }
        walls = newWalls;
        wallsSize = givenSize;
    }

    /// <summary>
    /// Генерация карты
    /// </summary>
    /// <param name="path">Путь к файлу с картой</param>
    /// <exception cref="ArgumentOutOfRangeException">Ошибка в случае добавления двух персонажей</exception>
    /// <exception cref="InvalidDataException">Ошибка в случае неизвестных символов</exception>
    public void GenerateMap(string path)
    {
        using var map = new StreamReader(path);
        int linesSize = Console.CursorTop;
        while (true)
        {
            var line = map.ReadLine();
            if (line == null)
            {
                break;
            }

            if (line.Length >= wallsSize || linesSize >= wallsSize)
            {
                ResizeMap(Math.Max(line.Length, wallsSize));
            }

            for (int j = Console.CursorLeft; j < line.Length; j++)
            {
                walls[linesSize][j] = (line[j] == '*');
                if (line[j] == '@')
                {
                    if (character.Item1 == -1 && character.Item2 == -1)
                    {
                        character = (j, linesSize);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("На карте уже есть один персонаж!");
                    }
                }
                else if (line[j] != ' ' && line[j] != '\n' && line[j] != '*')
                {
                    throw new InvalidDataException("Такой символ не используется в игре!");
                }
            }
            ++linesSize;
            Console.WriteLine(line);
        }
        map.Close();
        Console.SetCursorPosition(character.Item1, character.Item2);
    }

    private void SetCharacter(int directionLR, int directionUD)
    {
        Console.Write(" ");
        if (!СorrectCoords(character.Item1 + directionLR, character.Item2 + directionUD) ||
            walls[character.Item2][character.Item1 + 1] || 
            Math.Abs(directionLR) + Math.Abs(directionUD) == 1)
        {
            return;
        }
        character = (character.Item1 + directionLR, character.Item2 + directionUD);
        Console.SetCursorPosition(character.Item1, character.Item2);
        Console.Write("@");
        Console.SetCursorPosition(character.Item1, character.Item2);
    }

    private bool СorrectCoords(int x, int y)
    {
        return (x >= 0) && (y >= 0) && (x < wallsSize) && (y < wallsSize);
    }

    /// <summary>
    /// Перестановка персонажа при нажатии на левую стрелку
    /// </summary>
    public void OnLeft(object? sender, EventArgs args)
        => SetCharacter(-1, 0);

    /// <summary>
    /// Перестановка персонажа при нажатии на правую стрелку
    /// </summary>
    public void OnRight(object? sender, EventArgs args)
    {
        SetCharacter(1, 0);
    }

    /// <summary>
    /// Перестановка персонажа при нажатии на верхнюю стрелку
    /// </summary>
    public void OnUp(object? sender, EventArgs args)
    {
        SetCharacter(0, -1);
    }

    /// <summary>
    /// Перестановка персонажа при нажатии на нижнюю стрелку
    /// </summary>
    public void OnDown(object? sender, EventArgs args)
    {
        SetCharacter(0, 1);
    }
}
