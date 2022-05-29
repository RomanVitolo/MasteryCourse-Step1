using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [FormerlySerializedAs("spriteBladeeSaw")] 
    [SerializeField] private Transform sprite;
    [SerializeField] private float speed = 3f;
    
    private float positionPercent;
    private int direction = 1;
    private void Update()
    {

        float distance = Vector3.Distance(startPosition.position, endPosition.position);
        float speedForDistance = speed / distance;
        
        positionPercent += Time.deltaTime * direction * speedForDistance;

        sprite.position = Vector3.Lerp(startPosition.position, endPosition.position, positionPercent);

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
