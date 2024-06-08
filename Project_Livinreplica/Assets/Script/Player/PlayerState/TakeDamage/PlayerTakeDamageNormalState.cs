using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamageNormalState : PlayerTakeDamageState
{
    public PlayerTakeDamageNormalState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        stateMachine.ReusableData.CanTakeDamage = false;
        StartAnimation(stateMachine.Player.AnimationData.TakeDamageNormalParHash);
    }

    public override void Exit()
    { 
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.TakeDamageNormalParHash);
    }

    public override void AnimationTransitionEvent()
    {
        stateMachine.ReusableData.CanTakeDamage = true;
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}
