using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace MoguMaze.Maze
{
    [Obsolete]
    class Maze
    {
        private char[,] _maze;
        private char[] _obstacles = {'#'};

        private Position _current = new Position(8, 1);

        private System.Action _endGame;

        public Maze(System.Action endGame, int width = 20, int height = 20)
        {
            _endGame = endGame;

            _maze = new[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', '#', ' ', ' ', ' ', '#', 'O', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#'},
                {'#', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', '#', '#', '#', ' ', '#', ' ', ' ', ' ', '#'},
                {'#', 'E', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };
        }

        public void Display()
        {
            var sb = new StringBuilder();
            int width = 0;

            for (int height = 0; height < 10; height++)
            {
                while (width < 10)
                {
                    sb.Append(_maze[height, width]);
                    //Console.Write(_maze[height, width]);
                    width++;
                }

                width = 0;
                sb.Append(Environment.NewLine);
                //Console.Write(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
            Thread.Sleep(100);
        }

        public void DisplaySurrounding()
        {
            string pad = "     ";
            var sb = new StringBuilder();

            // Top line     ( _     /    top     / _ )
            sb.Append(pad).Append(' ').Append(_maze[_current.Y - 1, _current.X]).Append(Environment.NewLine);

            // Middle Line  ( left  /    mid    / right)
            sb.Append(pad).Append(_maze[_current.Y, _current.X - 1]).Append(_maze[_current.Y, _current.X])
                .Append(_maze[_current.Y, _current.X + 1]).Append(Environment.NewLine);

            // Bottom line  ( _     /   bottom  / _ )
            sb.Append(pad).Append(' ').Append(_maze[_current.Y + 1, _current.X]).Append(Environment.NewLine);

            Console.WriteLine(sb.ToString());
            Thread.Sleep(100);
        }


        public void PrintCurrentPos()
        {
            Console.WriteLine($"Current position is : {_current.X} - {_current.Y}");
        }

        public void HandleInput()
        {
            while (true)
            {
                var key = Console.ReadKey();

                var targetPosition = new Position(_current.X, _current.Y);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        targetPosition.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        targetPosition.Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        targetPosition.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        targetPosition.X++;
                        break;
                }

                if (IsValidTargetPosition(targetPosition))
                {
                    bool win = TargetIs(targetPosition, 'E');

                    _maze[_current.Y, _current.X] = ' ';    // Set old pos back to normal
                    _current = targetPosition;              // Update player pos
                    _maze[_current.Y, _current.X] = 'O';    // Set new pos to display player

                    if (win)
                    {
                        _endGame.Invoke();
                    }
                }
            }
        }

        public bool IsValidTargetPosition(Position position)
        {
            if (_obstacles.Contains(_maze[position.Y, position.X]))
            {
                return false;
            }

            return true;
        }

        public bool TargetIs(Position position, char c)
        {
            if (_maze[position.Y, position.X] == c)
            {
                return true;
            }

            return false;
        }
    }
}

