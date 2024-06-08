using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAnimationData
{
    [Header("Parameter Name")]

    [SerializeField] private string idleParaName = "Idle";
    [SerializeField] private string walkParaName = "Walk";
    [SerializeField] private string attackParaName = "Attack";
    [SerializeField] private string attack1ParaName = "Attack1";

    [SerializeField] private string takeDamageParaName = "TakeDamage";

    [SerializeField] private string takeDamageNormalParaName = "TakeDamageNormal";
    [SerializeField] private string takeDamageHardParaName = "TakeDamageHard";

    public int IdleParHash { get; private set; }
    public int WalkParHash { get; private set; }
    public int AttackParHash { get; private set; }
    public int Attack1ParHash { get; private set; }
    public int TakeDamageParHash { get; private set; }
    public int TakeDamageNormalParHash { get; private set; }

    public int TakeDamageHardParHash { get; private set; }
    public void Initialize()
    {
        IdleParHash = Animator.StringToHash(idleParaName);
        WalkParHash = Animator.StringToHash(walkParaName);
        AttackParHash = Animator.StringToHash(attackParaName);
        Attack1ParHash = Animator.StringToHash(attack1ParaName);
        TakeDamageParHash =Animator.StringToHash(takeDamageParaName);
        TakeDamageNormalParHash = Animator.StringToHash(takeDamageNormalParaName);
        TakeDamageHardParHash = Animator.StringToHash(takeDamageHardParaName);
    }
}