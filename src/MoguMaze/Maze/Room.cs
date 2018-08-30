using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoguMaze.Maze
{
    public class Room : Node, INode, IWalkable
    {
        public bool HasPlayer = false;

        private Position _position;

        public Room()
        {
            Visual = ' ';
        }

        public override TileType GetTileType() => TileType.Room;

        public char Display() => Visual;

        public void Display(StringBuilder stringBuilder) => stringBuilder.Append(Visual);

        public void SetPlayer(Position player)
        {
            HasPlayer = true;
            _position = player;
        }

        public void RemovePlayer()
        {
            HasPlayer = false;
            _position = null;
        }
    }
}
