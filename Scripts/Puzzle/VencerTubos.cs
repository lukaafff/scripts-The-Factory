using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VencerTubos : MonoBehaviour
{
    private int pontosGanhar;
    private int pontosAtuais;
    public GameObject lixosP;
    

    [SerializeField] private string nomeProximaFase;

    void Start()
    {
        pontosGanhar = lixosP.transform.childCount;
    }


    void Update()
    {
        if(pontosAtuais >= pontosGanhar)
        {
            //Ganhar
            //aparecer primeira camada desativada
            
            StartCoroutine(passarFase());
            
        }
    }

    public void AddPontos()
    {
        pontosAtuais++;
    }

    private void IrProximaFase()
    {
        SceneManager.LoadScene(nomeProximaFase);
     
    }

    IEnumerator passarFase()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        IrProximaFase();

    }

}
