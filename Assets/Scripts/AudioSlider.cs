using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    private const string saveKey = "PLAYER_DATA";
    public float volume = 100f;
    public AudioSource audioSource;
    public Slider slider;
    private const float volumeConst = 20f;
    private PlayerData data = new PlayerData();
    void Start()
    {
        Load();
        ValueMusic();
    }


    public void SliderMusic()
    {
        volume = slider.value;
        Save();
        ValueMusic();
    }
    private void ValueMusic()
    {
        audioSource.volume = volume;
        slider.value = volume;
    }

    private void Save()
    {
        saveHelper.Save(saveKey, getPlayerData());
    }

    private void Load()
    {
        data = saveHelper.Load<PlayerData>(saveKey);
        volume = data.audioVolume;
    }

    public PlayerData getPlayerData() {
        var playerData = new PlayerData() {
            audioVolume = volume,
            level = data.level
        };
        return playerData;
    }
}
