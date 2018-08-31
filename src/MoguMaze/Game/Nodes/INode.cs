using System.Text;

namespace MoguMaze.Game.Nodes
{
    public enum TileType
    {
        Wall = 0,
        Room = 1,
        UpStairs = 2,
        DownStairs = 3,
        Flame = 4,
        Brazero = 5,
        Teleporter = 6
    }

    public interface INode
    {
        char Display();
        void Display(StringBuilder stringBuilder);
    }
}