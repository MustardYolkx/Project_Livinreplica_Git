using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopingState : PlayerGroundedState
{
    public PlayerStopingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.StopingParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.StopingParHash);
    }
}
