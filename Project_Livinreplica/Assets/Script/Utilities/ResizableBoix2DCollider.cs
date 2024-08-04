using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizableBoix2DCollider : MonoBehaviour
{
    public Box2DColliderData Box2DColliderData { get; private set; }
    [field: SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }
    [field: SerializeField] public PlayerTriggerColliderData TriggerColliderData { get; private set; }
    //[field: SerializeField] public SlopeData SlopeData { get; private set; }

    private void Awake()
    {
        Resize();
    }

    private void OnValidate()
    {
        Resize();
    }

    public void Resize()
    {
        Initialize(gameObject,TriggerColliderData.TakeDamageCollider.gameObject);

        CalculateCapsuleColliderDimensions();
    }

    public void Initialize(GameObject gameObject,GameObject takeDamageCollider)
    {
        if (Box2DColliderData != null)
        {
            return;
        }

        Box2DColliderData = new Box2DColliderData();

        Box2DColliderData.Initialize(gameObject,takeDamageCollider);

        OnInitialize();
    }

    protected virtual void OnInitialize()
    {
    }

    public void CalculateCapsuleColliderDimensions()
    {
        SetCapsuleColliderSize(DefaultColliderData.Width, DefaultColliderData.Height);

        //SetCapsuleColliderHeight(DefaultColliderData.Height * (1f - SlopeData.StepHeightPercentage));
        
        RecalculateCapsuleColliderCenter();

        //RecalculateColliderRadius();

        Box2DColliderData.UpdateColliderData();
    }

    public void SetCapsuleColliderSize(float width, float height)
    {
        Box2DColliderData.Collider.size = new Vector2(width, height);
        Box2DColliderData.TakeDamageCollider.size = new Vector2(width, height);
    }


    public void RecalculateCapsuleColliderCenter()
    {
        float colliderHeightDifference = DefaultColliderData.Height - Box2DColliderData.Collider.size.y;

        Vector2 newColliderCenter = new Vector2(0f, DefaultColliderData.CenterY + (colliderHeightDifference / 2f));

        Box2DColliderData.Collider.offset = newColliderCenter;
        Box2DColliderData.TakeDamageCollider.offset = newColliderCenter;
    }

    public void RecalculateColliderThroughHeight(float height,float center)
    {
        Box2DColliderData.Collider.size = new Vector2(DefaultColliderData.Width, height);
        Box2DColliderData.TakeDamageCollider.size = new Vector2(DefaultColliderData.Width, height);
        float colliderHeightDifference = DefaultColliderData.Height - Box2DColliderData.Collider.size.y;
        Box2DColliderData.Collider.offset = new Vector2(0, center+ (colliderHeightDifference / 2f));
        Box2DColliderData.TakeDamageCollider.size = new Vector2(0, center + (colliderHeightDifference / 2f));
    }
    //public void RecalculateColliderRadius()
    //{
    //    float halfColliderHeight = Box2DColliderData.Collider.size.y / 2f;

    //    if (halfColliderHeight >= Box2DColliderData.Collider.size.x)
    //    {
    //        return;
    //    }

    //    SetCapsuleColliderSize(halfColliderHeight);
    //}
}

