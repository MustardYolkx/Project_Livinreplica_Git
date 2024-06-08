using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementState : PlayerState
{
    protected PlayerMovementStateMachine stateMachine;

    protected PlayerGroundedData groundedData;

    protected PlayerAirborneData airborneData;
    public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
       stateMachine= playerMovementStateMachine;
        groundedData = stateMachine.Player.data.GroundedData;
        airborneData = stateMachine.Player.data.AirbornedData;
    }

    protected float startTime;

    
    
    #region PlayerState Method
    public override void Enter()
    {
        
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.MovementParHash);
        AddInputActionCallBacks();
        startTime= Time.time;
        

    }

    public override void HandleInput()
    {
        base.HandleInput();
        ReadMovementInput();
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (stateMachine.ReusableData.CanFlip)
        {
            Flip();
        }
        
        startTime += Time.deltaTime;
        stateMachine.ReusableData.RunningCheckTime += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move();
    }

    

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.MovementParHash);
        RemoveInputActionCallBacks();
    }

    public override void OnTriggerEnter(Collider2D collider)
    {
        base.OnTriggerEnter(collider);
        if (stateMachine.Player.LayerData.IsGroundLayer(collider.gameObject.layer))
        {
            OnContactWithGround(collider);
            return;
        }
    }

    public override void OnTriggerExit(Collider2D collider)
    {
        base.OnTriggerExit(collider);
        OnContactWithGroundExit();
        return;
    }






    #endregion

    #region Main Method
    protected void ReadMovementInput()
    {
        stateMachine.ReusableData.MovementInput = stateMachine.Player.playerInput.PlayerActions.Movement.ReadValue<Vector2>();
    }

    protected void Move()
    {
        if(stateMachine.ReusableData.MovementInput == Vector2.zero || stateMachine.ReusableData.MovementSpeedModifier == 0)
        {
            return;
        }

        Vector2 movementDirection = GetMovementInputDirection();
        Vector2 horizontalPlayerVelocity = GetHorizontalVelocity();
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.Rb.AddForce(movementSpeed * movementDirection - horizontalPlayerVelocity, ForceMode2D.Impulse);
    }
    protected void Flip()
    {
        if (stateMachine.ReusableData.MovementInput.x > 0)
        {
            stateMachine.ReusableData.IsFacingRight= true;
            stateMachine.Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(stateMachine.ReusableData.MovementInput.x < 0)
        {
            stateMachine.ReusableData.IsFacingRight= false;
            stateMachine.Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    protected void JumpStart(InputAction.CallbackContext context)
    {
        stateMachine.ReusableData.JumpPrepare = true;
        
        stateMachine.ChangeState(stateMachine.JumpLightStart);
    }
    protected void JumpCancel(InputAction.CallbackContext context)
    {
        stateMachine.ReusableData.JumpPrepare = false;
    }

    #endregion

    #region Reusable Methods
    protected virtual void OnSprint(InputAction.CallbackContext obj)
    {
        
    }
    protected virtual void OnContactWithGround(Collider2D collider)
    {
        
    }
    protected virtual void OnContactWithGroundExit()
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
    protected Vector2 GetMovementInputDirection()
    {
        return new Vector2(stateMachine.ReusableData.MovementInput.x, 0);
    }

    protected float GetMovementSpeed()
    {
        return groundedData.BaseSpeed* stateMachine.ReusableData.MovementSpeedModifier;
    }

    protected Vector2 GetHorizontalVelocity()
    {
        Vector2 horizontalVelocity = stateMachine.Player.Rb.velocity;

        horizontalVelocity.y = 0f;
        return horizontalVelocity;
    }

    protected void ResetVelocity()
    {
        stateMachine.Player.Rb.velocity = Vector2.zero;
    }
    protected void OnAttack(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.AttackCombo1);
    }

    protected void OnAirAttack(InputAction.CallbackContext context)
    {
        if (stateMachine.ReusableData.CanCombo)
        {
            stateMachine.ChangeState(stateMachine.AirAttack);
        }
       
    }
    #endregion

    #region Input Method

    protected virtual void AddInputActionCallBacks()
    {

        stateMachine.Player.playerInput.PlayerActions.Sprint.started += OnSprint;
        
    }

    

    protected virtual void RemoveInputActionCallBacks()
    {

        stateMachine.Player.playerInput.PlayerActions.Sprint.started -= OnSprint;
        
    }


    #endregion
}
