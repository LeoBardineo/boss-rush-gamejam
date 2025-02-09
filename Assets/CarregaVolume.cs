using UnityEngine;
using UnityEngine.Audio;

public class CarregaVolume : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        float musicDB = musicVol > 0f ? Mathf.Log10(musicVol) * 20 : -80f;
        audioMixer.SetFloat("MusicVolume", musicDB);

        float sfxDB = sfxVol > 0f ? Mathf.Log10(sfxVol) * 20 : -80f;
        audioMixer.SetFloat("SFXVolume", sfxDB);
    }
}
