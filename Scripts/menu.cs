using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    //variáveis de comando do menu, o serializeField serve para que a variável apareça no inspector, facilitando a associação do objeto.
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCreditos;
    [SerializeField] private GameObject ComoJogar;

// tela de carregamento
    [SerializeField] private GameObject BotaoJogar;
    [SerializeField] private Slider BarraProgresso;

    //audios
    

//função de tela de carregamento, ativando uma coroutine

    private void Start()
    {
        this.BotaoJogar.SetActive(true);
        this.BarraProgresso.gameObject.SetActive(false);
    }

    public void Jogar()
    {
        Time.timeScale = 1;
        this.BotaoJogar.SetActive(false);
        this.BarraProgresso.gameObject.SetActive(true);
        StartCoroutine(CarregarCena());

    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("inicio");
        while (!asyncOperation.isDone)
        {
            this.BarraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }



//SetActive para detectar quando um menu está ativo ou não, usado para abrir as opções sem que haja o menu principal no fundo.
    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
        painelCreditos.SetActive(false);

    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        painelCreditos.SetActive(false);
        ComoJogar.SetActive(false);
    }
    public void AbrirCreditos(){

        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(false);
        painelCreditos.SetActive(true);
        ComoJogar.SetActive(false);
    }
    public void FecharCreditos(){

        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        painelCreditos.SetActive(false);
        ComoJogar.SetActive(false);
    }
     public void AbrirComoJogar(){

        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(false);
        painelCreditos.SetActive(false);
        ComoJogar.SetActive(true);
    }
    public void FecharComoJogar(){

        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        painelCreditos.SetActive(false);
        ComoJogar.SetActive(false);
    }



    //Application.Quit é uma aplicação da unity que serve para forçar o encerramento do app.
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
