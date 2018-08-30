using System;
using System.Collections.Generic;
using System.Text;

namespace MoguMaze
{
    public enum Move
    {
        MoveUp = 0,
        MoveLeft = 1,
        MoveDown = 2,
        MoveRight = 3
    }

    public class InputHandler
    {
        private static InputHandler _instance;

        private readonly Dictionary<ConsoleKey, List<Action>> _listeners = new Dictionary<ConsoleKey, List<Action>>();

        protected InputHandler()
        {
        }

        public static InputHandler GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = new InputHandler();

            return _instance;
        }

        public void Register(Action target, ConsoleKey input)
        {
            if (_listeners.TryGetValue(input, out var listeners))
            {
                listeners.Add(target);
            }
            else
            {
                _listeners.Add(input, new List<Action>{target});
            }
        }

        public void HandleInput()
        {
            while (true)
            {
                var key = Console.ReadKey();

                DispatchInput(key.Key);
            }
        }

        private void DispatchInput(ConsoleKey input)
        {
            if (_listeners.TryGetValue(input, out var listeners))
            {
                listeners.ForEach(e => e.Invoke());
            }
        }
    }
}
