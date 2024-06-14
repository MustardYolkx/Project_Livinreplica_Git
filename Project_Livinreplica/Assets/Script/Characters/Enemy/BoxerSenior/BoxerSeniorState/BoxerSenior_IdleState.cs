using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerSenior_IdleState : EnemyCombatIdle
{
    private new Enemy_BoxierSenior enemy;

    public BoxerSenior_IdleState(EnemyStateMachine enemyStateMachine, Enemy_BoxierSenior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        this.enemy = enemyScr;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.isSheild= true;
        FaceToPlayer();
        ResetVelocity();
        StartAnimation(enemy.animationData.IdleParHash);
    }
    public override void LogicUpdate()
    {

        base.LogicUpdate();
        CheckDefenseState();
        //TurnAround();
        startTime += Time.deltaTime;

        if (enemy.CheckPlayer())
        {
            if (enemy.canAttack)
            {
                stateMachine.ChangeState(enemy.BoxerSeniorAttack1);
            }

        }
        else
        {
            stateMachine.ChangeState(enemy.BoxerSeniorDefend);

        }

    }

    public override void Exit()
    {
        base.Exit();
        enemy.isSheild= false;
    }
    #region Main Methods
    public void CheckDefenseState()
    {
        if (enemy.CheckPlayer(10))
        {
            enemy.isSheild = true;
        }
        else
        {
            enemy.isSheild = false;
        }
    }
    #endregion
}
