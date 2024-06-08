using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReusableStateData 
{
    public Vector2 MovementInput { get;  set; }
    public float MovementSpeedModifier { get;  set; }

    public bool IsRunning { get;  set; }
    public bool IsFacingRight { get; set; }

    public bool CanFlip { get; set; } = true;
    public float RunningCheckTime { get; set; }
    public bool JumpPrepare { get; set; }

    public float JumpForce { get; set; }

    public bool OnGround { get; set; }
    public Vector2 CurrentJumpForce { get; set; }

    public float CurrentSprintForce { get; set; }

    public bool IsSprinting { get; set; }

    public bool CanCombo { get; set; }

    public float AttackForce { get; set; }
}
