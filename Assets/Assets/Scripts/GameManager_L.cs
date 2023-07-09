using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_L : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void main_menu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public void level_1()
    {   
        SceneManager.LoadScene("Level_1");
    }
    public void level_2()
    {
        if(Globals.levels_complete[1] == 1)
        {
            SceneManager.LoadScene("Level_2");
        }
    }
    public void level_3()
    {
        if(Globals.levels_complete[2] == 1)
        {
            SceneManager.LoadScene("Level_3");
        }
    }
}
