using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouchState : PlayerGroundedState
{
    public PlayerCrouchState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    #region Player State Methods
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.CrouchParHash);
        stateMachine.ReusableData.CanFlip = false;
        stateMachine.ReusableData.MovementSpeedModifier = 0f;
        stateMachine.Player.ResizableBox2DCollider.RecalculateColliderThroughHeight(stateMachine.Player.ResizableBox2DCollider.DefaultColliderData.CrouchHeight, stateMachine.Player.ResizableBox2DCollider.DefaultColliderData.CrouchCenterY);

        ResetVelocity();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.ReusableData.CanFlip = true;
        stateMachine.Player.ResizableBox2DCollider.RecalculateColliderThroughHeight(stateMachine.Player.ResizableBox2DCollider.DefaultColliderData.Height, stateMachine.Player.ResizableBox2DCollider.DefaultColliderData.CenterY);
        StopAnimation(stateMachine.Player.AnimationData.CrouchParHash);
    }


    #endregion

    #region Main Methods
    private void LeaveCrouch(InputAction.CallbackContext context)
    {
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }
    private void CrouchAttack(InputAction.CallbackContext obj)
    {

        stateMachine.ChangeState(stateMachine.PlayerCrouchAttack);
    }
    #endregion

    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        
        stateMachine.Player.playerInput.PlayerActions.Crouch.canceled += LeaveCrouch;
        stateMachine.Player.playerInput.PlayerActions.Attack.started += CrouchAttack;
    }

    

    protected override void RemoveInputActionCallBacks()
    {
        
        stateMachine.Player.playerInput.PlayerActions.Crouch.canceled -= LeaveCrouch;
        stateMachine.Player.playerInput.PlayerActions.Attack.started -= CrouchAttack;
    }
    #endregion


}
