using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MoguMaze.Game.Nodes
{
    public class Wall : Node, INode
    {
        public Wall()
        {
            Visual = '#';
        }

        public override TileType GetTileType() => TileType.Wall;

        public char Display() => Visual;

        public void Display(StringBuilder stringBuilder) => stringBuilder.Append(Visual);
    }
}
