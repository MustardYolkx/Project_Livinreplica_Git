using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    public EnemyStateMachine stateMachine;
    public Enemy enemy;
    protected float startTime;

    
    public EnemyState(EnemyStateMachine enemyStateMachine)
    {
        stateMachine= enemyStateMachine;
        enemy = stateMachine.Enemy;
    }
    public virtual void Enter()
    {
        Debug.Log("EnemyState:" + this.GetType().Name);
        startTime = Time.time;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {

    }
    #region Animation Methods
    public virtual void AnimationEnterTrigger()
    {

    }

    public virtual void AnimationExitTrigger()
    {

    }

    public virtual void AnimationTransitionTrigger()
    {

    }
    public void StartAnimation(int animHash)
    {
        enemy.Animator.SetBool(animHash, true);
    }
    protected void StopAnimation(int animHash)
    {
        enemy.Animator.SetBool(animHash,false);
    }
    #endregion
    #region Main Methods
    protected void Flip()
    {
        if (stateMachine.Enemy.isFacingRight == true)
        {
            
            stateMachine.Enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (stateMachine.Enemy.isFacingRight == false)
        {
            
            stateMachine.Enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    protected void ResetVelocity()
    {
        enemy.Rb.velocity = Vector2.zero;
    }

    protected void AttackCoolDownCount()
    {
        enemy.attackCoolDownTime -= Time.deltaTime;
        if (enemy.attackCoolDownTime < 0)
        {
            enemy.canAttack = true;
        }
        else
        {
            enemy.canAttack = false;
        }
    }
    #endregion
}
