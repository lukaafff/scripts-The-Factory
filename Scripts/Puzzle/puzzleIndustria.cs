using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleIndustria : MonoBehaviour
{
    //rotações possiveis
    float[] rotacoes = {0, 90, 180, 270 };

    public float[] posicaoCorreta;
    [SerializeField]bool colocado = false;

    int PossiveisRots = 1;


    IndustriaGerenciadorPuzzle gerenciadorPuzzleI;
    private void Awake() {
        gerenciadorPuzzleI = GameObject.Find("IndustriaGerenciadorPuzzle").GetComponent<IndustriaGerenciadorPuzzle>();
    }
    private void Start()
    {
        PossiveisRots = posicaoCorreta.Length;

        //definindo aleatoriedades dos canos ao iniciar
        int rand = Random.Range(0, rotacoes.Length);
        transform.eulerAngles = new Vector3(0, 0, rotacoes[rand]);

        if(PossiveisRots > 1)
        {
            if(transform.eulerAngles.z == posicaoCorreta[0])
            {
                colocado = true;
                gerenciadorPuzzleI.MovimentoCorreto();
            }
        }

    }

     //é chamado quando o usuário pressiona o botão do mouse enquanto está sobre o Collider
    private void OnMouseDown() 
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if(PossiveisRots > 1)
        {
            if(transform.eulerAngles.z == posicaoCorreta[0] || transform.eulerAngles.z == posicaoCorreta[1] && colocado == false)
            {
                colocado = true;
                gerenciadorPuzzleI.MovimentoCorreto();
            }
            else if(colocado == true)
            {
                colocado = false;
            }
        }
        else
        {
            if(transform.eulerAngles.z == posicaoCorreta[0] && colocado == false)
            {
                colocado = true;
                gerenciadorPuzzleI.MovimentoCorreto();
            }
            else if(colocado == true)
            {
                colocado = false;
            }
        }
    }
}
