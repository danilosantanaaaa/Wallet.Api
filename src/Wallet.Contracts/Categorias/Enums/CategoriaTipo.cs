using System.Text.Json.Serialization;

namespace Wallet.Contracts.Categorias.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoriaTipo
{
    Entrada,
    Saida,
}