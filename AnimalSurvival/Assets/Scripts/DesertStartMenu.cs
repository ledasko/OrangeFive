using UnityEngine;
using System.Collections;

public class DesertStartMenu : MonoBehaviour {
    public GameObject startMenu;

    public void StartGame()
    {
        MenuShow(false);
        StartTime();
    }

    public void Start()
    {
        StopTime();
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

    // Show/hide start menu.
    private void MenuShow(bool b)
    {
        startMenu.SetActive(b);
    }
}
