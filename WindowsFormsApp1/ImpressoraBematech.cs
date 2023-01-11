using System;
using static WindowsFormsApp1.FormatoImpressaoBematech4200;

namespace WindowsFormsApp1
{
    public static class ImpressoraBematech
    {
        //TESTE-PRECISA REALIZAR PROCEDIMENTO PARA CONFIGURAÇÃO FICAR DINAMICA
        static int ConfigurarImpressora { get { return (7); } }

        //configuração manual
        static string PortaImpressora { get { return ("USB"); } }
        static int TamanhoPapel { get { return (80); } }

        static int resultImpressora = 0;
        static int status = 0;

        public static string ConfigurarVerificarStatusImpressora()
        {
            resultImpressora = Bematech4200th.IniciaPorta(PortaImpressora);
            if (resultImpressora == 0)
                return $"Não foi possível acessar porta configurada: {PortaImpressora}";

            resultImpressora = Bematech4200th.AjustaLarguraPapel(TamanhoPapel);
            if (resultImpressora == 0)
                return $"Não foi possível configurar a largura do papel com tamanho:  {TamanhoPapel}";

            resultImpressora = Bematech4200th.SelecionaQualidadeImpressao(2);
            if (resultImpressora == 0)
                return $"Não foi possível configurar a qualidade do papel {2}";


            return StatusImpressora();
        }

        private static string StatusImpressora()
        {
            status = 0;

            status = Bematech4200th.Le_Status();

            switch (status)
            {
                case 0:
                    return "Sem comunicação com a impressora";

                case 5:
                    return "Impressoa com pouco papel";

                case 9:
                    return "Tampa da impressora aberta";
                case 32:
                    return "Impressora sem papel";

                default:
                    return status.ToString();
            }
        }


        /// <summary>
        /// Aciona a guilhotina, cortando o papel em modo parcial ou total.
        /// </summary>
        /// <param name="parcial_full">INTEIRA 0 = acionamento parcial, 1 = acionamento total.</param>
        /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
        public static string CortarPapel(int parcial_full)
        {

            var result = ConfigurarVerificarStatusImpressora();

            if (!int.TryParse(result, out int verifica))
            {
                Console.WriteLine(result);
                Console.Out.WriteLine(result);
                return result;
            }


            Bematech4200th.AcionaGuilhotina(parcial_full);

            if (parcial_full == 1)
            {
                //cortar full
                Console.WriteLine("Guilhotina acionada full");
            }
            else
                if (parcial_full == 0)
            {
                Console.WriteLine("Guilhotina acionada full");
            }

            return "ok";
        }

        public static string ImprimirTexto(string textoImprimir,
            TipoLetra tipo = TipoLetra.normal,
            Italico italico = Italico.desativa,
            Sublinhado sublinhado = Sublinhado.desativa,
            Expandido expandido = Expandido.desativa,
            Enfatizado enfatizado = Enfatizado.desativa,
            LinhaBaixoCortarPapel cortarPapel = LinhaBaixoCortarPapel.pularLinha
            )
        {
            ConfigurarVerificarStatusImpressora();
            var statusImpressora = StatusImpressora();

            //int retornoImpressao = Bematech4200th.BematechTX(textoImprimir);
            int retornoImpressao =
                Bematech4200th.FormataTX
                (textoImprimir,
                ((int)tipo),
                ((int)italico),
                ((int)sublinhado),
                ((int)expandido),
                ((int)enfatizado));

            switch (cortarPapel)
            {
                case LinhaBaixoCortarPapel.completo:
                    Bematech4200th.AcionaGuilhotina(1);
                    break;
                case LinhaBaixoCortarPapel.parcial:
                    Bematech4200th.AcionaGuilhotina(0);
                    break;
                case LinhaBaixoCortarPapel.pularLinha:
                    Bematech4200th.BematechTX("\r\n");
                    break;
                default:
                    break;
            }

            return retornoImpressao.ToString();

        }





    }
}
