using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyLand : PlayerLandingState
{
    public PlayerHeavyLand(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.HeavyLandParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StartAnimation(stateMachine.Player.AnimationData.HeavyLandParHash);
    }
}
