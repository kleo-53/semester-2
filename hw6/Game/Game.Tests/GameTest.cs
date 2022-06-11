using NUnit.Framework;
using System;
using System.IO;

namespace Game.Tests;

public class Tests
{
    [Test]
    public void OnLeftEventWorksCorrectlyWithoutWallsTest()
    {
        string[] map = { "*******",
                         "*     *",
                         "       ",
                         "       ",
                         "* @   *",
                         "*******" };
        var writer = new StreamWriter(File.Open("../../../mapTest.txt", FileMode.Open));
        for (int i = 0; i < map.Length; i++)
        {
            writer.WriteLine(map[i]);
        }
        var game = new GameProcess();
        writer.Close();

        game.GenerateMap("../../../mapTest.txt");
        var character = game.Character;

        game.OnLeft(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1 - 1, character.Item2), game.Character);
        game.OnLeft(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1 - 1, character.Item2), game.Character);
    }

    [Test]
    public void OnRightEventWorksCorrectlyWithoutWallsTest()
    {
        string[] map = { "*******", 
            "*     *", 
            "       ", 
            "       ", 
            "    @ *", 
            "*******" };
        var writer = new StreamWriter(File.Open("../../../mapTest.txt", FileMode.Open));
        for (int i = 0; i < map.Length; i++)
        {
            writer.WriteLine(map[i]);
        }
        var game = new GameProcess();
        writer.Close();

        game.GenerateMap("../../../mapTest.txt");
        var character = game.Character;

        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1 + 1, character.Item2), game.Character);
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1 + 1, character.Item2), game.Character);
    }

    [Test]
    public void OnUpEventWorksCorrectlyWithoutWallsTest()
    {
        string[] map = { "*******", 
            "*     *", 
            "     @ ", 
            "       ", 
            "       ", 
            "*******" };
        var writer = new StreamWriter(File.Open("../../../mapTest.txt", FileMode.Open));
        for (int i = 0; i < map.Length; i++)
        {
            writer.WriteLine(map[i]);
        }
        var game = new GameProcess();
        writer.Close();

        game.GenerateMap("../../../mapTest.txt");
        var character = game.Character;

        game.OnUp(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1, character.Item2 - 1), game.Character);
        game.OnUp(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1, character.Item2 - 1), game.Character);
    }

    [Test]
    public void OnDownEventWorksCorrectlyWithWallsTest()
    {
        string[] map = { "*******", 
            "*     *", 
            "       ", 
            "     @ ", 
            "       ", 
            "*******" };
        var writer = new StreamWriter(File.Open("../../../mapTest.txt", FileMode.Open));
        for (int i = 0; i < map.Length; i++)
        {
            writer.WriteLine(map[i]);
        }
        var game = new Game.GameProcess();
        writer.Close();

        game.GenerateMap("../../../mapTest.txt");
        var character = game.Character;

        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1, character.Item2 + 1), game.Character);
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((character.Item1, character.Item2 + 1), game.Character);
    }

    [Test]
    public void TwoCharactersMakeExceptionTest()
    {
        string[] map = { "*******", 
            "*     *", 
            "  @    ", 
            "       ", 
            "     @ ", 
            "*******" };
        var writer = new StreamWriter(File.Open("../../../mapTest.txt", FileMode.Open));
        for (int i = 0; i < map.Length; i++)
        {
            writer.WriteLine(map[i]);
        }
        var game = new Game.GameProcess();
        writer.Close();
        Assert.Throws<ArgumentOutOfRangeException>(() => game.GenerateMap("../../../mapTest.txt"));
    }

    [Test]
    public void ExtraSymbolsInMapMakeExceptionTest()
    {
        string[] map = { "***gfh***", 
            "*   h  *", 
            "  @    ", 
            "       ", 
            "  67   @ ", 
            "*--****" };
        var writer = new StreamWriter(File.Open("../../../mapTest.txt", FileMode.Open));
        for (int i = 0; i < map.Length; i++)
        {
            writer.WriteLine(map[i]);
        }
        var game = new Game.GameProcess();
        writer.Close();
        Assert.Throws<InvalidDataException>(() => game.GenerateMap("../../../mapTest.txt"));
    }
}
