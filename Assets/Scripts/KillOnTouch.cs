using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var agenControler = other.collider.GetComponent<AgentController>();
        if (agenControler != null)
        {
            GameManager.Instance.KillPlayer();
        }
    }

    
}
