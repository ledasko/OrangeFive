using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string levelSelect;

    public void PlayGame()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void Options()
    {

    }

    public void About()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
