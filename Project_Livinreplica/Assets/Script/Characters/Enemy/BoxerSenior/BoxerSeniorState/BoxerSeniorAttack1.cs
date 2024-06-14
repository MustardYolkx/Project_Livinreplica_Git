using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerSeniorAttack1 : EnemyAttack1
{
    private new Enemy_BoxierSenior enemy;
    public BoxerSeniorAttack1(EnemyStateMachine enemyStateMachine, Enemy_BoxierSenior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
    }
    #region State Methods


    public override void Enter()
    {
        base.Enter();
        enemy.isSheild = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }



    #endregion

    public override void AnimationTransitionTrigger()
    {
        stateMachine.ChangeState(enemy.BoxerSeniorIdle);
    }
}
