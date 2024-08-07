using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerMovementState
{
    float gravityScale;
    public PlayerDashState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.ReusableData.IsSprinting= true;
        //stateMachine.Player.Collider.enabled = false;
        stateMachine.Player.gameObject.layer = SetGameobjectLayer("Player_Sprint");
        stateMachine.Player.takeDamageTrigger.SetActive(false);
        //gravityScale = stateMachine.Player.Rb.gravityScale;
        //ChangeGravityScale(0);
        StartAnimation(stateMachine.Player.AnimationData.DashingParHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.ReusableData.IsSprinting = false;
        //stateMachine.Player.Collider.enabled = true;
        stateMachine.Player.gameObject.layer = SetGameobjectLayer("Player");
        stateMachine.Player.takeDamageTrigger.SetActive(true);
        //ChangeGravityScale(gravityScale);
        //OnContactWithGroundExit();
        StopAnimation(stateMachine.Player.AnimationData.DashingParHash);
    }

    public void ChangeGravityScale(float gravityScale)
    {
        stateMachine.Player.Rb.gravityScale = gravityScale;
    }

    public override void AnimationTransitionEvent()
    {
        CheckGroundExit();
    }

    protected  void CheckGroundExit()
    {
        if (IsThereGroundUnderneath())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        Vector2 capsuleColliderCenterInWorldSpace = stateMachine.Player.ResizableBox2DCollider.Box2DColliderData.Collider.bounds.center;

        Vector2 downwardsRayFromCapsuleBottom = capsuleColliderCenterInWorldSpace - stateMachine.Player.ResizableBox2DCollider.Box2DColliderData.ColliderVerticalExtents;

        RaycastHit2D hit = Physics2D.Raycast(downwardsRayFromCapsuleBottom, Vector3.down, groundedData.GroundToFallRayDistance, stateMachine.Player.LayerData.GroundLayer);
        if (hit.collider == null)
        {
            OnFall();
        }
        else
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
    protected virtual void OnFall()
    {
        stateMachine.ChangeState(stateMachine.Falling);
    }
    private bool IsThereGroundUnderneath()
    {
        PlayerTriggerColliderData triggerColliderData = stateMachine.Player.ResizableBox2DCollider.TriggerColliderData;

        Vector2 groundColliderCenterInWorldSpace = triggerColliderData.GroundCheckCollider.bounds.center;

        Collider2D[] overlappedGroundColliders = Physics2D.OverlapBoxAll(groundColliderCenterInWorldSpace, triggerColliderData.GroundCheckCollider.size, 0, stateMachine.Player.LayerData.GroundLayer);



        return overlappedGroundColliders.Length > 0;
    }

    public int SetGameobjectLayer(string layerName)
    {
         int layer = LayerMask.NameToLayer(layerName);
        return layer;
    }
}
