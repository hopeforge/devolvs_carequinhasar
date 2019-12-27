using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Doacao : MonoBehaviour
    {
        public int Id;
        //Ponto é definido na proporcao de R$5,00 para 1 Ponto.
        public int Pontos
        {
            get
            {
                return Convert.ToInt32(Math.Floor(Reais / 5));
            }
        }
        public double Reais;
    }
}
