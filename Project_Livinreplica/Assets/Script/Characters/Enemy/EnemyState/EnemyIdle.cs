using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    #region State Methods
    
    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        StartAnimation(enemy.animationData.IdleParHash);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        TurnAround();
        startTime += Time.deltaTime;

        if (enemy.CheckPlayer())
        {
            if(enemy.canAttack)
            {
                stateMachine.ChangeState(stateMachine.Attack1State);
            }
           
        }

        AttackCoolDownCount();
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

    #region Main Methods
    public void TurnAround()
    {
        if(startTime>2f)
        {
            enemy.isFacingRight = !enemy.isFacingRight;
            Flip();
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }
    #endregion
}
