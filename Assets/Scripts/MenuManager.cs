using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string firstLevelName = "Level_1";

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelName);
    }

    public void ResumeGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
