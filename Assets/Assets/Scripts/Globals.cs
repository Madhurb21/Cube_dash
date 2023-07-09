using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static int n = 10;
    public static int lives;
    public static int deaths;
    public static int high_score = 99999;
    public static int[] levels_complete = new int[n];

    private void Start() 
    {
        for(int i = 0; i < n; i++)
        {
            levels_complete[i] = 0;
        }
    }
    
}
