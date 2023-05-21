using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFinal : MonoBehaviour
{
	public Transform player;

	public bool isFlipped = false;

	public int vida;
    public int dano;   
    public GameObject itemDrop;

    void Start()
    {
        dano = PlayerPrefs.GetInt("danop");
        itemDrop.SetActive(false);
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
        itemDrop.SetActive(true);
    }

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}