using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int Level;
       void Start()
    {
        Button btn = GetComponent<Button>();
        
        if(PlayerPrefs.GetInt("LevelReached") < Level)
        {
            btn.interactable = false;
        }
        else
        {
            btn.interactable = true;
        }
    }

   
}

