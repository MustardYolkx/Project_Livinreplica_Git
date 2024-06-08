using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyState
{
    public EnemyWalk(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
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
        
        if (enemy.CheckWall() || !enemy.CheckLedge())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }

        if(enemy.CheckPlayer() )
        {
            if (enemy.canAttack)
                
            {
            stateMachine.ChangeState(stateMachine.Attack1State);

            }
        }
        AttackCoolDownCount();

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
