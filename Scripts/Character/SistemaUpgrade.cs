using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaUpgrade : MonoBehaviour
{
    public int vidaMaxima ;
    public int velocidadeMaxima = 10;
    public int danoMaximo = 1;
    public int velocidadeTiroMaxima = 18;

    private int vidaAtual;
    private int velocidadeAtual;
    private int danoAtual;
    private int velocidadeTiroAtual;

    void Start()
    {
        // Carrega os valores das preferências do jogador
        vidaAtual = PlayerPrefs.GetInt("vidap", vidaMaxima);
        velocidadeAtual = PlayerPrefs.GetInt("velocidadep", velocidadeMaxima);
        danoAtual = PlayerPrefs.GetInt("danop", danoMaximo);
        velocidadeTiroAtual = PlayerPrefs.GetInt("velocidadeTPp", velocidadeTiroMaxima);
    }

    void OnTriggerEnter(Collider other)
    {
        // Se colidir com um objeto coletável
        if (other.CompareTag("Upgrade"))
        {
            // Remove o objeto coletável
            Destroy(other.gameObject);

            // Faz o upgrade na preferência correspondente
            switch (other.gameObject.name)
            {
                case "UpgradeVida":
                    UpgradeVida();
                    break;
                case "UpgradeVelocidade":
                    UpgradeVelocidade();
                    break;
                case "UpgradeDano":
                    UpgradeDano();
                    break;
                case "UpgradeVelocidadeTiro":
                    UpgradeVelocidadeTiro();
                    break;
            }
        }
    }

    void UpgradeVida()
    {
        // Aumenta a vida em 1 e salva a preferência
        vidaAtual += 1;
        PlayerPrefs.SetInt("vidap", vidaAtual);
        PlayerPrefs.Save();
    }

    void UpgradeVelocidade()
    {
        // Aumenta a velocidade em 1 e salva a preferência
        velocidadeAtual += 10;
        PlayerPrefs.SetInt("velocidadep", velocidadeAtual);
        PlayerPrefs.Save();
    }

    void UpgradeDano()
    {
        // Aumenta o dano em 1 e salva a preferência
        danoAtual += 1;
        PlayerPrefs.SetInt("danop", danoAtual);
        PlayerPrefs.Save();
    }

    void UpgradeVelocidadeTiro()
    {
        // Aumenta a velocidade do tiro em 1 e salva a preferência
        velocidadeTiroAtual += 1;
        PlayerPrefs.SetInt("velocidadeTPp", velocidadeTiroAtual);
        PlayerPrefs.Save();
    }
}
