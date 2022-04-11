using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game;

public class GameProcess
{
    public bool[][] Walls { get; set; }
    public (int, int) Character { get; set; }
    int wallsSize = 10;

    public GameProcess()
    {
        Walls = new bool[wallsSize][];
        Character = (-1, -1);
        for (int i = 0; i < wallsSize; i++)
        {
            Walls[i] = new bool[wallsSize];
        }
    }

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
                newWalls[i][j] = Walls[i][j];
            }
        }
        Walls = newWalls;
        wallsSize = givenSize;
    }

    public void GenerateMap(string path)
    {
        using StreamReader map = new StreamReader(path);
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
                Walls[linesSize][j] = (line[j] == '*');
                if (line[j] == '@')
                {
                    if (Character.Item1 == -1 && Character.Item2 == -1)
                    {
                        Character = (j, linesSize);
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
        Console.SetCursorPosition(Character.Item1, Character.Item2);
    }

    private void SetCharacter(char direction)
    {
        Console.Write(" ");
        switch (direction)
        {
            case 'l':
                {
                    Character = (Character.Item1 - 1, Character.Item2);
                    break;
                }
            case 'r':
                {
                    Character = (Character.Item1 + 1, Character.Item2);
                    break;
                }
            case 'u':
                {
                    Character = (Character.Item1, Character.Item2 - 1);
                    break;
                }
            case 'd':
                {
                    Character = (Character.Item1, Character.Item2 + 1);
                    break;
                }
            default:
                {
                    throw new ArgumentException();
                }

        }
        Console.SetCursorPosition(Character.Item1, Character.Item2);
        Console.Write("@");
        Console.SetCursorPosition(Character.Item1, Character.Item2);
    }

    private bool СorrectCoords(int x, int y)
    {
        return (x >= 0) && (y >= 0) && (x < wallsSize) && (y < wallsSize);
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        if (!СorrectCoords(Character.Item1 - 1, Character.Item2) || Walls[Character.Item2][Character.Item1 - 1])
        {
            return;
        }
        SetCharacter('l');
    }

    public void OnRight(object? sender, EventArgs args)
    {
        if (!СorrectCoords(Character.Item1 + 1, Character.Item2) || Walls[Character.Item2][Character.Item1 + 1])
        {
            return;
        }
        SetCharacter('r');
    }

    public void OnUp(object? sender, EventArgs args)
    {
        if (!СorrectCoords(Character.Item1, Character.Item2 - 1) || Walls[Character.Item2 - 1][Character.Item1])
        {
            return;
        }
        SetCharacter('u');
    }

    public void OnDown(object? sender, EventArgs args)
    {
        if (!СorrectCoords(Character.Item1, Character.Item2 + 1) || Walls[Character.Item2 + 1][Character.Item1])
        {
            return;
        }
        SetCharacter('d');
    }

}
