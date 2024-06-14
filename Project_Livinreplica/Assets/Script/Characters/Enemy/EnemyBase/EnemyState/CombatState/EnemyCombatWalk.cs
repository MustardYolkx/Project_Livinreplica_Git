using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatWalk : EnemyCombatState
{
    public EnemyCombatWalk(EnemyStateMachine enemyStateMachine, Enemy enemyScr) : base(enemyStateMachine, enemyScr)
    {
    }


    #region State Methods
    public override void Enter()
    {
        base.Enter();

        StartAnimation(enemy.animationData.WalkParHash);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //if (enemy.CheckWall() || !enemy.CheckLedge())
        //{
        //    stateMachine.ChangeState(stateMachine.CombatIdleState);
        //}

        if (enemy.CheckPlayer())
        {
            if (enemy.canAttack)

            {
                stateMachine.ChangeState(enemy.Attack1State);

            }
            else
            {
                stateMachine.ChangeState(enemy.CombatIdleState);
            }
        }

        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.Rb.AddForce(enemy.enemySO.EnemyData.WalkSpeed * enemy.transform.right, ForceMode2D.Force);

    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.animationData.WalkParHash);
    }
    #endregion
}
