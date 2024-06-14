using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttackData 
{
    [field: SerializeField] public EnemyAttackDetail[] Attack1 { get; private set; }

    [Serializable]
    public struct EnemyAttackDetail
    {
        public string Name;
        public float Damage;
        public float coolDownTime;
        public Vector2 AttackMoveForce;
        public string CorrespondAnimation;
    }
}
