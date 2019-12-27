using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> itens;
    public GameObject ponto;
    private Usuario usuario = new Usuario();
    public GameObject modal;

    // Start is called before the first frame update
    void Start()
    {
        //captura de pontos
        var pontosAtuais = Arquivos.CarregarArquivo<PontosSerializable>("pontosAtuais.temp");
        if (pontosAtuais != null)
        {
            var totalPontos = this.gameObject.GetComponent<Ponto>();
            totalPontos.TotalPontos.text = pontosAtuais.TotalPontos.ToString();
        }

        var personagens = new Personagens().GetPersonagensAtivos();

        var ids = Arquivos.CarregarArquivo<int[]>("personagensDesbloqueados.temp");
        if (ids != null)
        {
            foreach (var personagemId in ids)
            {
                usuario.PersonagensAdquiridos.Add(new Personagens() { Id = personagemId });
            }
        }
        for (int i = 0; i < personagens.Count; i++)
        {
            var personagem = personagens[i];

            //Possui o personagem
            if (usuario.PersonagensAdquiridos.Any(d => d.Id == personagem.Id))
            {
                var personagemAtivo = itens[i].GetComponent<Personagens>();
                personagemAtivo.ImagemColorida.gameObject.SetActive(true);
                personagemAtivo.ImagemPretoBranco.gameObject.SetActive(false);
                personagemAtivo.IsBloqueado = false;
            }
            else
            {
                var personagemAtivo = itens[i].GetComponent<Personagens>();
                personagemAtivo.ImagemColorida.gameObject.SetActive(false);
                personagemAtivo.ImagemPretoBranco.gameObject.SetActive(true);
                personagemAtivo.IsBloqueado = true;
            }
        }
    }

    public void AbrirPersonagem(Personagens personagem)
    {
        var personagemSelecionado = personagem.GetComponent<Personagens>();

        //Se o personagem estiver bloqueado ele deve direcionar para a tela de Doação.
        if (personagemSelecionado.IsBloqueado)
        {
            var pontosAtuais = Arquivos.CarregarArquivo<PontosSerializable>("pontosAtuais.temp");
            if (pontosAtuais != null && pontosAtuais.TotalPontos >= personagemSelecionado.PontosNecessarios)
            {
                int[] ids;
                List<int> ids2 = new List<int>();
                try
                {
                    ids = Arquivos.CarregarArquivo<int[]>("personagensDesbloqueados.temp");
                    if (ids != null)
                    {
                        foreach (var item in ids)
                        {
                            if (item == 0)
                                continue;
                            ids2.Add(item);
                        }
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }
                personagemSelecionado.IsBloqueado = false;
                pontosAtuais.TotalPontos = pontosAtuais.TotalPontos - personagemSelecionado.PontosNecessarios;
                ids2.Add(personagemSelecionado.Id);
                Arquivos.SalvarArquivo(ids2.ToArray(), "personagensDesbloqueados.temp");
                Arquivos.SalvarArquivo(pontosAtuais, "pontosAtuais.temp");

                Abrir(personagemSelecionado);
            }
            else
            {
                SceneManager.LoadScene("Doar");
            }
            return;
        }
        else
        {
            Abrir(personagem);
        }
    }

    private static void Abrir(Personagens personagem)
    {
        switch (personagem.Id)
        {
            case 1:
                SceneManager.LoadScene("BonecoDeNeve");
                break;
            case 4:
                SceneManager.LoadScene("CaixaPresente");
                break;
            case 5:
                SceneManager.LoadScene("Arvore");
                break;
            default:
                SceneManager.LoadScene("Personagens");
                break;
        }
    }

    public void DoarNovoValor()
    {
        SceneManager.LoadScene("Cartao");
    }

    public void EfetuarDoacao(Doacao doacao)
    {
        var doacaoSelecionada = doacao.GetComponent<Doacao>();
        DoacaoSerializable aaa = new DoacaoSerializable();
        aaa.Id = doacaoSelecionada.Id;
        aaa.Reais = doacaoSelecionada.Reais;

        if (doacaoSelecionada.Reais > 0)
        {
            Arquivos.SalvarArquivo(aaa, "doacao.temp");
            SceneManager.LoadScene("Cartao");
        }
        else
            modal.gameObject.SetActive(true);
    }

    

    public void AbrirCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    //Update is called once per frame
    void Update()
    {
        var pontosAtuais = Arquivos.CarregarArquivo<PontosSerializable>("pontosAtuais.temp");
        if (pontosAtuais != null)
        {
            var totalPontos = this.gameObject.GetComponent<Ponto>();
            totalPontos.TotalPontos.text = pontosAtuais.TotalPontos.ToString();
        }
    }
}
