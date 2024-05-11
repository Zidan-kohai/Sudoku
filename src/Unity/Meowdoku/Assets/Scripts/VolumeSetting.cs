using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private float musicVolume;
    [SerializeField] private float soundVolume;
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer soundMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        musicSlider.value = DataController.Instanse.PlayerData.musicVolume;
        soundSlider.value = DataController.Instanse.PlayerData.soundVolume;
    }


    public void SetMusic()
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
        musicVolume = musicSlider.value;
        DataController.Instanse.PlayerData.musicVolume = musicSlider.value;
        DataController.Instanse.Save();
    }

    public void SetSound()
    {
        soundMixer.SetFloat("MusicVolume", Mathf.Log10(soundSlider.value) * 20);
        soundVolume = soundSlider.value;
        DataController.Instanse.PlayerData.soundVolume = soundSlider.value;
        DataController.Instanse.Save();
    }
}
