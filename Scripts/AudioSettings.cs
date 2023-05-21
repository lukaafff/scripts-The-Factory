using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider VolumeMusica;
    [SerializeField]private Slider VolumeSFX;
    [SerializeField]private Slider VolumeGeral;

    void Start()
    {
        if(PlayerPrefs.HasKey("SomMusica"))
        {
            SalvarVolume();
        }
        else
        {
            VolumeDaMusica();
            VolumeDoSFX();
            VolumeDoGeral();
            
        }
    
        
    }

    public void VolumeDaMusica()
    {
        float volume = VolumeMusica.value;
        Mixer.SetFloat("musica", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SomMusica",volume);
    }
    public void VolumeDoSFX()
    {
        float volume = VolumeSFX.value;
        Mixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SomSFX", volume);
    }

    public void VolumeDoGeral()
    {
        float volume = VolumeGeral.value;
        Mixer.SetFloat("volumeGeral", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SomGeral",volume);
    }
 
   

    private void SalvarVolume()
    {
        VolumeMusica.value = PlayerPrefs.GetFloat("SomMusica");
        VolumeSFX.value = PlayerPrefs.GetFloat("SomSFX");
        VolumeGeral.value = PlayerPrefs.GetFloat("SomGeral");
        

        VolumeDaMusica();
        VolumeDoSFX();
        VolumeDoGeral();
       
    }
}
