using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenuUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load best score and username for that highscore
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
