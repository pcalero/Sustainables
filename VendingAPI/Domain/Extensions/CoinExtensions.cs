using System.Collections.Generic;
using System.Linq;
using VendingAPI.Domain.ApiModels;

namespace VendingAPI.Domain.Extensions
{
    public static class CoinExtensions
    {
        public static List<CoinApiModel> CalculateBestCoinBack(List<CoinApiModel> coins, int change)
        {

            List<CoinApiModel>[] calculatedCoins = new List<CoinApiModel>[change + 1];

            calculatedCoins[0] = new List<CoinApiModel>();
            for (int i = 1; i <= change; i++)
            {
                calculatedCoins[i] = null;
            }

            for (int i = 1; i <= change; i++)
            {
                for (int j = 0; j < coins.Count; j++)
                {
                    if (coins[j].Value <= i)
                    {
                        int? previousCoins = calculatedCoins[i - coins[j].Value] != null ? calculatedCoins[i - coins[j].Value].Count() : (int?)null;
                        if (previousCoins != null && (calculatedCoins[i] == null || previousCoins + 1 < calculatedCoins[i].Count()))
                        {
                            if (calculatedCoins[i] == null)
                            {
                                calculatedCoins[i] = new List<CoinApiModel>();
                            }
                            AddOneCoinToPosition(calculatedCoins[i], new CoinApiModel() { Id = coins[j].Id, Value = coins[j].Value, Quantity = 1 });
                            calculatedCoins[i - coins[j].Value].ForEach(c => {
                                AddOneCoinToPosition(calculatedCoins[i], c);
                            });
                        }
                    }
                }
            }

            return calculatedCoins[change];
        }

        private static void AddOneCoinToPosition(List<CoinApiModel> position, CoinApiModel coin) {
            var foundCoin = position.Find(fc => fc.Id == coin.Id);
            if (foundCoin != null)
            {
                foundCoin.Quantity++;
            }
            else
            {
                position.Add(coin);
            }
        }

    }
}
