using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAttackData 
{
    [field:SerializeField] public float[] AttackCombo1Force { get;private set; }

    [field: SerializeField] public float AirAttackForce;
}
