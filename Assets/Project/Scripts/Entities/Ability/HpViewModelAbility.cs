using System;

namespace SlimeRPG
{
    public class HpViewModelAbility : CommonViewModelAbility
    {
        public event Action<float> OnAddingToTotal;

        protected override void Upgrade()
        {
            OnAddingToTotal?.Invoke(AddingToValueAfterUpgade);
            base.Upgrade();
        }
    }
}
