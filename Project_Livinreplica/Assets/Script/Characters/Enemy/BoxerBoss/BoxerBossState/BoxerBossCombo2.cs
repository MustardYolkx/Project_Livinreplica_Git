using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossCombo2 : EnemyAttackState
{
    public new Enemy_BoxerBoss enemy;
    public BoxerBossCombo2(EnemyStateMachine enemyStateMachine, Enemy_BoxerBoss enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
    }

    #region State Methods
    public override void Enter()
    {
        base.Enter();
        attackCountIndex = 0;
        enemy.attackCoolDownTime = enemy.boxerBossSO.BoxerBossAttackData.Combo1[attackCountIndex].coolDownTime;
        enemy.currentAttackDamage = enemy.boxerBossSO.BoxerBossAttackData.Combo1[attackCountIndex].Damage;
        enemy.currentDamageForce = enemy.boxerBossSO.BoxerBossAttackData.Combo1[attackCountIndex].DamageForce;
        enemy.targetTakeDamAnim = enemy.boxerBossSO.BoxerBossAttackData.Combo1[attackCountIndex].CorrespondAnimation;
        StartAnimation(enemy.boxerBossAnimationData.BoxerBossCombo2ParHash);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        attackCountIndex = 0;
        StopAnimation(enemy.boxerBossAnimationData.BoxerBossCombo2ParHash);
    }
    #endregion

    #region Main Methods
    public void ChangeAttackValue()
    {
        enemy.currentAttackDamage = enemy.boxerBossSO.BoxerBossAttackData.Combo2[attackCountIndex].Damage;
        enemy.targetTakeDamAnim = enemy.boxerBossSO.BoxerBossAttackData.Combo2[attackCountIndex].CorrespondAnimation;

    }
    #endregion

    #region Animation Methods
    public override void AnimationComboChange()
    {
        attackCountIndex++;
        ChangeAttackValue();
    }

    public override void AnimationTransitionTrigger()
    {
        stateMachine.ChangeState(enemy.BoxerBossCombatIdle);
    }
    #endregion
}
