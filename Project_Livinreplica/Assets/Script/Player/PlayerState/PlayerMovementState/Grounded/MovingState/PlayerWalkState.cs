using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerMovingState
{
    public PlayerWalkState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Player State Methods
    public override void Enter()
    {
        base.Enter();
        stateMachine.ReusableData.MovementSpeedModifier = groundedData.WalkData.SpeedModifier;
        stateMachine.ReusableData.RunningCheckTime = 0;

        StartAnimation(stateMachine.Player.AnimationData.WalkParHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        ToRun();

    }

   

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpForceNormal;
        stateMachine.ReusableData.MovementSpeedModifier = airborneData.JumpNormalSpeedModifier;
        stateMachine.ReusableData.CurrentSprintForce = groundedData.SprintData.SprintForce;
        StopAnimation(stateMachine.Player.AnimationData.WalkParHash);
    }


    #endregion

    #region Walk State Methods
    private void ToRun()
    {
        if(stateMachine.ReusableData.IsRunning)
        {
            stateMachine.ChangeState(stateMachine.RunState);
        }
    }
    #endregion

    #region Main Methods



    #endregion
    #region Input Method
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Jump.started += JumpStart;

    }

    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Jump.started -= JumpStart;
    }

    #endregion
}
