using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyDefaultState
{
    public EnemyIdle(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }

    #region State Methods

    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        //enemy.currentAttackDamage = enemy.enemySO.AttackData.IdleDamage[0].Damage;
        //enemy.currentDamageForce = enemy.enemySO.AttackData.IdleDamage[0].DamageForce;
        //enemy.targetTakeDamAnim = enemy.enemySO.AttackData.IdleDamage[0].CorrespondAnimation;
        StartAnimation(enemy.animationData.IdleParHash);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //TurnAround();
        startTime += Time.deltaTime;

        //if (enemy.CheckPlayer())
        //{
        //    if (enemy.canAttack)
        //    {
        //        stateMachine.ChangeState(stateMachine.Attack1State);
        //    }

        //}

        //AttackCoolDownCount();
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
