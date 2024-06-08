using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : EnemyAttackState
{
    public EnemyAttack1(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    #region State Methods

    public override void Enter()
    {
        base.Enter();
        enemy.attackCoolDownTime = 3f;
        enemy.currentAttackDamage = enemy.enemySO.AttackData.Attack1[attackCountIndex].Damage;
        enemy.targetTakeDamAnim = enemy.enemySO.AttackData.Attack1[attackCountIndex].CorrespondAnimation;
        StartAnimation(enemy.animationData.Attack1ParHash);
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
        StopAnimation(enemy.animationData.Attack1ParHash);
    }
    #endregion

    #region Animation Methods
    public override void AnimationTransitionTrigger()
    {
        
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    #endregion
}
