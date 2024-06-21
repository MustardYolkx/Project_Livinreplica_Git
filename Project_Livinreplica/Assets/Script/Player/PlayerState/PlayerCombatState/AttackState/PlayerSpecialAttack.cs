using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpecialAttack : PlayerAttackState
{
    public PlayerSpecialAttack(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    #region state methods
    public override void Enter()
    {
        base.Enter();
        attackCountIndex = 0;
        ChangeValue();
        stateMachine.Player.Rb.AddForce(attackData.SpecialAttackDetail[attackCountIndex].AttackMoveForce, ForceMode2D.Impulse);
        StartAnimation(stateMachine.Player.AnimationData.SpecialAttackParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.SpecialAttackParHash);
    }
    #endregion
    #region Main Methods
    public void ChangeValue()
    {
        stateMachine.Player.currentAttackDamage = attackData.SpecialAttackDetail[attackCountIndex].Damage;
        stateMachine.Player.targetTakeDamAnim = attackData.SpecialAttackDetail[attackCountIndex].CorrespondAnimation;
    }

    private void StopSpecialAttack(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    #endregion

    #region Animation Methods
    public override void AnimationTransitionEvent()
    {

            stateMachine.ChangeState(stateMachine.IdleState);
        
    }
    #endregion

    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        stateMachine.Player.playerInput.PlayerActions.SpecialAttack.started += StopSpecialAttack;
    }



    protected override void RemoveInputActionCallBacks()
    {
        stateMachine.Player.playerInput.PlayerActions.SpecialAttack.started -= StopSpecialAttack;
    }
    #endregion
}
