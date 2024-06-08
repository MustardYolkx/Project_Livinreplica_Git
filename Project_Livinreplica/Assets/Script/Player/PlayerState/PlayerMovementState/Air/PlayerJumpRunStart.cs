using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpRunStart : PlayerAirborneState
{
    public PlayerJumpRunStart(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = airborneData.JumpRunSpeedModifier;
        Jump();
        StartAnimation(stateMachine.Player.AnimationData.JumpRunStartParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.JumpRunStartParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public void Jump()
    {
        Vector2 jumpForce = stateMachine.ReusableData.CurrentJumpForce;
        Vector2 playerFace = stateMachine.Player.transform.right;

        jumpForce.x *= playerFace.x;
        ResetVelocity();
        stateMachine.Player.Rb.AddForce(jumpForce,ForceMode2D.Impulse);
    }


}
