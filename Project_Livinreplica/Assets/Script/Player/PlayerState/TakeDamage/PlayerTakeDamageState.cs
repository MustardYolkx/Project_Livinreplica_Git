using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamageState : PlayerState
{
    protected PlayerMovementStateMachine stateMachine;
    public PlayerTakeDamageState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;
       
    }

    #region Player State
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.TakeDamageParHash);
    }

    public override void Exit() 
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.TakeDamageParHash);
    }
    #endregion
    #region Reusable Methods
    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }

    protected void ResetVelocity()
    {
        stateMachine.Player.Rb.velocity = Vector2.zero;
    }
    #endregion
}
