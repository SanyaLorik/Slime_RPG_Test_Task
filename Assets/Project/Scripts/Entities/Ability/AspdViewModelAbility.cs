namespace SlimeRPG
{
    public class AspdViewModelAbility : BaseViewModelAbility
    {
        protected override void Upgrade()
        {
            Value -= Value * AddingToValueAfterUpgade;
            PurchasePrice += UpgradePriceToPrice;
            Level++;

            base.Upgrade();
        }
    }
}
