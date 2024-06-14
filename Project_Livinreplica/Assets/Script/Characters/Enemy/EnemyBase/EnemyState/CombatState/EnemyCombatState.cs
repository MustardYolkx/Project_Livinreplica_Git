using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatState : EnemyState
{
    public EnemyCombatState(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
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
