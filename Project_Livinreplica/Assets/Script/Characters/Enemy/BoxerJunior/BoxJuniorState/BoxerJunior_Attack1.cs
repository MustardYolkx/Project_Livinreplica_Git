using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerJunior_Attack1 : EnemyAttack1
{
    private new Enemy_BoxJunior enemy;
    public BoxerJunior_Attack1(EnemyStateMachine enemyStateMachine, Enemy_BoxJunior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
    }
    #region StateMethods
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion
    public override void AnimationTransitionTrigger()
    {
        stateMachine.ChangeState(enemy.BoxerJuniorCombatIdle);
    }
}
