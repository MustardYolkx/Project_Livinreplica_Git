using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerGroundedState
{

    public PlayerIdleState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }


    #region PlayerState Methods
    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = 0f;
        
        ResetVelocity();
        StartAnimation(stateMachine.Player.AnimationData.IdleParHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(stateMachine.ReusableData.MovementInput == Vector2.zero) 
        {
            return;
        }
        OnMove();
        
        stateMachine.ChangeState(stateMachine.WalkState);
    }

   

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpForceStay;
        //stateMachine.ReusableData.MovementSpeedModifier = airborneData.JumpStaySpeedModifier;
        stateMachine.ReusableData.CurrentSprintForce = groundedData.SprintData.SprintForce;
        StopAnimation(stateMachine.Player.AnimationData.IdleParHash);
    }
    #endregion

    #region Main Methods

    #endregion

    #region Idle State Methods
    private void OnMove()
    {
        stateMachine.ChangeState(stateMachine.WalkState);
    }


    #endregion

    #region Input Method
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Running.started += RunningInputStart;
        stateMachine.Player.playerInput.PlayerActions.Jump.started += JumpStart;

    }

    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Running.started -= RunningInputStart;
        stateMachine.Player.playerInput.PlayerActions.Jump.started -= JumpStart;

    }

    #endregion
}
