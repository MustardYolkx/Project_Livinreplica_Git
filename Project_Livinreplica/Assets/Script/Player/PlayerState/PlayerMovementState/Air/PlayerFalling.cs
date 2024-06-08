using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFalling : PlayerAirborneState
{
    float time = 0f;
    public PlayerFalling(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        time = 0;
        StartAnimation(stateMachine.Player.AnimationData.FallingParHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.FallingParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        time += Time.deltaTime;
        

    }

    #region Reusable Methods
   
    #endregion

    #region Input Methods

   

    #endregion
}
