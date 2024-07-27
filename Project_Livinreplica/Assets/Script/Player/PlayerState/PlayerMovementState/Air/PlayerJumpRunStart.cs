using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpRunStart : PlayerAirborneState
{
    float time = 0f;
    public PlayerJumpRunStart(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        time = 0;
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
        time += Time.deltaTime;
        JumpAddForce();
    }
    private void JumpAddForce()
    {
        if (stateMachine.ReusableData.JumpPrepare)
        {
            if (time < 0.5f)
            {
                stateMachine.Player.Rb.AddForce(airborneData.JumpForceAdd * Vector2.up, ForceMode2D.Force);
            }

        }
    }
    public void Jump()
    {
        Vector2 jumpForce = stateMachine.ReusableData.CurrentJumpForce;
        Vector2 playerFace = stateMachine.Player.transform.right;

        jumpForce.x *= playerFace.x;
        ResetVelocity();
        stateMachine.Player.Rb.AddForce(jumpForce,ForceMode2D.Impulse);
    }

    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();

        stateMachine.Player.playerInput.PlayerActions.Jump.canceled += JumpCancel;
        //stateMachine.Player.playerInput.PlayerActions.Attack.started += OnAirAttack;
    }



    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();

        stateMachine.Player.playerInput.PlayerActions.Jump.canceled -= JumpCancel;
        //stateMachine.Player.playerInput.PlayerActions.Attack.started -= OnAirAttack;
    }

    public override void AnimationComboStart()
    {
        stateMachine.ReusableData.CanCombo = true;
    }

    public override void AnimationComboStop()
    {
        stateMachine.ReusableData.CanCombo = false;
    }
    #endregion
}

