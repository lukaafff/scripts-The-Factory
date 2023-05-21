using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndustriaGerenciadorPuzzle : MonoBehaviour
{
    public GameObject SuporteTubos;
    public GameObject[] Tubos;


    [SerializeField] int totalTubos;

    [SerializeField] int tubosCertos;

    void Start()
    {
        TubosAleatorios();
    }

    private void Update() {
        Ganhou();
    }

    public void TubosAleatorios()
    {
        //o total de tubos é o que esta no jogo, que definimos
        totalTubos = 7;

        Tubos = new GameObject[totalTubos];

        for(int i = 0; i < Tubos.Length; i++)
        {
            Tubos[i] = SuporteTubos.transform.GetChild(i).gameObject;
        }
    }

    public void MovimentoCorreto()
    {
        tubosCertos += 1;
        Debug.Log("movimento correto");
    }

    public void Ganhou()
    {
        if(tubosCertos == totalTubos)
        {
            GameObject.Find("Ganhou2").GetComponent<VencerTubos>().AddPontos();
            Debug.Log("ganhou");
        }
    }
}