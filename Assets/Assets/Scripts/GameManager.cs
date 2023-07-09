using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool game_paused = true;
    private bool game_started = false;
    [SerializeField] GameObject pause_menu;
    [SerializeField] GameObject level_complete_menu;
    [SerializeField] Text lives_num;
    [SerializeField] Text deaths_num;
    [SerializeField] Text deaths_till_now;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f; //Game is paused in the beginning
    }

    // Update is called once per frame
    void Update()
    {
        lives_num.text = Globals.lives.ToString("0");
        deaths_num.text = Globals.deaths.ToString("0");
        deaths_till_now.text = Globals.deaths.ToString("0");

        if(game_started == false && Input.GetKeyDown(KeyCode.Return)) //Starting the game
        {
            Time.timeScale = 1f;
            game_started = true;
            game_paused = false;
        }

        if(game_started)
        {
            if(game_paused == false && Input.GetKeyDown(KeyCode.Escape))
            {
                pause_game();
            }
            else if(game_paused && Input.GetKeyDown(KeyCode.Escape))
            {
                continue_game();
            }
        }
    }

    public void restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void pause_game()
    {
        Time.timeScale = 0f;
        game_paused = true;
        pause_menu.SetActive(true);
    }
    public void continue_game()
    {
        Time.timeScale = 1f;
        game_paused = false;
        pause_menu.SetActive(false);
    }

    public void level_complete()
    {
        level_complete_menu.SetActive(true);
    }
    public void load_next_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void main_menu()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
