using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossDownPunch : EnemyAttackState
{
    public new Enemy_BoxerBoss enemy;
    public BoxerBossDownPunch(EnemyStateMachine enemyStateMachine, Enemy_BoxerBoss enemyScr) : base(enemyStateMachine, enemyScr)
    {
        enemy = enemyScr;
    }

    #region State Methods
    public override void Enter()
    {
        base.Enter();
        attackCountIndex = 0;
        enemy.attackCoolDownTime = enemy.boxerBossSO.BoxerBossAttackData.DownPunch[attackCountIndex].coolDownTime;
        enemy.currentAttackDamage = enemy.boxerBossSO.BoxerBossAttackData.DownPunch[attackCountIndex].Damage;
        enemy.currentDamageForce = enemy.boxerBossSO.BoxerBossAttackData.Combo1[attackCountIndex].DamageForce;
        enemy.targetTakeDamAnim = enemy.boxerBossSO.BoxerBossAttackData.DownPunch[attackCountIndex].CorrespondAnimation;
        StartAnimation(enemy.boxerBossAnimationData.BoxerBossDownPunchParHash);
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
        StopAnimation(enemy.boxerBossAnimationData.BoxerBossDownPunchParHash);
    }
    #endregion

    #region Main Methods
    public void ChangeAttackValue()
    {
        enemy.currentAttackDamage = enemy.boxerBossSO.BoxerBossAttackData.DownPunch[attackCountIndex].Damage;
        enemy.targetTakeDamAnim = enemy.boxerBossSO.BoxerBossAttackData.DownPunch[attackCountIndex].CorrespondAnimation;

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
