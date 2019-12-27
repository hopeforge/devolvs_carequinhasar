using System;
using System.Collections.Generic;

[Serializable]
public class Usuario
{
    public Usuario()
    {
        PersonagensAdquiridos = new List<Personagens>();
    }
    public string Id { get; set; }
    public string Nome { get; set; }
    public Ponto Pontos { get; set; }
    public List<Personagens> PersonagensAdquiridos { get; set; }
}
