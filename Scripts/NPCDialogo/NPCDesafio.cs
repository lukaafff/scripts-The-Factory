using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDesafio : MonoBehaviour
{
    //audio do dialogo  //
    public AudioSource audioSourceDialogo;

    //matriz para armazernar os dialogos
    public string[] dialogoNPC;
    public int dialogoIndex;

    public GameObject btnAceitarDesafio;


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
        btnAceitarDesafio.SetActive(false);
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
        //verifica se a rotina ie numerator esta ativa
        if(ieNumeratorAtiva ==true)
        {
            //para a rotina ie numerator e chama a frase completa
            pararIENumerator = true;
            ieNumeratorAtiva = false;
            FraseCompleta();
        }
        //caso a ienumerator ja tenha acabado, verifica se tem proxima frase e chama ela letra por letra
        else
        {
            //pegar indice do dialogo atual e somar +1
            dialogoIndex ++;
            
            //se o indice do dialogo for menor que o total de itens da matriz
            if(dialogoIndex < dialogoNPC.Length)
            {
                //exibir proximo dialogo letra por letra
                pararIENumerator = false;
                StartCoroutine(MostrarDialogo());
            }
            else
            {
                btnAceitarDesafio.SetActive(true);
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
        //marcando a rotina ienumertaor como ativa
        ieNumeratorAtiva = true;
        dialogoTexto.text = "";
        //loop para mostrar os dialogos
        foreach (char letter in dialogoNPC[dialogoIndex])
        {
            //verificando se existe comando de parar a rotina ienumerator
            if (pararIENumerator == false)
            {
                dialogoTexto.text += letter;
                audioSourceDialogo.Play ();
                yield return new WaitForSeconds(0.05f);         
            }
            else
            {
                ieNumeratorAtiva = false;
                yield break;
            }
        //ieNumeratorAtiva = false;
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
