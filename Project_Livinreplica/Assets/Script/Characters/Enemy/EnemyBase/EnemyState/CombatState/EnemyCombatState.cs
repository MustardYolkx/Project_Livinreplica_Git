using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatState : EnemyState
{
    public EnemyCombatState(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.currentAttackDamage = enemy.enemySO.AttackData.IdleDamage[0].Damage;
        enemy.currentDamageForce = enemy.enemySO.AttackData.IdleDamage[0].DamageForce;
        enemy.targetTakeDamAnim = enemy.enemySO.AttackData.IdleDamage[0].CorrespondAnimation;
    }
    public override void LogicUpdate()
    {

        
        base.LogicUpdate();
        if (enemy.canFlip)
        {
             Flip();
            
            
        }

        FaceToPlayer();
        AttackCoolDownCount();
    }


}
