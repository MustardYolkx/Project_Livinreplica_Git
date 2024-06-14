using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageState : EnemyState
{
    public EnemyTakeDamageState(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
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
        enemy.canTakeDamage = true;
        StopAnimation(stateMachine.Enemy.animationData.TakeDamageParHash);
    }
    #endregion


}
