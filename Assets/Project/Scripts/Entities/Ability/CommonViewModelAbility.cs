namespace SlimeRPG
{
    public class CommonViewModelAbility : BaseViewModelAbility
    {
        protected override void Upgrade()
        {
            Value += AddingToValueAfterUpgade;
            PurchasePrice += UpgradePriceToPrice;
            Level++;

            base.Upgrade();
        }
    }
}
