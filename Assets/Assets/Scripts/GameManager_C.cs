using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_C : MonoBehaviour
{
    [SerializeField] GameObject HighScore_Panel;
    [SerializeField] GameObject NHighScore_Panel;
    [SerializeField] Text high_score_text;
    [SerializeField] Text high_score_panel_text;
    [SerializeField] Text your_score_text;

    // Start is called before the first frame update
    void Awake()
    {
        if(Globals.deaths <= Globals.high_score)
        {
            HighScore_Panel.SetActive(true);
            Globals.high_score = Globals.deaths;
            PlayerPrefs.SetInt("HighScore", Globals.high_score);
        }
        else
        {
            NHighScore_Panel.SetActive(true);
        }
    }

    private void Update() 
    {
        your_score_text.text = Globals.deaths.ToString();
        high_score_text.text = Globals.deaths.ToString();
        high_score_panel_text.text = Globals.deaths.ToString();
    }
    public void main_menu()
    {
        Invoke("Disappear", 2f);
        SceneManager.LoadScene("Main_menu");
    }

    private void Disappear()
    {
        HighScore_Panel.SetActive(false);
        NHighScore_Panel.SetActive(false);
    }
}
