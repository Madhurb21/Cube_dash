using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_M : MonoBehaviour
{
    [SerializeField] Text high_score_text;
    [SerializeField] Text deaths_text;
    // Start is called before the first frame update
    void OnEnable()
    {
        Globals.high_score = PlayerPrefs.GetInt("HighScore", 99999);
        Globals.levels_complete[1] = PlayerPrefs.GetInt("Level_1", 0);
        Globals.levels_complete[2] = PlayerPrefs.GetInt("Level_2", 0);
        Globals.levels_complete[3] = PlayerPrefs.GetInt("Level_3", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.high_score < 99999)
        {
            high_score_text.text = Globals.high_score.ToString("0");
        }
        else
        {
            high_score_text.text = "XX";
        }
        deaths_text.text = Globals.deaths.ToString("0");
    }
    public void levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
