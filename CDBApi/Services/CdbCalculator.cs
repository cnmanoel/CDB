using System;

namespace CDBApi.Services
{
    public class CdbCalculator : ICdbCalculator
    {
        private const decimal CDI = 0.009m;
        private const decimal TB = 1.08m;

        public decimal CalculateGrossValue(decimal initialValue, int months)
        {
            decimal finalValue = initialValue;

            for (int i = 0; i < months; i++)
            {
                finalValue = Math.Round(finalValue * (1 + (CDI * TB)), 2, MidpointRounding.AwayFromZero);
                Console.WriteLine($"Mês {i + 1}: {finalValue}");
            }

            return finalValue;
        }

        public decimal CalculateNetValue(decimal grossValue, decimal initialValue, int months)
        {
            decimal profit = Math.Round(grossValue - initialValue, 2, MidpointRounding.AwayFromZero);

            decimal taxRate = GetTaxRate(months);
            decimal tax = Math.Round(profit * taxRate, 2, MidpointRounding.AwayFromZero);

            return Math.Round(grossValue - tax, 2, MidpointRounding.AwayFromZero);
        }

        private decimal GetTaxRate(int months)
        {
            if (months <= 6) return 0.225m;      // 22.5%
            if (months <= 12) return 0.20m;      // 20%
            if (months <= 24) return 0.175m;     // 17.5%
            return 0.15m;                        // 15%
        }
    }
}