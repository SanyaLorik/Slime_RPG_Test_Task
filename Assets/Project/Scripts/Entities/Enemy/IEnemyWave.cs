using System;

namespace SlimeRPG.Entities
{
    public interface IEnemyWave
    {
        event Action OnWaveStarted;
        event Action OnWaveEnded;
        event Action<float> OnDelayed;

        Enemy AliveEnemy { get; }
    }
}