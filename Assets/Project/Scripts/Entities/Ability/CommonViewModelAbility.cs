namespace SlimeRPG
{
    public class CommonViewModelAbility : BaseViewModelAbility
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
