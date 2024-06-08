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
        stateMachine.ReusableData.CanFlip = false;
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        ResetVelocity();
        StartAnimation(stateMachine.Player.AnimationData.CrouchParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.ReusableData.CanFlip = true;
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
    #endregion

    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Crouch.canceled += LeaveCrouch;
    }

    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Crouch.canceled -= LeaveCrouch;
    }
    #endregion


}
