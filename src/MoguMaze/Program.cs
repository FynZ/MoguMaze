using System;
using System.Threading;
using System.Threading.Tasks;
using MoguMaze.Maze;

namespace MoguMaze
{
    class Program
    {
        public static bool Play = true;

        static void Main(string[] args)
        {
            var a = new MazeBis();
            a.PrintMaze();
            Console.ReadKey();

            var t = new Thread(a.HandleInput) {IsBackground = true};
            t.Start();

            while (Play)
            {
                Console.Clear();
                //maze.Display();
                a.PrintSurrounding();
                //maze.HandleInput();
            }
        }

        static void OldImplem()
        {
            Console.WriteLine("Starting MoguMaze ==> Fun Incoming");

            var maze = new Maze.Maze(EndGame);

            var t = new Thread(maze.HandleInput) { IsBackground = true };
            t.Start();

            while (Play)
            {
                Console.Clear();
                //maze.Display();
                maze.DisplaySurrounding();
                //maze.HandleInput();
            }
        }

        static void EndGame()
        {
            Play = false;
        }
    }
}
