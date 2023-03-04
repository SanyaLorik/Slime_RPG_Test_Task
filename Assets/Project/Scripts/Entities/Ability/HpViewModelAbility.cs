using System;

namespace SlimeRPG
{
    public class HpViewModelAbility : BaseViewModelAbility
    {
        public event Action<float> OnAddingToTotal;

        protected override void Upgrade()
        {
            base.Upgrade();
            OnAddingToTotal?.Invoke(AddingToValueAfterUpgade);
        }
    }
}
