using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaCarregamento : MonoBehaviour
{

    [SerializeField] private Slider BarraProgresso;
    [SerializeField] private string Local;

    void Start()
    {
        this.BarraProgresso.gameObject.SetActive(true);
        StartCoroutine(CarregarCena());

    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Local);
        while (!asyncOperation.isDone)
        {
            this.BarraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }
}
