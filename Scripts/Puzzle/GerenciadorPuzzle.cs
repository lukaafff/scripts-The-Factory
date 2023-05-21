using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorPuzzle : MonoBehaviour
{  
    public void inicarPuzzle(string cenaa)
    {
        SceneManager.LoadScene(cenaa);
    }
}
