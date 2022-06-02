using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGrounding : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] float maxDistance = 3f;

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;
    [field: SerializeField] public bool IsGrounded{ get; private set; }
    [field: SerializeField] public Vector2 groundedDirection { get; private set; }
   
    void Update()
    {
        foreach (var position in positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded) break;
        }
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
        var rayCastHit = Physics2D.Raycast(_foot.position, _foot.forward, maxDistance, _layerMask);
        Debug.DrawRay(_foot.position, _foot.forward * maxDistance, Color.red);

        if (rayCastHit.collider != null)
        {
            if (rayCastHit.collider.transform != null)
            {
                groundedObjectLastPosition = rayCastHit.collider.transform.position;
            }
            groundedObject = rayCastHit.collider.transform;
            IsGrounded = true;
            groundedDirection = _foot.forward;
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
