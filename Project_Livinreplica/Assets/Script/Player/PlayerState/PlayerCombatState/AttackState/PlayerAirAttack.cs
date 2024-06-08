using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttack : PlayerAttackState
{
    public PlayerAirAttack(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Player State Methods
    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.Rb.AddForce(attackData.AirAttackForce * Vector2.up, ForceMode2D.Impulse);
        StartAnimation(stateMachine.Player.AnimationData.AirAttackParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AirAttackParHash);
        
    }
    #endregion

    #region Main Methods
    public override void AnimationTransitionEvent()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    #endregion
}
