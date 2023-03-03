namespace SlimeRPG.Battle
{
    public interface IDamageable<T>
    {
        void Damage(T damage);
    }
}