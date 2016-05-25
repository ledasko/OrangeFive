using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DesertPauseMenu : MonoBehaviour {
    public string mainMenu;

    public GameObject pauseMenu;

    public void PauseGame()
    {
        MenuShow(true);
        StopTime();
    }

    public void ResumeGame()
    {
        MenuShow(false);
        StartTime();
    }

    public void RestartGame()
    {
        MenuShow(false);
        FindObjectOfType<GameManager>().Reset();
        StartTime();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(mainMenu);
        StartTime();
    }

    // Sets time scaling to 1.
    private void StartTime()
    {
        Time.timeScale = 1f;
    }

    // Sets time scaling to 0.
    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    // Show pause menu.
    private void MenuShow(bool b)
    {
        pauseMenu.SetActive(b);
    }
}
