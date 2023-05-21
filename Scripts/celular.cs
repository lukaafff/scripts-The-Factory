using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class celular : MonoBehaviour
{   
   
    private ControladorJogo gcPlayer;
    public GameObject IconC;
    public GameObject TelaCelular;
    public bool celularAtivo;
    private PlayerMovement2D Player;
    
    void Start()
        {
            //trazendo as variaves do script "ControladorJogo" com os valores necessários para a lógica desse script, como a chave que também foi levada para o script de player.
            gcPlayer = ControladorJogo.gc;
            gcPlayer.celular = 0;
            
            //sistema de controle do icone da celular, que só aparece quando ela é coletado
            if(celularAtivo == false)
            {
                IconC.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                IconC.SetActive(true);
            }
            
        }
    void Update()
        {
          AtivarCelular();  
        }
        
    //metodo de ativação da celular na tela
    private void AtivarCelular()
    {
        if(IconC.activeInHierarchy == false && gcPlayer.celular == 1)
            {
                IconC.SetActive(true);
            }
    }

    public void MostrarCelular()
    {
       if(TelaCelular.gameObject.activeSelf)
        {
            TelaCelular.gameObject.SetActive(false);
            
        }
        else
        {
            TelaCelular.gameObject.SetActive(true); 
            

        }
    }
}
