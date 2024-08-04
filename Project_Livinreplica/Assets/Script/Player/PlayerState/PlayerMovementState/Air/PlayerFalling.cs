using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFalling : PlayerAirborneState
{
    float time = 0f;
    public PlayerFalling(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        time = 0;
        //stateMachine.ReusableData.CanTakeDamage = true;
        StartAnimation(stateMachine.Player.AnimationData.FallingParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.FallingParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        time += Time.deltaTime;
        

    }

    #region Reusable Methods

    #endregion

    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();

        //stateMachine.Player.playerInput.PlayerActions.Jump.canceled += JumpCancel;
        //stateMachine.Player.playerInput.PlayerActions.Attack.started += OnAirAttack;
    }



    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();

        //stateMachine.Player.playerInput.PlayerActions.Jump.canceled -= JumpCancel;
        //stateMachine.Player.playerInput.PlayerActions.Attack.started -= OnAirAttack;
    }


    #endregion
}
