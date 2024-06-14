using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageHard : EnemyTakeDamageState
{
    public EnemyTakeDamageHard(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }


    #region State Methods
    public override void Enter()
    {
        base.Enter();
        
        StartAnimation(enemy.animationData.TakeDamageHardParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.animationData.TakeDamageHardParHash);
    }
    #endregion

    #region Animation Methods
    public override void AnimationTransitionTrigger()
    {
        base.AnimationTransitionTrigger();
    }
    #endregion
}
