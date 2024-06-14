using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldState : EnemyCombatState
{
    public EnemyShieldState(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.isSheild= true;
        StartAnimation(enemy.animationData.DefendParHash);

    }

    public override void Exit()
    {
        base.Exit();
        enemy.isSheild= false;
        StopAnimation(enemy.animationData.DefendParHash);
    }

 
}


