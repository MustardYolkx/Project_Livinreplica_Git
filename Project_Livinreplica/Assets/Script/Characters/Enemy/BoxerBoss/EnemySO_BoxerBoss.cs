using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_BoxerBoss", menuName = "Custom/Characters/Enemy_BoxerBoss")]
public class EnemySO_BoxerBoss : EnemySO
{
    [field:SerializeField]public BoxerBossAttackData BoxerBossAttackData { get; private set; }
}
