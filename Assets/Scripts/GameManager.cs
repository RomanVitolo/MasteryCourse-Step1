using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [field: SerializeField] public int Lives { get; private set; }
    [field: SerializeField] public int coins { get; private set; }
    
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

    /*private void Update()
    {
        System.Threading.Thread.Sleep(50);
    }*/

    internal void KillPlayer()
    {
        Lives--;
        OnLivesChanged?.Invoke(Lives);
        if (Lives <= 0)
        {
            RestartGame();
        }
        else
        {
            SendPlayerToCheckPoint();
        }
    }

     void SendPlayerToCheckPoint() //Obtengo el ultimo checkpoint y envio al player a esa posicion. 
     {
         var _checkpointManager = FindObjectOfType<CheckPointManager>();
         var checkpoint = _checkpointManager.GetLastCheckPointThatWasPassed();
         var _player = FindObjectOfType<AgentController>();
         _player.transform.position = checkpoint.transform.position;
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
