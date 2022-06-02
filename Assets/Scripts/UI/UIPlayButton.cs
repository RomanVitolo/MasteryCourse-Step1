using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayButton : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.MoveToNextLevel();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    
    
}
