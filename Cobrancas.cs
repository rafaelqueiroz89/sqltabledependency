using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegaBugWinService
{
    public class Cobrancas
    {
        public DateTime dt_vencimento { get; set; }
        public double valor_original { get; set; }
        public int forma_pagto { get; set; }
        public bool envio_email { get; set; }
        public bool envio_sms { get; set; }
        public int status_cobranca { get; set; }
        public int tipo_cliente { get; set; }
        public int parcelas { get; set; }
        public DateTime dt_agendado { get; set; }
        public DateTime dt_confirmacao_pagto { get; set; }
        public int tipo_cobranca { get; set; }
        public int NUMERO_RPS { get; set; }
        public int IdLoteNFSE { get; set; }
        public string url_boleto { get; set; }
        public int idposcobrancageracao { get; set; }
        public int idAssinaturaCobranca { get; set; }
        public int numero_parcela { get; set; }
        public string arquivo_retorno_baixa { get; set; }
        public double valor { get; set; }
        public bool nao_gerar_nota { get; set; }
        public int tipo_cliente_antigo { get; set; }
        public int idcliente_antigo { get; set; }
        public int numero_nfse { get; set; }
        public bool compra_um_click { get; set; }
        public int situacao_spc { get; set; }
        public bool registrada { get; set; }
        public bool spc { get; set; }
        public bool negociacao { get; set; }
        public string codigo_verificacao { get; set; }
        public int idPedido { get; set; }
        public int id_servico { get; set; }
        public int id_venda { get; set; }
        public bool parcela_pos { get; set; }
        public double valor_nota { get; set; }
        public string nsu { get; set; }
        public bool recusa_cartao_email { get; set; }
        public int id_instituicao { get; set; }
        public DateTime dt_url_boleto { get; set; }
        public double valor_estornado { get; set; }
        public DateTime dt_estorno { get; set; }

    }

}
