using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagens : MonoBehaviour
{
    public int Id;
    public string Nome;
    public int PontosNecessarios;
    public Image ImagemColorida;
    public Image ImagemPretoBranco;
    public bool Ativo { get; set; }
    public bool IsBloqueado;

    void Start()
    {

    }


    public List<Personagens> GetPersonagensAtivos()
    {
        List<Personagens> personagens = new List<Personagens>();
        personagens.Add(new Personagens() { Id = 1, Nome = "Personagem 1", Ativo = true, PontosNecessarios = 1 });//R5$,00
        personagens.Add(new Personagens() { Id = 2, Nome = "Personagem 2", Ativo = true, PontosNecessarios = 2 });//R$10,00
        personagens.Add(new Personagens() { Id = 3, Nome = "Personagem 3", Ativo = true, PontosNecessarios = 3 }); //R$15,00
        personagens.Add(new Personagens() { Id = 4, Nome = "Personagem 4", Ativo = true, PontosNecessarios = 5 }); //R$25,00
        personagens.Add(new Personagens() { Id = 5, Nome = "Personagem 5", Ativo = true, PontosNecessarios = 10 });//R$50,00
        personagens.Add(new Personagens() { Id = 6, Nome = "Personagem 6", Ativo = true, PontosNecessarios = 20 });//R$100,00

        return personagens;
    }
}
