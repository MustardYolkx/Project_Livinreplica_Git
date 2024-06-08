using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerLayerData 
{
    [field:SerializeField] public LayerMask GroundLayer { get;private set; }

    public bool ContainsLayer(LayerMask layermask, int layer)
    {
        return (1<<layer &layermask) != 0;
    }

    public bool IsGroundLayer(int layer)
    {
        return ContainsLayer(GroundLayer, layer);
    }
}
