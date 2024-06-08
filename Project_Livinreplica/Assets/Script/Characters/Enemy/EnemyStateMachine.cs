using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState CurrentState { get; private set; }
    public Enemy Enemy { get; private set; }

    public EnemyIdle IdleState { get; private set; }

    public EnemyWalk WalkState { get; private set; }

    public EnemyTakeDamageHard TakeDamageHardState { get; private set; }

    public EnemyTakeDamageNormalState TakeDamageNormalState { get; private set; }

    public EnemyAttackState AttackState { get; private set; }

    public EnemyAttack1 Attack1State { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy= enemy;
        IdleState= new EnemyIdle(this);
        WalkState= new EnemyWalk(this);
        TakeDamageHardState= new EnemyTakeDamageHard(this);
        TakeDamageNormalState = new EnemyTakeDamageNormalState(this);
        Attack1State = new EnemyAttack1(this);
        AttackState = new EnemyAttackState(this);
    }
    public void ChangeState( EnemyState state)
    {
        CurrentState?.Exit();

        CurrentState = state;

        CurrentState.Enter();
    }
    public void Enter()
    {
        CurrentState?.Enter();
    }

    public void LogicUpdate()
    {
        CurrentState?.LogicUpdate();
    }

    public void PhysicsUpdate()
    {
        CurrentState?.PhysicsUpdate();
    }
    public void Exit()
    {
        CurrentState?.Exit();
    }

    public void AnimationEnterTrigger()
    {
        CurrentState?.AnimationEnterTrigger();
    }

    public void AnimationExitTrigger()
    {
        CurrentState?.AnimationExitTrigger();
    }

    public void AnimationTransitionTrigger()
    {
        CurrentState?.AnimationTransitionTrigger();
    }
}
