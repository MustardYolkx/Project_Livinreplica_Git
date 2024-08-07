using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAirborneState : PlayerMovementState
{
    public PlayerAirborneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.ReusableData.MovementSpeedModifier = airborneData.JumpStaySpeedModifier;
        StartAnimation(stateMachine.Player.AnimationData.AirborneParHash);
        stateMachine.ReusableData.CurrentSprintForce = groundedData.SprintData.SprintForce;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AirborneParHash);
    }



    #region
    protected override void OnContactWithGround(Collider2D collider)
    {
        stateMachine.ChangeState(stateMachine.LightLand);
       
    }

    protected override void OnSprint(InputAction.CallbackContext obj)
    {

        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.SprintBackward);
            return;
        }

        stateMachine.ChangeState(stateMachine.SprintForward);

    }


    #endregion
    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();

        //stateMachine.Player.playerInput.PlayerActions.Jump.canceled += JumpCancel;
        stateMachine.Player.playerInput.PlayerActions.Attack.started += OnAirAttack;
    }



    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();

        //stateMachine.Player.playerInput.PlayerActions.Jump.canceled -= JumpCancel;
        stateMachine.Player.playerInput.PlayerActions.Attack.started -= OnAirAttack;
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
