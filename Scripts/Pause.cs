using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    //sistema de pause
    public GameObject MenuPause;
    public GameObject BotaoDePause;
    public GameObject MenuOpcoes;
    

    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private string nomeDoLevel;

    public GameObject TítuloSobreposicao;
    
    public GameObject Joystick;

    

    void Start()
    {
        Time.timeScale = 1;
        Joystick.gameObject.SetActive(true);
    }



    // botão que ativa o pause
    void Update ()
   {
     if (Input.GetKeyDown(KeyCode.Escape))
     {
        TelaDePause();
     }     
   }

   //sistema criado para detectar quando o jogo está pausado(quando o esc for pressionado), se for true aparece o menu de pause
    void TelaDePause()
    {
        if(MenuPause.gameObject.activeSelf)
        {
            MenuPause.gameObject.SetActive(false);
            Time.timeScale= 1;
            Joystick.gameObject.SetActive(true);
            
        }
        else
        {
            MenuPause.gameObject.SetActive(true); 
            Time.timeScale= 0;
            Joystick.gameObject.SetActive(false);
            MenuOpcoes.gameObject.SetActive(false);    
        }
    }

    //Time.timeScale para detectar quando o botão foi selecionado (tempo zera) seguido da boleana SetActive para desenvolver a ação
    public void PauseGame()
    {
        BotaoDePause.gameObject.SetActive(true); 
        Time.timeScale= 1;
        Joystick.gameObject.SetActive(false); 
        MenuOpcoes.gameObject.SetActive(false); 
    }

    public void Retorno()
    {
      if(MenuPause.gameObject.activeSelf)
        {
            MenuPause.gameObject.SetActive(false);
            Time.timeScale= 1;
            Joystick.gameObject.SetActive(true);  
        }
        else
        {
            MenuPause.gameObject.SetActive(true); 
            Time.timeScale= 0;
            Joystick.gameObject.SetActive(false);        
        }
    
    }

   
    public void RetornoMenu()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
        
    }

    public void Options()
    {
        if(MenuOpcoes.gameObject.activeSelf)
        {
            MenuOpcoes.gameObject.SetActive(false);   
        }
        else
        {
            MenuOpcoes.gameObject.SetActive(true);
            
        }
        
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(nomeDoLevel);
        PlayerPrefs.DeleteKey("vida");
        Time.timeScale = 1;
        TítuloSobreposicao.gameObject.SetActive(false);
        
        
    }
    


}

