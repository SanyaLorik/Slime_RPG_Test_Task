namespace SlimeRPG.State
{
    public interface IStateSwitcher
    {
        void Switch<T>(IState old) where T : IState;
    }
}
