using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerJunior_CombatIdle : EnemyCombatState
{
    private new Enemy_BoxJunior enemy;
    public BoxerJunior_CombatIdle(EnemyStateMachine enemyStateMachine, Enemy_BoxJunior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
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
                stateMachine.ChangeState(enemy.BoxerJuniorAttack1);
            }

        }
        else
        {
            stateMachine.ChangeState(enemy.BoxerJunior_CombatWalk);

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
