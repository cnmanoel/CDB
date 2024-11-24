namespace CDBApi.Services
{
    public interface ICdbCalculator
    {
        decimal CalculateGrossValue(decimal initialValue, int months);
        decimal CalculateNetValue(decimal grossValue, decimal initialValue, int months);
    }
}