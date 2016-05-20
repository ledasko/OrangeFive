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
}