using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerGroundedState : PlayerMovementState
{
    public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Player State Methods
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundedParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundedParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    #endregion

    #region Main Methods
    private void OnCrouch(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.CrouchState);
    }
    
    protected void JumpRunStart(InputAction.CallbackContext context)
    {
        
        stateMachine.ChangeState(stateMachine.JumpRunStart);
    }
    #endregion

    #region Reusable Methods
    protected override void OnContactWithGroundExit()
    {

            if (IsThereGroundUnderneath())
            {
                return;
            }

            Vector2 capsuleColliderCenterInWorldSpace = stateMachine.Player.ResizableBox2DCollider.Box2DColliderData.Collider.bounds.center;

            Vector2 downwardsRayFromCapsuleBottom = capsuleColliderCenterInWorldSpace - stateMachine.Player.ResizableBox2DCollider.Box2DColliderData.ColliderVerticalExtents;

            RaycastHit2D hit = Physics2D.Raycast(downwardsRayFromCapsuleBottom, Vector3.down, groundedData.GroundToFallRayDistance, stateMachine.Player.LayerData.GroundLayer);
            if (hit.collider == null)
            {
                OnFall();
            }
        
        
    }
    
    private bool IsThereGroundUnderneath()
    {
        PlayerTriggerColliderData triggerColliderData = stateMachine.Player.ResizableBox2DCollider.TriggerColliderData;

        Vector2 groundColliderCenterInWorldSpace = triggerColliderData.GroundCheckCollider.bounds.center;

        Collider2D[] overlappedGroundColliders = Physics2D.OverlapBoxAll(groundColliderCenterInWorldSpace, triggerColliderData.GroundCheckCollider.size,0, stateMachine.Player.LayerData.GroundLayer);

        
        
        return overlappedGroundColliders.Length > 0;
    }
    protected virtual void OnFall()
    {
        stateMachine.ChangeState(stateMachine.Falling);
    }

    protected override void OnSprint(InputAction.CallbackContext obj)
    {
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.SprintBackward);
            return;
        }

        stateMachine.ChangeState(stateMachine.SprintForward);
    }


    #endregion

    #region Input Methods


    protected override void AddInputActionCallBacks()
    {
        base.AddInputActionCallBacks();
       
        stateMachine.Player.playerInput.PlayerActions.Crouch.started += OnCrouch;
        stateMachine.Player.playerInput.PlayerActions.Attack.started += OnAttack;

    }

    protected override void RemoveInputActionCallBacks()
    {
        base.RemoveInputActionCallBacks();
        stateMachine.Player.playerInput.PlayerActions.Crouch.started -= OnCrouch;
        stateMachine.Player.playerInput.PlayerActions.Attack.started -= OnAttack;


    }

    protected void RunningInputStart(InputAction.CallbackContext context)
    {
        if (stateMachine.ReusableData.RunningCheckTime < 0.2f)
        {
            stateMachine.ChangeState(stateMachine.RunState);
        }
    }
    #endregion
}
