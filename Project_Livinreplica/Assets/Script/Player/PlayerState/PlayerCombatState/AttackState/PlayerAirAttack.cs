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
        attackCountIndex= 0;
        ChangeValue();
        stateMachine.Player.Rb.AddForce(attackData.AirAttackDetail[attackCountIndex].AttackMoveForce , ForceMode2D.Impulse);
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
        if (stateMachine.Player.CheckGround())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else
        {

            stateMachine.ChangeState(stateMachine.Falling);
        }
    }

    public void ChangeValue()
    {
        stateMachine.Player.currentAttackDamage = attackData.AirAttackDetail[attackCountIndex].Damage;
        stateMachine.Player.targetTakeDamAnim = attackData.AirAttackDetail[attackCountIndex].CorrespondAnimation;
        stateMachine.Player.currentDamageForce = attackData.AttackCombo1Detail[attackCountIndex].DamageForce;
    }
    #endregion
}
