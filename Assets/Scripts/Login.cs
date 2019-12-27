using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField Email;
   public InputField Senha;
    public Text mensagemErro;
    private string usuarioPadrao = "graacc";
    private string senhaPadrao = "123";
    public void RealizarLogin()
    {
        if (!string.IsNullOrEmpty(Email.text) && !string.IsNullOrEmpty(Senha.text))
        {
            mensagemErro.gameObject.SetActive(false);

            if (Email.text.ToLower().Equals(usuarioPadrao) && Senha.text.Equals(senhaPadrao))
                SceneManager.LoadScene("Personagens");
        }
        else
        mensagemErro.gameObject.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
