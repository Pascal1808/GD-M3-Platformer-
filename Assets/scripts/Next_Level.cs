using UnityEngine;

public class Next_Level : MonoBehaviour
{
    public string nextLevelName;
    public int NextLevelValue;
    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("LevelReached", NextLevelValue);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1f; 
    }
}
