using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerSeniorTakeDamage : EnemyTakeDamageState
{
    private new Enemy_BoxierSenior enemy;

    public BoxerSeniorTakeDamage(EnemyStateMachine enemyStateMachine, Enemy_BoxierSenior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        this.enemy = enemyScr;
    }

    #region State Methods
    public override void Enter()
    {
        base.Enter();

       
    }

    public override void Exit()
    {
        base.Exit();
        
    }
    #endregion
    #region Animation Methods
    public override void AnimationTransitionTrigger()
    {
        enemy.canTakeDamage = true;
        Debug.Log("Change State");
        stateMachine.ChangeState(enemy.BoxerSeniorIdle);
    }
    #endregion
}
