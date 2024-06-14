using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine :PlayerStateMachine
{
    public Player Player { get; }
    public PlayerReusableStateData ReusableData { get;  } 
    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get;  }
    public PlayerRunState RunState { get;  }

    public PlayerCrouchState CrouchState { get; }

    public PlayerJumpLightStart JumpLightStart { get; }
    public PlayerJumpRunStart JumpRunStart { get; }
    public PlayerFalling Falling { get; }
    public PlayerHeavyLand HeavyLand { get; }
    public PlayerLightLand LightLand { get; }
    public PlayerSprintForward SprintForward { get; }
    public PlayerSprintBackward SprintBackward { get; }
    public PlayerAttackState AttackState { get; }

    public PlayerAttackCombo1State AttackCombo1 { get; }

    public PlayerAirAttack AirAttack { get; }

    public PlayerTakeDamageNormalState TakeDamageNormalState { get; }

    public PlayerCrouchAttack PlayerCrouchAttack { get; }


    public PlayerMovementStateMachine(Player player)
    {
        Player = player;
        ReusableData= new PlayerReusableStateData();
        IdleState = new PlayerIdleState(this);
        CrouchState = new PlayerCrouchState(this);
       WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        JumpLightStart= new PlayerJumpLightStart(this);
        JumpRunStart= new PlayerJumpRunStart(this);
        Falling= new PlayerFalling(this);
        LightLand= new PlayerLightLand(this);
        HeavyLand= new PlayerHeavyLand(this);
        SprintBackward= new PlayerSprintBackward(this);
        SprintForward= new PlayerSprintForward(this);
        AttackState= new PlayerAttackState(this);
        AttackCombo1 = new PlayerAttackCombo1State(this);
        AirAttack= new PlayerAirAttack(this);
        TakeDamageNormalState= new PlayerTakeDamageNormalState(this);
        PlayerCrouchAttack= new PlayerCrouchAttack(this);
    }



}
