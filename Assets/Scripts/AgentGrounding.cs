using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGrounding : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] float maxDistance = 3f;

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;
    [field: SerializeField] public bool IsGrounded{ get; private set; }
   
    void Update()
    {
        CheckFootForGrounding(_leftFoot);
        if (IsGrounded == false)
        {
            CheckFootForGrounding(_rightFoot);
        }
        StickMovingObject();
    }

    private void StickMovingObject()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue && groundedObjectLastPosition != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                transform.position += delta;
            }
            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform _foot)
    {
        var rayCastHit = Physics2D.Raycast(_foot.position, Vector2.down, maxDistance, _layerMask);
        Debug.DrawRay(_foot.position, Vector3.down * maxDistance, Color.red);

        if (rayCastHit.collider != null)
        {
            groundedObject = rayCastHit.collider.transform;
            IsGrounded = true;
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
