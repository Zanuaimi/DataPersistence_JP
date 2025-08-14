using System;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

public class SceneFlower : MonoBehaviour
{
    // Variables
    private string name = "";
    public static SceneFlower instance = null;
    // Methods
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
        }
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
        get { return name; }
        set { name = value; }
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
