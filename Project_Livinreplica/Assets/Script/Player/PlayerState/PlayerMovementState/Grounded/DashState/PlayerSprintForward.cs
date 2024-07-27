using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintForward : PlayerDashState
{
    public PlayerSprintForward(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //ResetVelocity();
        //TO DO:
        stateMachine.Player.playerInput.PlayerActions.Movement.Disable();
        stateMachine.Player.Rb.AddForce(stateMachine.ReusableData.CurrentSprintForce*stateMachine.Player.transform.right,ForceMode2D.Impulse);
        StartAnimation(stateMachine.Player.AnimationData.SprintForwardParHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.playerInput.PlayerActions.Movement.Enable();
        StartAnimation(stateMachine.Player.AnimationData.SprintForwardParHash);
    }

   
}
