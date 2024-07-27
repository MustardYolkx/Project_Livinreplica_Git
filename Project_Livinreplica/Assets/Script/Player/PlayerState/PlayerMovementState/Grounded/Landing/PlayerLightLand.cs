using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightLand : PlayerLandingState
{
    float time;
    public PlayerLightLand(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.ReusableData.MovementSpeedModifier= 0;
        time = 0;
        ResetVelocity();
        StartAnimation(stateMachine.Player.AnimationData.LightLandParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        time += Time.deltaTime;

    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.LightLandParHash);
    }

    public override void AnimationTransitionEvent()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    public override void AnimationComboStart()
    {
        stateMachine.ReusableData.CanCombo = true;
    }

    public override void AnimationComboStop()
    {
        stateMachine.ReusableData.CanCombo = false;
    }
}
