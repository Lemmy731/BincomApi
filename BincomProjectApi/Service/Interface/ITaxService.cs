namespace BincomProjectApi.Service.Interface
{
    public interface ITaxService
    {
        Decimal Calculatetax(decimal income, decimal rent);
    }
}
