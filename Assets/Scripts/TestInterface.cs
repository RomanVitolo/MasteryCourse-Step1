using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterface : MonoBehaviour, ITakeShellHits
{
    public void HandleShellHit(ShellFlipped _shellFlipped)
    {
        Debug.Log("Do Something here");
        Destroy(gameObject);
    }
}
