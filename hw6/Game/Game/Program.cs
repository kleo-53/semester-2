using System;

namespace Game;

class Program
{
    public static void Main(string[] args)
    {
        var game = new Game.GameProcess();
        game.GenerateMap("C:/Users/Star/source/repos/semester-2/hw6/Game/Game/map.txt");

        var eventLoop = new EventLoop();
        eventLoop.LeftHandler += game.OnLeft;
        eventLoop.RightHandler += game.OnRight;
        eventLoop.UpHandler += game.OnUp;
        eventLoop.DownHandler += game.OnDown;

        eventLoop.Run();

    }
}