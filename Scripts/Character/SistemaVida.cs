using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaVida : MonoBehaviour
{
    //referencias
    public static SistemaVida heart;
    public PlayerMovement2D player;
    

    public int Vida; //vida atual
    public int VidaMaxima; //vida máxima que o personagem terá
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    //morte
    public bool EstaMorto;
    public GameObject MenuMorte;

    //reiniciar
    [SerializeField] private string nomeReinicio;

    [SerializeField] private GameObject Joystick;

    
   

    
    void Start()
    {
        player = GetComponent<PlayerMovement2D>();
        MenuMorte.SetActive(false);
        Joystick.gameObject.SetActive(true);
                
    }

    void Update()
    {
        LogicaVida();
        EstadoMorte();
    }

    public void LogicaVida()
    {
        //se a vida do personagem for menor que a vida máxima, então a vida máxima será a vida atual do personagem.
       if(Vida > VidaMaxima)

       {

        Vida = VidaMaxima;

        
        
       }

        //laço para adicionar ou remover corações da tela.

        //inicia com i em zero e adicionára 1 coração ao vetor em cada laço.
        for (int i = 0; i < coracao.Length; i++)

        //se a i for menor que a vida, então essa diferença indicará com a quantidade de i em sprites cheios
        {
             if(i<Vida)
        {
            coracao[i].sprite = cheio;
           
        }
        else
        // A diferença entre i e a vida (vida atual) será representada por corações vazios
        {
            coracao[i].sprite = vazio;
        }
            //se i for maior que a vidamáxima, então ativaremos corações a mais na tela
            if(i < VidaMaxima)
            {
                coracao[i].enabled = true;
            }
            //se não, permaneceremos do jeito que está
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    //Se a vida for menor que 0, ativará a boleana setada no personagem que indicará quando ele está morto. 
    //Quando essa boleana for true, recebe o comando para destruir o objeto e chamando o metodo de reinicio ao inicio da cena atual.
    void EstadoMorte()
    {
        if(Vida <= 0 )
        {
            EstaMorto = true;
            MenuMorte.SetActive(true);
            GetComponent<PlayerMovement2D>().enabled = false;
            //Destroy(gameObject);
            Joystick.gameObject.SetActive(false);

            //Resetar a vida do SAVE quando o personagem morrer.
            PlayerPrefs.DeleteKey("vida");

           
        }
    }

    //metodo de reiniciar a tela quando o player morre.
    public void Reiniciar()
    {
        
        SceneManager.LoadScene(nomeReinicio);
        PlayerPrefs.DeleteKey("vida"); 
        Joystick.gameObject.SetActive(true);  
        
    }

    
   
}
