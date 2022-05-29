using UnityEngine;

public static class Collision2DExtensions
{
    public static bool WasHitByPlayer(this Collision2D other)
    {
        return other.collider.GetComponent<AgentController>() != null;
    }
    
    public static bool WasHitFromBottomSide(this Collision2D other)
    {
        return other.contacts[0].normal.y > 0.5f;
    }

    public static bool WasHitFromTopSide(this Collision2D other)
    {
        return other.contacts[0].normal.y < -0.5f;
    }

    public static bool WasSide(this Collision2D other)
    {
        return other.contacts[0].normal.x < -0.5f || other.contacts[0].normal.x > 0.5f;
    }
    
}