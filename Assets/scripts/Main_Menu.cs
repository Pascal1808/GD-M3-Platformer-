using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject startMainMenu;
    public GameObject LevelSelect;
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToLevelSelect()
    {
        startMainMenu.SetActive(false);
        LevelSelect.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
