using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageState : EnemyState
{
    public EnemyTakeDamageState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    #region State Methods
    public override void Enter()
    {
        base.Enter();
        enemy.canTakeDamage = false;
        StartAnimation(stateMachine.Enemy.animationData.TakeDamageParHash);
        
    }

    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(stateMachine.Enemy.animationData.TakeDamageParHash);
    }
    #endregion

    #region Animation Methods
    public override void AnimationTransitionTrigger()
    {
        enemy.canTakeDamage = true;
        stateMachine.ChangeState(stateMachine.IdleState);

    }
    #endregion
}
