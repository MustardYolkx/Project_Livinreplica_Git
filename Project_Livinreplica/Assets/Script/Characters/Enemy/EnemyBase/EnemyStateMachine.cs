using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState CurrentState { get; private set; }
    public Enemy Enemy { get; private set; }

    
    public EnemyStateMachine(Enemy enemy)
    {
        Enemy= enemy;
        
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
    public void AnimationComboChange()
    {
        CurrentState?.AnimationComboChange();
    }
}
