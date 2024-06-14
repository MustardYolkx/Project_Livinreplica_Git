using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossTakeDamage : EnemyTakeDamageState
{
    public new Enemy_BoxerBoss enemy;
    public BoxerBossTakeDamage(EnemyStateMachine enemyStateMachine, Enemy_BoxerBoss enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit() { base.Exit();}

    public override void AnimationTransitionTrigger()
    {
        stateMachine.ChangeState(enemy.BoxerBossCombatIdle);
    }
}

    

