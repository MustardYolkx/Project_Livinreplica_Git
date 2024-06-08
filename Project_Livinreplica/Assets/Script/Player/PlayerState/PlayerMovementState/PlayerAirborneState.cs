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

        stateMachine.ChangeState(stateMachine.SprintForward);
    
    }


    #endregion
}
