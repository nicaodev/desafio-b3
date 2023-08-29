namespace calculo_cdb.Domain.Model;

public class InvestmentData
{
    public decimal InitialValue { get; set; }
    public int Months { get; }

    public InvestmentData(decimal initialValue, int months)
    {
        //if (initialValue <= 0 || months <= 1)
        //{
        //    throw new ArgumentException("O valor inicial deve ser positivo e o prazo em meses deve ser maior que 1.");
        //}

        InitialValue = initialValue;
        Months = months;
    }
}