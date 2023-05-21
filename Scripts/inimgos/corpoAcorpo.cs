using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpoAcorpo : MonoBehaviour
{
    [Header("Parametros de ataque")]
   [SerializeField] private float atackCooldown;
   [SerializeField] private float range;
   [SerializeField] private int damage;

   [Header("Parametros de colisão")]
   [SerializeField] private float colliderDistance;
   [SerializeField] private BoxCollider2D boxCollider;

   [Header("Player layer")]
   [SerializeField] private LayerMask playerLayer;
   private float cooldownTimer = Mathf.Infinity;

    //referencias
   private Animator anim;

   private SistemaVida vidaPlayer;
   private patrulha patrulhaInimigo;

   private void Awake() 
   {
        anim = GetComponent<Animator>();
        patrulhaInimigo = GetComponentInParent<patrulha>();
   }

   private void Update() 
   {
        cooldownTimer += Time.deltaTime;

        //ataque apenas quando o jogador estiver à vista
        if(PlayerInSight())
        {
            if(cooldownTimer >= atackCooldown)
            {
                //ataque
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }
        
        if(patrulhaInimigo != null)
        {
            patrulhaInimigo.enabled = !PlayerInSight();
        }
   }

   private bool PlayerInSight()
   {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            vidaPlayer = hit.transform.GetComponent<SistemaVida>();
        }

        return hit.collider != null;
   }

   private void OnDrawGizmos() {
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
   }

   private void DamagePlayer()
   {
        if(PlayerInSight())
        {
            vidaPlayer.LogicaVida();
        }
   }
}
