using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoxerBossAttackData : EnemyAttackData
{
    [field: SerializeField] public EnemyAttackDetail[] Combo1 { get; private set; }
    [field: SerializeField] public EnemyAttackDetail[] Combo2 { get; private set; }

    [field: SerializeField] public EnemyAttackDetail[] DoubleHammer { get; private set; }

    [field: SerializeField] public EnemyAttackDetail[] StraightPunch { get; private set; }
    [field: SerializeField] public EnemyAttackDetail[] DownPunch { get; private set; }

    
}
