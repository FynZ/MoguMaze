using System;
using System.Collections.Generic;
using System.Text;

namespace MoguMaze
{
    class SoundManager
    {
        private bool playing = true;
        private Action _action;

        public void PushSound(Action action)
        {
            _action = action;
        }

        public void Play()
        {
            do
            {
                _action?.Invoke();
            } while (playing);
        }
    }
}
