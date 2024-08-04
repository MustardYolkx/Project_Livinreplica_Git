using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerJunior_CombatWalk : EnemyCombatState
{
    private new Enemy_BoxJunior enemy;
    public BoxerJunior_CombatWalk(EnemyStateMachine enemyStateMachine, Enemy_BoxJunior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
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
                stateMachine.ChangeState(enemy.BoxerJuniorAttack1);

            }
            else
            {
                stateMachine.ChangeState(enemy.BoxerJuniorCombatIdle);
            }
        }



    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Vector3 horizontalVelocity = GetHorizontalVelocity();
        enemy.Rb.AddForce(enemy.enemySO.EnemyData.WalkSpeed * enemy.transform.right - horizontalVelocity, ForceMode2D.Force);
        //enemy.Rb.AddForce(enemy.enemySO.EnemyData.WalkSpeed * enemy.transform.right, ForceMode2D.Force);

    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.animationData.WalkParHash);
    }
    #endregion
}
