using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2DColliderData 
{
    public CapsuleCollider2D Collider { get; private set; }
    public CapsuleCollider2D TakeDamageCollider { get; private set; }
    public Vector2 ColliderCenterInLocalSpace { get; private set; }
    public Vector2 ColliderVerticalExtents { get; private set; }

    public void Initialize(GameObject gameObject,GameObject takeDamageCollider)
    {
        if (Collider != null)
        {
            return;
        }

        Collider = gameObject.GetComponent<CapsuleCollider2D>();
        TakeDamageCollider = takeDamageCollider.GetComponent<CapsuleCollider2D>();
        UpdateColliderData();
    }

    public void UpdateColliderData()
    {
        ColliderCenterInLocalSpace = Collider.bounds.center;

        ColliderVerticalExtents = new Vector2(0f, Collider.size.y/2);
    }
}
