using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class documento : MonoBehaviour
{
    [SerializeField] private string nomeProximaFase;
    private ControladorJogo gcPlayer;
    public GameObject Icon;
   
    
   
    void Start()
        {
            //trazendo as variaves do script "ControladorJogo" com os valores necessários para a lógica desse script, como a chave que também foi levada para o script de player.
            gcPlayer = ControladorJogo.gc;
            gcPlayer.documento = 0;
            //sistema de controle do icone da chave, que só aparece quando ela é coletada
            Icon.SetActive(false);
            
          
            
        } 
    void Update()

        {
          AtivarDocumento();  
        }

    //verificação da chave no inventário, no qual só possibilita o player de passar a fase quando estiver com o dado "1" da chave.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( gcPlayer.documento == 3 && collision.gameObject.tag == "Player")
            {
                IrProximaFase();
            }
     
    }
    //sistema de passar fase de fase e desativação do icone e do valor da chave.
    private void IrProximaFase()
        {
            SceneManager.LoadScene(this.nomeProximaFase);
            Icon.SetActive(false);
            
            gcPlayer.documento = 0;

        }

    //metodo de ativação da chave na tela
    private void AtivarDocumento()
    {
        
        if(Icon.activeInHierarchy == false && gcPlayer.documento == 1)
            {
                Icon.SetActive(true);
                
            }
    }

    
}
