namespace SlimeRPG
{
    public class AspdViewModelAbility : BaseViewModelAbility
    {
        public override void Upgrade()
        {
            Value += AddingToValueAfterUpgade;
            PurchasePrice += UpgradePriceToPrice;
            Level++;

            base.Upgrade();
        }
    }
}
