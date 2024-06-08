using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintBackward : PlayerDashState
{
    public PlayerSprintBackward(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        stateMachine.Player.playerInput.PlayerActions.Movement.Disable();
        stateMachine.Player.Rb.AddForce(stateMachine.ReusableData.CurrentSprintForce * -stateMachine.Player.transform.right, ForceMode2D.Impulse);

        StartAnimation(stateMachine.Player.AnimationData.SprintBackwardParHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.playerInput.PlayerActions.Movement.Enable();
        StopAnimation(stateMachine.Player.AnimationData.SprintBackwardParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }


}
