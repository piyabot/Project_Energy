using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main_Level");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
