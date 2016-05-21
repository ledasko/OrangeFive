using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DesertDeathMenu : MonoBehaviour {
    public string currentLevel;
    public string mainMenu;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(mainMenu);
    }

    // Sets time scaling to 1.
    private void StartTime()
    {
        Time.timeScale = 1f;
    }
}