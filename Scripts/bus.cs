using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bus : MonoBehaviour
{
    [SerializeField] private string Cena;

    public void Seguir()
    {
        SceneManager.LoadScene(Cena);
        
    }
}