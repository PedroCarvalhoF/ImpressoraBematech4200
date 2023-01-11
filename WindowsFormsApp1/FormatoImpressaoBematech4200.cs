using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FormatoImpressaoBematech4200
    {
        public enum TipoLetra
        {
            comprimido = 1,
            normal = 2,
            elite = 3
        }

        public enum Italico
        {
            ativa = 1,
            desativa = 0

        }
        public enum Sublinhado
        {
            ativa = 1,
            desativa = 0
        }
        public enum Expandido
        {
            ativa = 1,
            desativa = 0
        }
        public enum Enfatizado
        {
            ativa = 1,
            desativa = 0
        }

        public enum LinhaBaixoCortarPapel
        {
            completo = 1,
            parcial = 0,
            pularLinha = 3
        }
    }
}
