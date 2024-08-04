using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAttackData 
{
   

    [field: SerializeField] public float AirAttackForce;

    [field: SerializeField] public AttackDetails[] AttackCombo1Detail { get; private set; }

    [field: SerializeField] public AttackDetails[] AirAttackDetail { get; private set; }

    [field: SerializeField] public AttackDetails[] CrouchAttackDetail { get; private set; }

    [field: SerializeField] public AttackDetails[] SpecialAttackDetail { get; private set; }
}
[Serializable]
public struct AttackDetails
{
    public string Name;
    public float Damage;
    public Vector2 AttackMoveForce;
    public float DamageForce;
    public string CorrespondAnimation;
    
}

