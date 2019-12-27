using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class PersonagemSerializable
    {
        public int Id { get; set; }
        public int PontosNecessarios { get; set; }
        public bool IsBloqueado { get; set; }
    }
}
