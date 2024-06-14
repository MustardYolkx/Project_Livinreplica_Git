using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageNormalState : EnemyTakeDamageState
{
    public EnemyTakeDamageNormalState(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }


    #region State Methods
    public override void Enter()
    {
        base.Enter();
        
        StartAnimation(enemy.animationData.TakeDamageNormalParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.animationData.TakeDamageNormalParHash);
    }
    #endregion

    #region Animation Methods
    public override void AnimationTransitionTrigger()
    {
        enemy.canTakeDamage = true;
        stateMachine.ChangeState(enemy.CombatIdleState);

    }
    #endregion
}
