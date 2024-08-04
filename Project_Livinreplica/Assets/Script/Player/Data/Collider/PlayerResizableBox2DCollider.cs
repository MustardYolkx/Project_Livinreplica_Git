using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResizableBox2DCollider : ResizableBoix2DCollider
{
    

    protected override void OnInitialize()
    {
        base.OnInitialize();

        TriggerColliderData.Initialize();
    }
}
