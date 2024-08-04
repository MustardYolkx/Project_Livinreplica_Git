using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttackData 
{
    [field: SerializeField] public EnemyAttackDetail[] IdleDamage { get; private set; }
    [field: SerializeField] public EnemyAttackDetail[] Attack1 { get; private set; }

    [Serializable]
    public struct EnemyAttackDetail
    {
        public string Name;
        public float Damage;
        public float coolDownTime;
        public Vector2 AttackMoveForce;
        public float DamageForce;
        public string CorrespondAnimation;
    }
}
