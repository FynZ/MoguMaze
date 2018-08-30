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
            var maze = new MazeBis();
            maze.PrintMaze();
            Console.ReadKey();

            var listener = InputHandler.GetInstance();
            maze.RegisterInputs(listener);

            var t = new Thread(listener.HandleInput) {IsBackground = true};
            t.Start();

            while (Play)
            {
                Console.Clear();
                //maze.Display();
                maze.PrintSurrounding();
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
