using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleprefeitura : MonoBehaviour
{

    public GameObject lixeiraCorreta;
    private bool movendo;
    private bool finalizado;

    private float posicaoInicialX;
    private float posicaoInicialY;
    private Vector3 resetPosicao;

    void Start()
    {
        //voltar para a posição inicial
        resetPosicao = this.transform.localPosition;
    }

    void Update()
    {
        if(finalizado == false)
        {
            if(movendo){
            Vector3 posicaoMouse;
            //variavel posicaoMouse é igual a posição do mouse e da camera
            posicaoMouse = Input.mousePosition;
            posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);

            //mover lixos pegando posição mouse
            this.gameObject.transform.localPosition = new Vector3(posicaoMouse.x - posicaoInicialX, posicaoMouse.y - posicaoInicialY, this.gameObject.transform.localPosition.z);
        }
        }
    }
    
    //é chamado quando o usuário pressiona o botão do mouse enquanto está sobre o Collider
    private void OnMouseDown() {
        //se pressionado o botão
        if(Input.GetMouseButtonDown(0)) {
            Vector3 posicaoMouse;
            //variavel posicaoMouse é igual a posição do mouse e da camera
            posicaoMouse = Input.mousePosition;
            posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);

            posicaoInicialX = posicaoMouse.x - this.transform.localPosition.x;
            posicaoInicialY = posicaoMouse.y - this.transform.localPosition.y;

            movendo = true;
        }
    }

    //é chamado quando o usuário libera o botão do mouse.
    private void OnMouseUp() {
        movendo = false;
        //retornar o valor absoluto de um número da posicao X e Y
        if(Mathf.Abs(this.transform.localPosition.x - lixeiraCorreta.transform.localPosition.x) <= 1.5f && 
            Mathf.Abs(this.transform.localPosition.x - lixeiraCorreta.transform.localPosition.x) <= 1.5f)
        {
            //lixo na lixeira correta
            this.transform.position = new Vector3(lixeiraCorreta.transform.position.x, lixeiraCorreta.transform.position.y, lixeiraCorreta.transform.position.z);

            finalizado = true;

            GameObject.Find("Ganhou").GetComponent<puzzleVencer>().AddPontos();
        }
        else
        {
            //lixo na lixeira errada volta para a posição inicial
            this.transform.localPosition = new Vector3(resetPosicao.x, resetPosicao.y, resetPosicao.z);
        }
    }

    
}
