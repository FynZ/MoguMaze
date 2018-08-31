namespace MoguMaze.Game.Nodes
{
    public interface IWalkable
    {
        void SetPlayer(Position player);
        void RemovePlayer();
    }
}