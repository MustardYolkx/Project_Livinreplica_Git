using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected int attackCountIndex = 0;

    public EnemyAttackState(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }


    #region State Methods

    public override void Enter()
    {
        base.Enter();
        enemy.canFlip= false;
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
        enemy.canFlip = true;
        StopAnimation(enemy.animationData.AttackParHash);
    }
    #endregion

}
