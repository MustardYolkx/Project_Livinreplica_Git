using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouchAttack : PlayerAttackState
{
    public PlayerCrouchAttack(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Player State Methods
    public override void Enter()
    {
        base.Enter();
        attackCountIndex = 0;
        ChangeValue();
        stateMachine.Player.Rb.AddForce(attackData.CrouchAttackDetail[attackCountIndex].AttackMoveForce, ForceMode2D.Impulse);
        StartAnimation(stateMachine.Player.AnimationData.CrouchAttackParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.CrouchAttackParHash);

    }
    #endregion

    #region Main Methods
    public override void AnimationTransitionEvent()
    {
        if (stateMachine.ReusableData.IsCrouch)
        {

        stateMachine.ChangeState(stateMachine.CrouchState);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public void ChangeValue()
    {
        stateMachine.Player.currentAttackDamage = attackData.CrouchAttackDetail[attackCountIndex].Damage;
        stateMachine.Player.targetTakeDamAnim = attackData.CrouchAttackDetail[attackCountIndex].CorrespondAnimation;
    }
    private void LeaveCrouch(InputAction.CallbackContext obj)
    {
        stateMachine.ReusableData.IsCrouch= false;
    }
    #endregion

    #region Input Methods

    protected override void AddInputActionCallBacks()
    {
        stateMachine.Player.playerInput.PlayerActions.Crouch.canceled += LeaveCrouch;
    }
    protected override void RemoveInputActionCallBacks()
    {
        stateMachine.Player.playerInput.PlayerActions.Crouch.canceled -= LeaveCrouch;
    }

    #endregion
}
