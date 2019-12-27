using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class CartaoCredito :MonoBehaviour
    {
        public void FinalizarDoacao(Ponto pontosAtuais)
        {
            var doacaoSelecionada = Arquivos.CarregarArquivo<DoacaoSerializable>("doacao.temp");

            var totalPontos = pontosAtuais.GetComponent<Ponto>();
            PontosSerializable pontos = new PontosSerializable();
            pontos.TotalPontos = Convert.ToInt32(totalPontos.TotalPontos.text);
            pontos.TotalPontos = (pontos.TotalPontos + doacaoSelecionada.Pontos);

            Arquivos.SalvarArquivo(pontos,"pontosAtuais.temp");

            SceneManager.LoadScene("Personagens");
        }
    }
}
