using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoxerBossAnimationData : EnemyAnimationData
{

    [Header("Parameter Name")]

    [SerializeField] private string boxerBossCombo1ParaName = "Combo1";
    [SerializeField] private string boxerBossCombo2ParaName = "Combo2";
    [SerializeField] private string boxerBossDownPunchParaName = "DownPunch";
    [SerializeField] private string boxerBossStraightPunchParaName = "StraightPunch";

    [SerializeField] private string boxerBossDoubleHammerParaName = "DoubleHammer";


    public int BoxerBossCombo1ParHash { get; private set; }
    public int BoxerBossCombo2ParHash { get; private set; }
    public int BoxerBossDownPunchParHash { get; private set; }
    public int BoxerBossStraightPunchParHash { get; private set; }
    public int BoxerBossDoubleHammerParHash { get; private set; }

    public override void Initialize()
    {
        
        BoxerBossCombo1ParHash = Animator.StringToHash(boxerBossCombo1ParaName);
        BoxerBossCombo2ParHash = Animator.StringToHash(boxerBossCombo2ParaName);
        BoxerBossDownPunchParHash = Animator.StringToHash(boxerBossDownPunchParaName);
        BoxerBossStraightPunchParHash = Animator.StringToHash(boxerBossStraightPunchParaName);
        BoxerBossDoubleHammerParHash = Animator.StringToHash(boxerBossDoubleHammerParaName);
    }
}
