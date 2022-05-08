using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var agentController = other.collider.GetComponent<AgentController>();
        if (agentController != null)
        {
            GameManager.Instance.KillPlayer();
        }
    }
}
