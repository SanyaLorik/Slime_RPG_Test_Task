using SlimeRPG.Data;

namespace SlimeRPG
{
    public struct Ability
    {
        public Ability(InitialAbilityValue initialAbilityValue)
        {
            Level = initialAbilityValue.Level;
            Value = initialAbilityValue.Value;
            AddingToValueAfterUpgade = initialAbilityValue.AddingToValueAfterUpgade;
            PurchasePrice = initialAbilityValue.PurchasePrice;
            UpgradePriceToPrice = initialAbilityValue.UpgradePriceToPrice;
        }

        public int Level { get; private set; }

        public float Value { get; private set; }

        public float AddingToValueAfterUpgade { get; private set; }

        public int PurchasePrice { get; private set; }

        public int UpgradePriceToPrice { get; private set; }

        public bool CanUpgrade(Wallet wallet)
        {
            return wallet.CanWithdrawed(PurchasePrice);
        }

        public void Upgrade()
        {
            Value += AddingToValueAfterUpgade;
            PurchasePrice += UpgradePriceToPrice;
            Level++;
        }
    }
}
