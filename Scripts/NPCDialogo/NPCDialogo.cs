using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogo : MonoBehaviour
{  
    //audio do dialogo  
    public AudioSource audioSourceDialogo;

    //matriz para armazernar os dialogos
    public string[] dialogoNPC;
    public int dialogoIndex;

    //painel de dialogo
    public GameObject dialogoPainel;
    public Text dialogoTexto;

    public Text nomeNPC;
    public Image imagemNPC;
    public Sprite spriteNPC;
    public string setNomeNPC;

    public bool prontoParaFalar;
    public bool iniciarDialogo;


    public GameObject btnInteragir;

    void Start()
    {
        dialogoPainel.SetActive(false);
        btnInteragir.SetActive(false);
    }

    void Update()
    {
        DialogoPronto();
    }

    public void DialogoPronto()
    {
        //se a boleana iniciar dialogo estiver verdade e estiver pronto para falar
        if(prontoParaFalar == true && iniciarDialogo == true)
        {
            //e se o dialogo nao iniciou
            if(!iniciarDialogo)
            {
              IniciarDialogo();
            }
            //se o texto do dialogo é igual ao dialogo atual
            else if(dialogoTexto.text == dialogoNPC[dialogoIndex])
            {
                //se pressionar o botao esquerdo do mouse (FIRE1) passa para o proximo dialogo
                if(Input.GetMouseButtonDown(0))
                {
                    ProximoDialogo();
                }
                
            }
            
        }
    }

    public void ProximoDialogo()
    {
        //pegar indice do dialogo atual e somar +1
        dialogoIndex ++;

        //se o indice do dialogo for menor que o total de itens da matriz
        if(dialogoIndex < dialogoNPC.Length)
        {
            //exibir proximo dialogo
            StartCoroutine(MostrarDialogo());
        }
        else
        {
            dialogoPainel.SetActive(false);
            iniciarDialogo = false;
            dialogoIndex = 0;
        }
    }

    public void IniciarDialogo()
    {
        //atribuir nome do NPC
        nomeNPC.text = setNomeNPC;
        //atribuir imagem do NPC
        imagemNPC.sprite = spriteNPC;
        //atribuir verdadeiro para inicar dialogo
        iniciarDialogo = true;
        //pegar elemento 0 da matriz de dialogo
        dialogoIndex = 0;
        //ativar painel dialogo

       
    
        
        dialogoPainel.SetActive(true);
        StartCoroutine(MostrarDialogo());
        btnInteragir.SetActive(false);
    
    
       
    }

    //corrotina para mostrar dialogo
    IEnumerator MostrarDialogo()
    {
        dialogoTexto.text = "";
        //loop para mostrar os dialogos
        foreach (char letter in dialogoNPC[dialogoIndex])
        {
            if(iniciarDialogo == true)
                {   
                    dialogoTexto.text += letter;
                    audioSourceDialogo.Play ();
                    yield return new WaitForSeconds(0.05f);
                }
                else 
                {
                    yield break;
                }
        }                
    }

    //colidir com NPC
    private void OnTriggerEnter2D(Collider2D collision) {
        //verificar se foi o player que colidiu
        if(collision.CompareTag("Player"))
        {
            prontoParaFalar = true;
            btnInteragir.SetActive(true);
        }
       
        
    }

    //sair da colisao
    private void OnTriggerExit2D(Collider2D collision) 
    {
        //verificar se foi o player que parou de colidiu
        if(collision.CompareTag("Player"))
        {
            prontoParaFalar = false;
            btnInteragir.SetActive(false);
            iniciarDialogo = false;
            dialogoPainel.SetActive(false);
        
        }
    }

    
}