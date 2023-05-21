using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour
{
    //ausio do dailogo 
    public AudioSource audioSourceDialogo;
    
    //matriz para armazernar os dialogos
    public string[] dialogoNPC;
    public int dialogoIndex;


     //painel de dialogo
    public GameObject dialogoPainel;
    public Text dialogoTexto;
    private bool EstaMostrando;

    //verificadores para ativar e desativar a couroutine
    public bool ieNumeratorAtiva;
    public bool pararIENumerator;

    [SerializeField] private string Cena;

    
    void Start()
    {
        dialogoPainel.SetActive(true);
        DialogoPronto();
        pararIENumerator = false;

    }
    void Update()
    {
        
    }
   
     public void DialogoPronto()
    {
        
        IniciarDialogo();
          
        
    }

    public void ProximoDialogo()
    {
        //verifica se a ie numerator esta ativa
        if(ieNumeratorAtiva == true)
        {
            //para aa rotina ie numerator e chama a frase completa
            pararIENumerator = true;
            ieNumeratorAtiva = false;
            FraseCompleta();
        }
        //caso a ienumerator ja tenha acabado.
        else
        {
            //pegar indice do dialogo atual e somar +1
            dialogoIndex ++;
            

            //se o indice do dialogo for menor que o total de itens da matriz
            if(dialogoIndex < dialogoNPC.Length)
            {
                //exibir proximo dialogo
                pararIENumerator = false;
                StartCoroutine(MostrarDialogo());
                
            }
            else
            {
                ProximaFase();
            }
        }
       
    }

    public void IniciarDialogo()
    {
        
        
        //pegar elemento 0 da matriz de dialogo
        dialogoIndex = 0;
        //ativar painel dialogo
        
        StartCoroutine(MostrarDialogo());
        
       
    }

    //corrotina para mostrar dialogo
    IEnumerator MostrarDialogo()
    {
        //marcando ie numerator como ativa 
        ieNumeratorAtiva = true;
        dialogoTexto.text = "";
        //loop para mostrar os dialogos
        foreach (char letter in dialogoNPC[dialogoIndex])
        {   
            //verificando se existe comando para parar a rotina
            if(pararIENumerator == false)
            {
                dialogoTexto.text += letter;
                audioSourceDialogo.Play();
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                ieNumeratorAtiva = false;
                yield break;
            }
        }
        
    }
    public void ProximaFase()
   
    {
        SceneManager.LoadScene(Cena);
        
    }

    public void ProximaCena()
    {
        ProximoDialogo();
    }

        public void FraseCompleta()
    {
        dialogoTexto.text = dialogoNPC[dialogoIndex];
    }
    
    
}
