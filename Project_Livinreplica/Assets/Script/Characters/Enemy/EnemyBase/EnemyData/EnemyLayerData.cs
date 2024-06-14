using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyLayerData 
{
    [field: SerializeField] public LayerMask GroundLayer { get; private set; }

    [field: SerializeField] public LayerMask PlayerLayer { get; private set; }
    [field: SerializeField] public LayerMask IDamagableLayer { get; private set; }
    [field: SerializeField] public LayerMask PlayerAttack { get; private set; }

    public bool ContainsLayer(LayerMask layermask, int layer)
    {
        return (1 << layer & layermask) != 0;
    }

    public bool IsGroundLayer(int layer)
    {
        return ContainsLayer(GroundLayer, layer);
    }

    public bool IsPlayerLayer(int layer)
    {
        return ContainsLayer(PlayerLayer, layer);
    }

    public bool IsPlayerAttack(int layer)
    {
        return ContainsLayer(PlayerAttack, layer);
    }
}
