using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransiçãoInicio : MonoBehaviour
{
    public GameObject Transicao;
    

    void Start()
    {
        Transicao.SetActive(true);
        
    }

    void Update()
    {
        Desativar();
    }

    void Desativar()
    {
        Destroy(Transicao,  2.0f);
       
    }
}
