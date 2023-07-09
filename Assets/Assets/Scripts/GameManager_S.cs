using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_S : MonoBehaviour
{
    
    [SerializeField] AudioMixer Music;
    [SerializeField] AudioMixer FX;
    [SerializeField] Slider music_slider;
    [SerializeField] Slider fx_slider;
    [SerializeField] Dropdown quality_dropdown;
    
    private void Start()
    {
        music_slider.value = PlayerPrefs.GetFloat("music_volume", 0.75f);
        fx_slider.value = PlayerPrefs.GetFloat("fx_volume", 0.75f);
        quality_dropdown.value = PlayerPrefs.GetInt("quality_level", 1);
    }
    public void reset_stats()
    {
        PlayerPrefs.DeleteAll();
        Globals.deaths = 0;
        Globals.high_score = 99999;
        for(int i = 0; i < 10; i++)
        {
            Globals.levels_complete[i] = 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void music_control(float sliderValue)
    {
        Music.SetFloat("volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("music_volume", sliderValue);
    }
    public void fx_control(float sliderValue)
    {
        FX.SetFloat("volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("fx_volume", sliderValue);
    }
    public void main_menu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public void levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void set_quality(int quality_level)
    {
        QualitySettings.SetQualityLevel(quality_level);
        PlayerPrefs.SetInt("quality_level", quality_level);
    }
}
