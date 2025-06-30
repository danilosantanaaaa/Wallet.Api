using System.Text.Json.Serialization;

namespace Wallet.Contracts.Cobrancas.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CobrancaStatus
{
    Pendente = 0,
    Finalizada = 1,
    Pago = 2,
    Vencida = 3,
    Cancelado = 4
}