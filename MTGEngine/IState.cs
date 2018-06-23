using MTGEngine.Zones;

namespace MTGEngine
{
    public interface IState
    {
        Battlefield Battlefield( Player player );
    }
}
