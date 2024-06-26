using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResizableBox2DCollider : ResizableBoix2DCollider
{
    [field: SerializeField] public PlayerTriggerColliderData TriggerColliderData { get; private set; }

    protected override void OnInitialize()
    {
        base.OnInitialize();

        TriggerColliderData.Initialize();
    }
}
