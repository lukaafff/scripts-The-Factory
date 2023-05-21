using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DanoSistema : MonoBehaviour

{
    public SistemaVida heart;
    public PlayerMovement2D player;
    public Pause pause;
    
    
    void Start()
    {
        //If para identificar se há algum registro na chave, se não tiver a vida seguirá como vida máxima setado no sistema vida, 
        //se tiver, ele puxará as informações iniciará as seguintes fases com a vida atual.
       
        if(PlayerPrefs.HasKey("vida"))
        {
            heart.Vida = PlayerPrefs.GetInt("vida");
        }
      
    }
    void Update()
    {
        
    }
   
    

    
    //colisão para dar dano
    private void OnCollisionEnter2D(Collision2D collision)

    {
        //se o objeto em colisão estiver vinculado a tag "Player", diminuirá 1 de vida.
        if(collision.gameObject.tag == "Player" )
        {
            heart.Vida = heart.Vida-1;
            player.animationPlayer.SetTrigger("TomandoDano");

            //SAVE da vida mais o dano tomado
            PlayerPrefs.SetInt("vida", heart.Vida);
            
            if(gameObject.tag == "inimigo")
            {

                heart.Vida = heart.Vida-1;
                
                
            }

        }

            //Se o objeto em colisão além de estar vinculado a tag player estiver relacionado com alguma tag "morte", é morte instântanea
            if(gameObject.tag == "morte")
            {
                heart.Vida = 0;
                heart.EstaMorto = true; 
                
            }

            //TomandoDano = true;
            //player.animationPlayer.SetBool("TomandoDano", TomandoDano);
    }
}