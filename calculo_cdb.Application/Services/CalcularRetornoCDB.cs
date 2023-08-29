using calculo_cdb.Application.Interfaces;
using calculo_cdb.Domain.Model;

namespace calculo_cdb.Application.Services;

public class CalcularRetornoCDB : ICalcularRetornoCDB
{
    public async Task<InvestmentResult> CalculaRetornoCDB(InvestmentData data)
    {
        ValidateInvestmentData(data);

        decimal cdiRate = 0.009m; // 0.9%
        decimal bankRate = 1.08m; // 108%
        decimal cdi = cdiRate * data.Months;

        decimal ValorBruto = data.InitialValue * (1 + cdi * bankRate);

        decimal taxRate = CalculateTaxRate(data.Months);

        decimal ValorLiquido = ValorBruto - ((ValorBruto - data.InitialValue) * taxRate);

        return new InvestmentResult(ValorBruto, ValorLiquido);
    }

    private void ValidateInvestmentData(InvestmentData data)
    {
        if (data.InitialValue <= 0 || data.Months <= 1)
        {
            throw new ArgumentException("O valor inicial deve ser positivo e o prazo em meses deve ser maior que 1.");
        }
    }

    private decimal CalculateTaxRate(int months)
    {
        if (months <= 6) return 0.225m;     // 22.5%
        if (months <= 12) return 0.20m;     // 20%
        if (months <= 24) return 0.175m;    // 17.5%
        return 0.15m;                       // 15%
    }
}