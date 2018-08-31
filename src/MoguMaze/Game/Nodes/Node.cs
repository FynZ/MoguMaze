using System;
using System.Collections.Generic;
using System.Text;

namespace MoguMaze.Game.Nodes
{
    public abstract class Node
    {
        protected char Visual { get; set; }

        public abstract TileType GetTileType();
    }
}
