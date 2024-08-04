using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackCombo1State : PlayerAttackState
{

    int lastCountIndex;

    int inputCount = 0;
    public PlayerAttackCombo1State(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ComboChange();
        //StartAnimation(stateMachine.Player.AnimationData.AttackCombo1ParHash);
        AttackAnimIndexChange(stateMachine.Player.AnimationData.AttackCombo1ParHash, attackCountIndex);
        lastCountIndex = attackCountIndex;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
    }

    public override void Exit()
    {
        base.Exit();
        //StopAnimation(stateMachine.Player.AnimationData.AttackCombo1ParHash);
    }
    protected override void OnAttack(InputAction.CallbackContext context)
    {
        if (stateMachine.ReusableData.CanCombo)
        {
            if(inputCount== 0)
            {
                if (attackCountIndex == attackData.AttackCombo1Detail.Length - 1)
                {
                    attackCountIndex = 0;
                    ComboChange();
                    inputCount++;
                    return;
                }
                attackCountIndex++;
                
                
                ComboChange();
                inputCount++;
            }
           
        }
        else
        {
            
        }
    }

    protected void ComboChange()
    {
        stateMachine.ReusableData.AttackForce = attackData.AttackCombo1Detail[attackCountIndex].AttackMoveForce;
        stateMachine.Player.currentAttackDamage = attackData.AttackCombo1Detail[attackCountIndex].Damage;
        stateMachine.Player.targetTakeDamAnim = attackData.AttackCombo1Detail[attackCountIndex].CorrespondAnimation;
        stateMachine.Player.currentDamageForce = attackData.AttackCombo1Detail[attackCountIndex].DamageForce;
    }

    public override void AnimationEnterEvent()
    {
        stateMachine.Player.Rb.AddForce(stateMachine.ReusableData.AttackForce*stateMachine.Player.transform.right,ForceMode2D.Impulse);
        stateMachine.Player.playerInput.PlayerActions.Movement.Disable();
    }

    public override void AnimationExitEvent()
    {
        stateMachine.Player.playerInput.PlayerActions.Movement.Enable();
       
    }
    public override void AnimationTransitionEvent()
    {
        if(lastCountIndex == attackCountIndex||attackCountIndex == 0)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            inputCount = 0;
            stateMachine.Player.playerInput.PlayerActions.Movement.Enable();
        }
        else
        {
            AttackAnimIndexChange(stateMachine.Player.AnimationData.AttackCombo1ParHash, attackCountIndex);
            inputCount = 0;
            lastCountIndex = attackCountIndex;
        }
        
        
    }

    #region Input Methods
    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Attack.started += OnAttack;
    }

    protected override void RemoveInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Attack.started -= OnAttack;
    }
    #endregion
}
