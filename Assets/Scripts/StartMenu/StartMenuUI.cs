using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    // Variables

    // UI Components
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TMP_InputField nameInputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load best score and username for that highscore
        scoreText.text = "Best Score : " + SceneFlower.instance.BestName + " : " + SceneFlower.instance.Highscore; // Access to the variables from static instance variable from SceneFlower class, no need to find gameObject
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterName()
    {
        // Read and update name for SceneFlower object
        string value = nameInputField.text;
        SceneFlower.instance.Name = value;
        Debug.Log("Name: " + value);
    } 
}
