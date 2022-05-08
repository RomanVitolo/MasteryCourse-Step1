using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.WasHitByPlayer() && other.WasHitFromBottomSide())
        {
            Destroy(gameObject);
        }
    }
}