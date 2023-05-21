using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenciasPlayer : MonoBehaviour
{
   private int VidaPlayer = 5;
    private int VelocidadePlayer = 10;
    private int DanoPlayer = 1;
    private int VelocidadeTiroPlayer = 18;
    private bool fezUpgrade = false;

    // Start is called before the first frame update
    void Start()
    {   
    fezUpgrade = PlayerPrefs.GetInt("fezUpgrade") == 1;

    if (!fezUpgrade)
    {
        Padrao();
        PlayerPrefs.SetInt("fezUpgrade", 1);
        PlayerPrefs.Save();
    }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Padrao()
    {
        PlayerPrefs.SetInt("vidap", VidaPlayer);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("velocidadep", VelocidadePlayer);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("danop", DanoPlayer);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("velocidadeTPp", VelocidadeTiroPlayer);
        PlayerPrefs.Save();
    }

    void UpgradeDano()
    {
        PlayerPrefs.SetInt("danop", 3);
        PlayerPrefs.Save();
    }

    void UpgradeVida()
    {
        PlayerPrefs.SetInt("vidap", 10);
        PlayerPrefs.Save();
    }

    void UpgradeVelocidade()
    {
        PlayerPrefs.SetInt("velocidadep", 15);
        PlayerPrefs.Save(); 
    }

    void UpgradeVelocidadeTiro()
    {
        PlayerPrefs.SetInt("velocidadeTPp", 21);
        PlayerPrefs.Save();
    }
}
