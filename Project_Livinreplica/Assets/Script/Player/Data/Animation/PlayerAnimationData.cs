using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData 
{
    [Header("State Group Parameter Name")]
    [SerializeField] private string movementParaName = "Movement";
    [SerializeField] private string groundParaName = "Grounded";
    [SerializeField] private string movingParaName = "Moving";
    [SerializeField] private string landingParaName = "Landing";
    [SerializeField] private string stopingParaName = "Stoping";
    [SerializeField] private string dashingParaName = "Dashing";
    [SerializeField] private string airborneParaName = "Airborne";
    [SerializeField] private string attackParaName = "Attack";
    [SerializeField] private string takeDamageParaName = "TakeDamage";
    [Header("Grounded Parameter Name")]
    [SerializeField] private string idleParaName = "IsIdle";
    [SerializeField] private string walkParaName = "IsWalk";
    [SerializeField] private string runParaName = "IsRun";
    [SerializeField] private string crouchParaName = "IsCrouch";
   
    [SerializeField] private string lightLandParaName = "LightLand";
    [SerializeField] private string heavyLandParaName = "HeavyLand";
    [SerializeField] private string sprintForwardParaName = "SprintForward";
    [SerializeField] private string sprintBackwardParaName = "SprintBackward";

    [Header("Airborne Parameter Name")]
    [SerializeField] private string jumpLightStartParaName = "JumpLightStart";
    [SerializeField] private string jumpRunStartParaName = "JumpRunStart";
    [SerializeField] private string fallingParaName = "Falling";

    [Header("Attack Parameter Name")]
    
    [SerializeField] private string attackCombo1ParaName = "AttackCombo1";
    [SerializeField] private string airAttackParaName = "AirAttack";

    [Header("Take Damage Parameter Name")]

    [SerializeField] private string takeDamageNormalParaName = "TakeDamageNormal";
    [SerializeField] private string takeDamageHardParaName = "TakeDamageHard";
    public int GroundedParHash { get; private set; }
    public int MovingParHash { get; private set; }
    public int LandingParHash { get; private set; }
    public int DashingParHash { get; private set; }
    public int AirborneParHash { get; private set; }
    public int StopingParHash { get; private set; }
    public int IdleParHash { get; private set; }
    public int WalkParHash { get; private set; }
    public int RunParHash { get; private set; }
    public int CrouchParHash { get; private set; }
    public int JumpLightStartParHash { get; private set; }
    public int JumpRunStartParHash { get; private set; }
    public int FallingParHash { get; private set; }
    public int LightLandParHash { get; private set; }
    public int HeavyLandParHash { get; private set; }
    public int SprintForwardParHash { get; private set; }
    public int SprintBackwardParHash { get; private set; }

    public int AttackCombo1ParHash { get; private set; }
    public int AttackParHash { get; private set; }
    public int MovementParHash { get; private set; }

    public int AirAttackParHash { get; private set; }
    public int TakeDamageParHash { get; private set; }
    public int TakeDamageNormalParHash { get; private set; }
    public int TakeDamageHardParHash { get; private set; }

    public void Initialize()
    {
        GroundedParHash = Animator.StringToHash(groundParaName);
        MovingParHash = Animator.StringToHash(movingParaName);
        DashingParHash = Animator.StringToHash(dashingParaName);
        StopingParHash = Animator.StringToHash(stopingParaName);
        LandingParHash = Animator.StringToHash(landingParaName);
        AirborneParHash = Animator.StringToHash(airborneParaName);
        IdleParHash = Animator.StringToHash(idleParaName);
        WalkParHash = Animator.StringToHash(walkParaName);
        RunParHash = Animator.StringToHash(runParaName);
        CrouchParHash = Animator.StringToHash(crouchParaName);
        JumpLightStartParHash = Animator.StringToHash(jumpLightStartParaName);
        JumpRunStartParHash = Animator.StringToHash(jumpRunStartParaName);
        FallingParHash = Animator.StringToHash(fallingParaName);
        LightLandParHash = Animator.StringToHash(lightLandParaName);
        HeavyLandParHash = Animator.StringToHash(heavyLandParaName);
        SprintForwardParHash = Animator.StringToHash(sprintForwardParaName);
        SprintBackwardParHash = Animator.StringToHash(sprintBackwardParaName);
        AttackCombo1ParHash = Animator.StringToHash(attackCombo1ParaName);
        AttackParHash = Animator.StringToHash(attackParaName);
        MovementParHash = Animator.StringToHash(movementParaName);
        AirAttackParHash = Animator.StringToHash(airAttackParaName);
        TakeDamageParHash = Animator.StringToHash(takeDamageParaName);
        TakeDamageNormalParHash = Animator.StringToHash(takeDamageNormalParaName);
        TakeDamageHardParHash = Animator.StringToHash(takeDamageHardParaName);
    }

}
