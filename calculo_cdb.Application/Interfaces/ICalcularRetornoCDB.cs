using calculo_cdb.Domain.Model;

namespace calculo_cdb.Application.Interfaces;

public interface ICalcularRetornoCDB
{
    Task<InvestmentResult> CalculaRetornoCDB(InvestmentData data);
}