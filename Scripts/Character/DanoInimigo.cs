using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int vida = 5;
    public int dano;   

    void Start()
    {
        dano = PlayerPrefs.GetInt("danop");
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "bala")
        {
            vida -= dano;
            if (vida == 0)
            {
                MorteInimigo();
            }
        }
    }
     public void MorteInimigo()
    {
        vida = 0;
        Destroy(gameObject);
    }
}
