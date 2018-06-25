using MTGEngine.Zones;

namespace MTGEngine
{
    public interface IState
    {
        Player CurrentPlayer { set; }
        Battlefield Battlefield( Player player );
        Player Opponent();
        Player Me();
    }
}
