using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaBala : MonoBehaviour
{
   void Start()
    {
     
        Destroy(gameObject, 0.7f);
    }
   private void OnTriggerEnter2D(Collider2D col) 
    {
        switch (col.gameObject.tag)
        {
            case "cenario":
                Destroy(gameObject);
                break;
            case "inimigoFraco":
                Destroy(gameObject);
                break;
            case "inimigoForte":
                Destroy(gameObject);
                break;
            case "bossSeguranca":
                Destroy(gameObject);
                break;
            case "bossSecretaria":
                Destroy(gameObject);
                break;
            case "bossPrefeito":
                Destroy(gameObject);
                break;        
        }
    }
}
