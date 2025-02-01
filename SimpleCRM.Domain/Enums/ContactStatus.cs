using System.ComponentModel;

namespace SimpleCRM.Domain.Enums {
    public enum ContactStatus {
        [Description("Pré-Venda Realizada")]
        PreVendaRealizada = 1,

        [Description("Interesse Futuro")]
        InteresseFuturo = 2,

        [Description("Sem Interesse")]
        SemInteresse = 3,

        [Description("Não Atendeu")]
        NaoAtendeu = 4,

        [Description("Telefone Errado")]
        TelefoneErrado = 5
    }
}
