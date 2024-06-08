using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerMovingState
{
    public PlayerRunState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Player State Methods
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.RunParHash);
        stateMachine.ReusableData.MovementSpeedModifier = groundedData.RunData.SpeedModifier;
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpForceRun;
        stateMachine.ReusableData.CurrentSprintForce = groundedData.SprintData.SprintForce;
        StopAnimation(stateMachine.Player.AnimationData.RunParHash);
    }

    #endregion

    #region Main Methods

    #endregion
    #region Input Method
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Jump.started += JumpRunStart;
    }

    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Jump.started -= JumpRunStart;
    }

    #endregion
}
