using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerLayerData 
{
    [field: SerializeField] public LayerMask PlayerDefualtLayer{ get; private set; }

    [field: SerializeField] public LayerMask PlayerSprintLayer { get; private set; }
    [field:SerializeField] public LayerMask GroundLayer { get;private set; }

    [field: SerializeField] public LayerMask DamagableLayer { get; private set; }

    [field: SerializeField] public LayerMask IDamagableLayer { get; private set; }

    public bool ContainsLayer(LayerMask layermask, int layer)
    {
        return (1<<layer &layermask) != 0;
    }

    public bool IsGroundLayer(int layer)
    {
        return ContainsLayer(GroundLayer, layer);
    }

    public bool IsDamagableLayer(int layer)
    {
        return ContainsLayer(DamagableLayer, layer);
    }
}
