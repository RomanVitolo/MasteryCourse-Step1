using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int Lives { get; private set; }
    public int coins { get; private set; }
    

    public event Action<int> OnLivesChanged; 
    public event Action<int> OnCoinsChanged; 


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            RestartGame();
        }
    }

    internal void KillPlayer()
    {
        Lives--;
        OnLivesChanged?.Invoke(Lives);
        if (Lives <= 0)
        {
            RestartGame();
        }
    }
    
    internal void CoinCollected()
    {
        coins++;
        OnCoinsChanged?.Invoke(coins);
    }

    private void RestartGame()
    {
        Lives = 3;
        coins = 0;
        
        OnCoinsChanged?.Invoke(coins);
        
        SceneManager.LoadScene(0);
    }
}
