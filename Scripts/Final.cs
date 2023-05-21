using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public void VoltarMenu()
   
    {
        SceneManager.LoadScene(0);
    }
    
    public void SairJogo()
   
    {
        Application.Quit();
        Debug.Log("Aplicativo Encerrado");
    }

}
