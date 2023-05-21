using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulha : MonoBehaviour
{
    [Header ("Pontos de Patrulha")]
    [SerializeField] private Transform bordaEsquerda;

    [SerializeField] private Transform bordaDireita;

    [Header ("Inimigo")]
    [SerializeField] private Transform inimigo;

    [Header ("Parametro Movimento")]
    [SerializeField] private float velocidade;
    private Vector3 escalaInicial;
    private bool moverEsquerda;

    [Header ("Tempo espera")]
    [SerializeField] private float idleDuracao;
    private float tempoIdle;


    [Header ("Animação inimigo")]
    [SerializeField] private Animator anim;

    private void Awake() {
        escalaInicial = inimigo.localScale;
    }

    private void OnDisable() {
        anim.SetBool("moving", false);
    }

    private void Update() 
    {
        if(moverEsquerda)
        {
            if(inimigo.position.x >= bordaEsquerda.position.x)
            {
                MoverDirecao(-1);
            }
            else
            {
                EscolherDirecao();
            }
        }
        else
        {
            if(inimigo.position.x <= bordaDireita.position.x)
            {
                MoverDirecao(1);
            }
            else
            {
                EscolherDirecao();
            }
        }
    }

    private void EscolherDirecao()
    {
        anim.SetBool("moving", false);

        tempoIdle += Time.deltaTime;

        if(tempoIdle > idleDuracao)
        {
            moverEsquerda = !moverEsquerda;
        }
    }

    private void MoverDirecao( int direcao)
    {
        tempoIdle = 0;
        anim.SetBool("moving", true);

        inimigo.localScale = new Vector3(Mathf.Abs(escalaInicial.x) * direcao, escalaInicial.y, escalaInicial.z);

        inimigo.position = new Vector3(inimigo.position.x + Time.deltaTime * direcao * velocidade, inimigo.position.y, inimigo.position.z);
    }
}
