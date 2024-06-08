using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerAttackState : PlayerState
{

    protected int attackCountIndex;
    protected PlayerMovementStateMachine stateMachine;
    

    protected PlayerAttackData attackData;

    protected EnemyTakeDamageState targetEnemyState;
    public PlayerAttackState(PlayerMovementStateMachine playerMovementStateMachine) 
    {
        stateMachine= playerMovementStateMachine;
        attackData = stateMachine.Player.data.AttackData;
    }



    #region Player State Methods
    public override void Enter()
    {
        ResetVelocity();
        AddInputActionCallBacks();
        attackCountIndex= 0;
        StartAnimation(stateMachine.Player.AnimationData.AttackParHash);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        RemoveInputActionCallBacks();
        StopAnimation(stateMachine.Player.AnimationData.AttackParHash);
        
    }
    #endregion

    #region Main Methods

    #endregion

    #region Reuasble Methods
    protected virtual void AttackAnimIndexChange(int animationHash,int counter)
    {
        stateMachine.Player.Animator.SetInteger(animationHash, counter);
    }



    public override void AnimationComboStart()
    {
        stateMachine.ReusableData.CanCombo = true;
    }

    public override void AnimationComboStop()
    {
        stateMachine.ReusableData.CanCombo = false;
    }
    protected virtual void OnAttack(InputAction.CallbackContext context)
    {
       
    }
    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }

    protected void ResetVelocity()
    {
        stateMachine.Player.Rb.velocity = Vector2.zero;
    }


    #endregion

    #region Input Methods
    protected virtual void AddInputActionCallBacks()
    {

        
    }

    

    protected virtual void RemoveInputActionCallBacks()
    {
        

    }
    #endregion
}
