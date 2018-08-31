using System;
using System.Text;
using System.Threading;
using MoguMaze.Game.Nodes;

namespace MoguMaze.Game
{
    public class Maze
    {
        private INode[,,] _maze;

        private Position _player;

        public Maze()
        {
            _maze = new MazeGenerator(20, 20, 3).GenerateMaze(out _player);
        }

        public void PrintMaze()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(_maze[i,j,0].Display());
                }

                Console.Write(Environment.NewLine);
            }
        }

        public void PrintSurrounding()
        {
            const string pad = "     ";
            var sb = new StringBuilder();

            // Top line     ( _     /    top     / _ )
            sb.Append(pad)
                .Append(' ')
                .Append(_maze[_player.Y - 1, _player.X, _player.Z].Display())
                .Append(' ') // Can be removed
                .Append(Environment.NewLine);

            // Middle Line  ( left  /    mid    / right)
            sb.Append(pad)
                .Append(_maze[_player.Y, _player.X - 1, _player.Z].Display())
                .Append('O')
                .Append(_maze[_player.Y, _player.X + 1, _player.Z].Display())
                .Append(Environment.NewLine);

            // Bottom line  (   _  /   bottom  / _ )
            sb.Append(pad)
                .Append(' ')
                .Append(_maze[_player.Y + 1, _player.X, _player.Z].Display())
                .Append(' ') // Can be removed
                .Append(Environment.NewLine);

            Console.WriteLine(sb.ToString());

            Thread.Sleep(150);
        }

        // Move player on the Y axisis to the TOP
        public void MoveTop()
        {
            if (_maze[_player.Y - 1, _player.X, _player.Z] is IWalkable target)
            {
                _player.Y--;
                target.SetPlayer(_player);
                (_maze[_player.Y, _player.X, _player.Z] as IWalkable)?.RemovePlayer();
            }
        }

        // Move player on the X axsis to the LEFT
        public void MoveLeft()
        {
            if (_maze[_player.Y, _player.X - 1, _player.Z] is IWalkable target)
            {
                _player.X--;
                target.SetPlayer(_player);
                (_maze[_player.Y, _player.X, _player.Z] as IWalkable)?.RemovePlayer();
            }
        }

        // Move player on the Y axsis to the BOTTOM
        public void MoveBottom()
        {
            if (_maze[_player.Y + 1, _player.X, _player.Z] is IWalkable target)
            {
                _player.Y++;
                target.SetPlayer(_player);
                (_maze[_player.Y, _player.X, _player.Z] as IWalkable)?.RemovePlayer();
            }
        }

        // Move player on the X axsis to the RIGHT
        public void MoveRight()
        {
            if (_maze[_player.Y, _player.X + 1, _player.Z] is IWalkable target)
            {
                _player.X++;
                target.SetPlayer(_player);
                (_maze[_player.Y, _player.X, _player.Z] as IWalkable)?.RemovePlayer();
            }
        }

        // Move player on the Y axsis to the TOP
        public void MoveUp()
        {

        }

        // Move player on the Z axsis
        public void MoveDown()
        {

        }


        public void RegisterInputs(InputHandler handler)
        {
            handler.Register(MoveTop, ConsoleKey.UpArrow);
            handler.Register(MoveBottom, ConsoleKey.DownArrow);
            handler.Register(MoveLeft, ConsoleKey.LeftArrow);
            handler.Register(MoveRight, ConsoleKey.RightArrow);
        }

        public void HandleInput()
        {
            while (true)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveTop();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveBottom();
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight();
                        break;
                }
            }
        }
    }
}