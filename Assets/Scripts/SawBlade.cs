using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform spriteBladeeSaw;
    
    private float positionPercent;
    private float speed = 3f;
    private int direction = 1;
    private void Update()
    {

        float distance = Vector3.Distance(startPosition.position, endPosition.position);
        float speedForDistance = speed / distance;
        
        positionPercent += Time.deltaTime * direction * speedForDistance;

        spriteBladeeSaw.position = Vector3.Lerp(startPosition.position, endPosition.position, positionPercent);

        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }
}
