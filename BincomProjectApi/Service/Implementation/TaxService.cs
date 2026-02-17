using BincomProjectApi.Model.Enum;
using BincomProjectApi.Service.Interface;

namespace BincomProjectApi.Service.Implementation
{
    public class TaxService: ITaxService
    {
        
        public decimal Calculatetax(decimal income, decimal rent)
        {
            decimal taxableIncome = 0;
            decimal relief = 0;      
            decimal tax = 0;
            if (income <= (decimal)TaxEnum.TaxFree)
            {
                return 0;
            }
            else if (income >= (decimal)TaxEnum.MiddleIncome && income < (decimal)TaxEnum.HigherIncome)
            {
                relief = rent * (20m / 100m);
                taxableIncome = (income - rent) + (rent - relief);
                tax = taxableIncome * (15m / 100m);
                return Decimal.Round(tax);
            }
            else if (income >= (decimal)TaxEnum.HigherIncome && income < (decimal)TaxEnum.WealthIncome)
            {
                relief = rent * (20m / 100m);
                taxableIncome = (income - rent) + (rent - relief);
                tax = taxableIncome * (18m / 100m);
                return Decimal.Round(tax);
            }
            else if (income <= (decimal)TaxEnum.TopIncome)
            {
                relief = rent * (20m / 100m);
                taxableIncome = (income - rent) + (rent - relief);
                tax = taxableIncome * (21m / 100m);
                return Decimal.Round(tax);
            }
            else 
            {
                relief = rent * (20m / 100m);
                taxableIncome = (income - rent) + (rent - relief);
                tax = taxableIncome * (25m / 100m);
                return Decimal.Round(tax);
            }
        }
    }
}
