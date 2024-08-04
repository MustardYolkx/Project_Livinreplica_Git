using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerTriggerColliderData 
{
    
    
        [field: SerializeField] public CapsuleCollider2D GroundCheckCollider { get; private set; }
        [field: SerializeField] public CapsuleCollider2D TakeDamageCollider { get; private set; }

    public Vector2 GroundCheckColliderWidth { get; private set; }

        public void Initialize()
        {
        //GroundCheckColliderWidth = GroundCheckCollider.size.x;
    }
    
}
