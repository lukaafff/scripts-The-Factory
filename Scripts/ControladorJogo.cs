using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJogo : MonoBehaviour
{
    //variveis de controle, variavel static para ser levada para outros scripts
    public static ControladorJogo gc;
    public int chave;
    public int celular;
    public int documento;

    
    void Start()
    {
       chave = 0;
       celular = 0;
       documento = 0;
    }

    void Awake()
    {
        //se gc nao existir
        if(gc == null)
        {
            //recebe a classe ControladorJogo
            gc = this;
        }
        //se gc for diferente da classe
        else if (gc != this)
        {
            //destrio o objeto do jogo que tem essa classe (canvas)
            Destroy(gameObject);
        }
    }
  
}
