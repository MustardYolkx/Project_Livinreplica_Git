using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateMachine 
{
    protected PlayerState currentState { get; private set; }

    public void ChangeState(PlayerState playerState)
    {
        
        currentState?.Exit();
        currentState = playerState;
        currentState?.Enter();
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void LogicUpdate()
    {
        currentState?.LogicUpdate();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }

    public void OnTriggerEnter(Collider2D collider)
    {
        currentState?.OnTriggerEnter(collider);
    }

    public void OnTriggerExit(Collider2D collider)
    {
        currentState?.OnTriggerExit(collider);
    }

    public void AnimationTransitionEvent()
    {
        currentState?.AnimationTransitionEvent();
    }
    public void AnimationEnterEvent()
    {
        currentState?.AnimationEnterEvent();
    }
    public void AnimationExitEvent()
    {
        currentState?.AnimationExitEvent();
    }

    public void AnimationComboStartEvent()
    {
        currentState?.AnimationComboStart();
    }

    public void AnimationComboStopEvent()
    {
        currentState?.AnimationComboStop();
    }
}
