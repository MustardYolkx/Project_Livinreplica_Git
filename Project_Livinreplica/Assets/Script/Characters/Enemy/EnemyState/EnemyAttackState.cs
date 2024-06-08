using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected int attackCountIndex = 0;
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    #region State Methods

    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        StartAnimation(enemy.animationData.AttackParHash);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        startTime += Time.deltaTime;

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.animationData.AttackParHash);
    }
    #endregion

}
