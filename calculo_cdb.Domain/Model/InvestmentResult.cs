namespace calculo_cdb.Domain.Model;

public class InvestmentResult
{
    public decimal ValorBruto { get; }
    public decimal ValorLiquido { get; }

    public InvestmentResult(decimal valorBruto, decimal valorLiquido)
    {
        ValorBruto = valorBruto;
        ValorLiquido = valorLiquido;
    }
}