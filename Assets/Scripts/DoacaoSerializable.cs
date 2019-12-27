using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class DoacaoSerializable
    {
        public int Id { get; set; }
        public double Reais { get; set; }

        public int Pontos
        {
            get
            {
                return Convert.ToInt32(Math.Floor(Reais / 5));
            }
        }
    }
}
