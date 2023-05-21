using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleVencer : MonoBehaviour
{
    private int pontosGanhar;
    private int pontosAtuais;
    public GameObject lixosP;
    [SerializeField] private string nomeProximaFase;

    [SerializeField] private GameObject lixo;
    [SerializeField] private GameObject lixeira;
    [SerializeField] private GameObject menuInicial;
    //[SerializeField] private GameObject lixeiraGrande;




    void Start()
    {
        pontosGanhar = lixosP.transform.childCount;
        lixo.SetActive(true);
        lixeira.SetActive(true);
        menuInicial.SetActive(true);
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
        lixo.SetActive(false);
        lixeira.SetActive(false);
        menuInicial.SetActive(false);
        //lixeiraGrande.SetActive(false);

        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        IrProximaFase();
    }

}
