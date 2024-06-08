using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerData playerData;
    public PlayerMovementState PlayerMovementState { get; private set; }
    public PlayerState()
    {
        
    }

    
    public virtual void Enter()
    {
        Debug.Log("Player State:" + this.GetType().Name);
    }

    public virtual void HandleInput()
    {

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

    public virtual void OnTriggerEnter(Collider2D collider)
    {

    }

    public virtual void OnTriggerExit(Collider2D collider)
    {

    }

    public virtual void AnimationTransitionEvent()
    {

    }

    public virtual void AnimationEnterEvent()
    {

    }

    public virtual void AnimationExitEvent()
    {

    }

    public virtual void AnimationComboStart()
    {
        
    }

    public virtual void AnimationComboStop()
    {
        
    }
}
