using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerSenior_DefendState : EnemyShieldState
{
    private new Enemy_BoxierSenior enemy;
    public BoxerSenior_DefendState(EnemyStateMachine enemyStateMachine, Enemy_BoxierSenior enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy= enemyScr;
    }
    #region State Methods
    public override void Enter()
    {
        base.Enter();
        enemy.canFlip= true;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckDefenseState();
        if (enemy.CheckPlayer())
        {
            if (enemy.canAttack)

            {
                stateMachine.ChangeState(enemy.BoxerSeniorAttack1);

            }
            else
            {
                stateMachine.ChangeState(enemy.BoxerSeniorIdle);
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
        enemy.isSheild = false;
    }
    #endregion

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
