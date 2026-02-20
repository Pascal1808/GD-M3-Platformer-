using UnityEngine;

public class Restart_Game : MonoBehaviour
{
   public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f; 
    }

}
