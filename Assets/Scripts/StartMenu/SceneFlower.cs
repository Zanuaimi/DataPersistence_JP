using System;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

public class SceneFlower : MonoBehaviour
{
    // Variables
    private string playerName = "";
    public static SceneFlower instance = null;
    // Methods
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Makes this gameObject become a DontDestroyOnLoad gameObject, so it can carry data in this between scenes
        }
        else
        {
            Destroy(gameObject); // Have no duplicates of this object
        }
    }

    public void UpdateBest(int newScore, string newName)
    {
        string oldName = PlayerPrefs.GetString("BestName", "");
        int oldScore = PlayerPrefs.GetInt("Highscore", 0);

        // If newScore is higher or equal to highscore, update best name and highscore. No update if not.
        if (newScore >= oldScore)
        {
            PlayerPrefs.SetInt("Highscore", newScore);
            PlayerPrefs.SetString("BestName", newName);
            Debug.Log("New highscore: " + newScore + " by " + newName);
            return;
        }
        Debug.Log("Highscore and best name isn't updated.");

    }

    // Properties ( Accessor methods )

    public int Highscore
    {
        get
        {
            int score = PlayerPrefs.GetInt("Highscore", 0);
            return score;
        }
    }
    public string Name
    {
        get { return playerName; }
        set { playerName = value; }
    }
    public string BestName
    {
        get
        {
            string bestname = PlayerPrefs.GetString("BestName", "");
            return bestname;
        }
    }
}
