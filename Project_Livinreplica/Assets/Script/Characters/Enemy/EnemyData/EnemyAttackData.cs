using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttackData 
{
    [field: SerializeField] public AttackDetails[] Attack1 { get; private set; }
}
