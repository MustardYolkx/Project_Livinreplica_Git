using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Custom/Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyData EnemyData { get; private set; }

    [field: SerializeField] public EnemyLayerData LayerData { get; private set; }

    [field: SerializeField] public EnemyAttackData AttackData { get; private set; }

    [field: SerializeField] public EnemyDetectedData EnemyDetectedData { get; private set;}
}
