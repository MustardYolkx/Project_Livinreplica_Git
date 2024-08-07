using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossCombatWalk : EnemyCombatState
{
    public new Enemy_BoxerBoss enemy;
    public BoxerBossCombatWalk(EnemyStateMachine enemyStateMachine, Enemy_BoxerBoss enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
    }

    #region State Methods
    public override void Enter()
    {
        base.Enter();
        enemy.canFlip = true;
        StartAnimation(enemy.animationData.WalkParHash);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        FaceToPlayer();
        
        if (enemy.CheckPlayer())
        {
            if (enemy.canAttack)

            {
                
                RandomAttackIndex();

            }
            else
            {
                stateMachine.ChangeState(enemy.BoxerBossCombatIdle);
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

    #region Main Methods
    public void RandomAttackIndex()
    {
        int index = Random.Range(0, 5);
        if(index == 0)
        {
            stateMachine.ChangeState(enemy.BoxerBossCombo1);
        }
        else if(index == 1)
        {
            stateMachine.ChangeState(enemy.BoxerBossCombo2);
        }
        else if(index == 2)
        {
            stateMachine.ChangeState(enemy.BoxerBossDoubleHammer);
        }
        else if (index == 3)
        {
            stateMachine.ChangeState(enemy.BoxerBossDownPunch);
        }
        else if(index == 4)
        {
            stateMachine.ChangeState(enemy.BoxereBossStraightPunch);
        }
    }
    #endregion
}
