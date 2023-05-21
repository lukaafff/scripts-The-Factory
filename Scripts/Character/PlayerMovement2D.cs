using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerMovement2D : MonoBehaviour
{

    //var movimentação em X
    private float movimentacao;
    public float velocidadeMovimento;

    //var movimentação em y/Jump
    [SerializeField]private float velocidadePulo;
    [SerializeField]private float velocidadePuloDuplo;
    [SerializeField]private bool estaNoChao;
    [SerializeField]private int numeroPulos;
    public Transform posicaoPe;
    public LayerMask Ground;
    public float tamanhoRaio; 

    //var dash
    [SerializeField]private float dashSpeed;
    [SerializeField]private bool canDash;
    [SerializeField]private bool isDashing;
    [SerializeField]private float dashingTime;
    [SerializeField]private float dashingCoolDown;
    [SerializeField] TrailRenderer tr;

     //var tiro
    [SerializeField]private GameObject balaProjetil; //o objeto bala
    [SerializeField]private Transform arma;          //posição de onde o tiro é desparado
    [SerializeField]private bool executarTiro;       //input do tiro
    [SerializeField]private float velocidadeTiro;    //velocidade do nosso tiro
    [SerializeField]private bool podeAtirar; //verifica se pode ou não atirar
    [SerializeField]private float tiroEspera; //espera entre um tiro e outro

    //var geral
    public Rigidbody2D rigB;
    public SpriteRenderer sprite;
    public Animator animationPlayer;

    public bool flipX;

    private ControladorJogo gcPlayer;
    public Text DocTxT;

    public GameObject PopUp;
    public GameObject notificacao;

    //som
    public GameObject AudioPegarItem;
    public AudioSource AudioPular;
    

    // Todos os comandos no Start são executados somente uma vez, na inicialização do Script;
    void Start()
        {
            PopUp.SetActive(false);
            notificacao.SetActive(true);

            gcPlayer = ControladorJogo.gc;
            rigB =  GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            animationPlayer = GetComponent<Animator>();
            AudioPular = GetComponent<AudioSource>();

            gcPlayer.documento = 0;
            
        }

    // Update executa o código a cada freme, porem objetos com fisica não é recomendado que sejam executados aqui
    void Update()
    {
        VerificaSeEstaCorrendo();
        
        VerificaSeEstaNoChao();

        MovimentacaoPersonagem();

        InverterSprite();

        Pular();
        
        Correr_Dash();

        RealizarAtirar();

        DocTxT.text = gcPlayer.documento.ToString();
    }


// ----------------- Métodos -------------------------------
    void VerificaSeEstaCorrendo()
    {
        if (isDashing)
        {
            return;
        }
    }

    void VerificaSeEstaNoChao()
    {
        //Reconhecimento do chão
        //cria um circulo na posição do pé do personagem para verificar colisão com chão
        estaNoChao = Physics2D.OverlapCircle(posicaoPe.position, tamanhoRaio, Ground);
        animationPlayer.SetBool("estaNoChao", estaNoChao);
        animationPlayer.SetFloat("velocidadeY", rigB.velocity.y);
    }

    //movimentação do personagem
    private Vector2 MovimentacaoPersonagem()
    {
        //input que recebe o valor da movimentação do personagem, o valor vai de -1 a 1, toda essa movimentação ocorre no eixo x (Horizontal)
        //-1 = esquerda
        //1 = direita

        //input teclado
        movimentacao = Input.GetAxisRaw("Horizontal");
        animationPlayer.SetFloat("velocidade", Mathf.Abs(movimentacao));

        //se o personagem esta parado ou não quer andar ou quer usar o joytick
        if (movimentacao == 0.0f)
        {
            //input joystick
            movimentacao = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            animationPlayer.SetFloat("velocidade", Mathf.Abs(movimentacao));
        }
        return new Vector2(movimentacao, 0);
        
    
    }

    void InverterSprite()
    {
        //inverter a posição do sprite do personagem
        //se flip na horizontal for menor que zero, olha para esquerda
        if (flipX == false && movimentacao < 0 )    
        {
            Flip();
        }
        //se flip na horizontal for menor que zero, olha para direita
        else if (flipX == true && movimentacao > 0)
        {
            Flip();    
        }
    }
    void Pular()
    {
        //se o personagem esta no chao
        if(estaNoChao == true)
        {
            //pular uma vez
            numeroPulos = 1;
            
            //se pressionado input teclado       ou   input joystick
            if(Input.GetKeyDown(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    //pular
                    Jump();
                }
        }
        else
        {   
            //se pressionado input teclado        ou  input joystick                               e  pulo extra maior que zero
            if(Input.GetKeyDown(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump") && numeroPulos > 0 )
                {
                    numeroPulos--;
                    //pulo duplo
                    DoubleJump();
                    
                }
        }
    }

    void Correr_Dash()
    {
        //se pressionado input shift esquerdo   ou  input joytick                                 e pode pode correr
        if (Input.GetKeyDown(KeyCode.LeftShift) || CrossPlatformInputManager.GetButtonDown("Dash") && canDash)
        {
            //iniciar corrotina do dash
            StartCoroutine(Dash());
        }
    }
    
    void RealizarAtirar()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) || CrossPlatformInputManager.GetButtonDown("Atirar") && podeAtirar)
        {
            StartCoroutine(Atirar());
        }
    }
    //FixedUpdate executa o código um controle fixo de frames per second, estipulado pela engine de física da Unity, sendo assim é melhor para funçoes com fisica 
    void FixedUpdate() 
    {
        if (isDashing)
        {
            return;
        }
        rigB.velocity = new Vector2(movimentacao*velocidadeMovimento,rigB.velocity.y);
    }

    //girar sprite do personagem
    void Flip()
    {
        flipX = !flipX;
        float x = transform.localScale.x;
        x*= -1;
        transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
        velocidadeTiro *= -1;
    }

    //função que executa o pulo do personagem
    void Jump()
    {
        AudioPular.Play();
        rigB.velocity = Vector2.up*velocidadePulo;
    }

    //função do double jump
    void DoubleJump()
    {
        AudioPular.Play();
        rigB.velocity = Vector2.up*velocidadePuloDuplo;
    }

    //rotina do dash
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rigB.gravityScale;
        rigB.gravityScale = 0f;
        rigB.velocity = new Vector2(transform.localScale.x * dashSpeed, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds (dashingTime);
        tr.emitting = false;
        rigB.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }
    //metodo colisao
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //chave
        if(collision.gameObject.tag == "Chaves")
        {
            //som
            GameObject prefab = Instantiate(AudioPegarItem, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            //parar som
            Destroy(prefab.gameObject, 1.5f);

            //destruir objeto
            Destroy(collision.gameObject);
            gcPlayer.chave++;
        }
        //celular
        if(collision.gameObject.tag == "celular")
        {

            PopUp.SetActive(true);

            //som
            GameObject prefab = Instantiate(AudioPegarItem, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            //parar som
            Destroy(prefab.gameObject, 1.5f);

            Destroy(collision.gameObject);
            gcPlayer.celular++;
        }
        //documento
        if(collision.gameObject.tag == "documento")
        {
             //som
            GameObject prefab = Instantiate(AudioPegarItem, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            //parar som
            Destroy(prefab.gameObject, 1.5f);

            Destroy(collision.gameObject);
            gcPlayer.documento = gcPlayer.documento + 1;
        }

    }
    public void FecharPopUp()
    {
        PopUp.SetActive(false);
    }

    IEnumerator Atirar()
    {
        podeAtirar = false;
        GameObject temp = Instantiate(balaProjetil);
        temp.transform.position =  arma.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocidadeTiro,0);
        yield return new WaitForSeconds (tiroEspera);
        podeAtirar = true;
    }
    
}

// ----------------- Métodos -------------------------------