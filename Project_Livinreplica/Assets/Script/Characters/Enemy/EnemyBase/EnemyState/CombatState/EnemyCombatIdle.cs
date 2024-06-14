using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatIdle : EnemyCombatState
{
    public EnemyCombatIdle(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }


    #region State Methods

    public override void Enter()
    {
        base.Enter();
        FaceToPlayer();
        ResetVelocity();
        StartAnimation(enemy.animationData.IdleParHash);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //TurnAround();
        startTime += Time.deltaTime;

        if (enemy.CheckPlayer())
        {
            if (enemy.canAttack)
            {
                stateMachine.ChangeState(enemy.Attack1State);
            }

        }
        else
        {
            stateMachine.ChangeState(enemy.CombatWalkState);

        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.animationData.IdleParHash);
    }
    #endregion


}
