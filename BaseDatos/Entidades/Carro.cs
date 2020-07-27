using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Entidades
{
   public class Carro
    {
        public int IDCARRO { set; get; }
        public string MARCA { set; get; }
        public string MODELO { set; get; }
        public string PAIS { set; get; }
        public decimal COSTO { set; get; }
    }
}
