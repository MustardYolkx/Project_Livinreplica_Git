using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BoxerBoss : Enemy,IDamagable
{

    public EnemySO_BoxerBoss boxerBossSO { get; private set; }
    [field:SerializeField] public BoxerBossAnimationData boxerBossAnimationData { get; private set; }
    #region State Instance
    public BoxerBossCombatIdle BoxerBossCombatIdle { get; private set; }
    public BoxerBossCombatWalk BoxerBossCombatWalk { get; private set; }
    public BoxerBossCombo1 BoxerBossCombo1 { get; private set; }
    public BoxerBossCombo2 BoxerBossCombo2 { get; private set; }

    public BoxerBossDoubleHammer BoxerBossDoubleHammer { get; private set; }
    public BoxerBossDownPunch BoxerBossDownPunch { get; private set; }
    public BoxerBossTakeDamage BoxerBossTakeDamage { get; private set; }
    public BoxereBossStraghtPunch BoxereBossStraightPunch { get; private set; }
    #endregion
    // Start is called before the first frame update
    private new void Awake()
    {
        base.Awake();

        if(this.GetType() == typeof(Enemy_BoxerBoss))
        {
            boxerBossSO = (EnemySO_BoxerBoss)enemySO;
            
        }
        
        #region Generate State Instance

        BoxerBossCombatIdle= new BoxerBossCombatIdle(stateMachine,this);
        BoxerBossCombatWalk = new BoxerBossCombatWalk(stateMachine,this);
        BoxerBossCombo1 = new BoxerBossCombo1(stateMachine,this);
        BoxerBossCombo2 = new BoxerBossCombo2(stateMachine,this);
        BoxerBossDoubleHammer = new BoxerBossDoubleHammer(stateMachine,this);
        BoxerBossDownPunch = new BoxerBossDownPunch(stateMachine,this);
        BoxerBossTakeDamage= new BoxerBossTakeDamage(stateMachine,this);
        BoxereBossStraightPunch = new BoxereBossStraghtPunch(stateMachine,this);
        #endregion
    }

    private new void Start()
    // Start is called before the first frame update
    {
        base.Start();
        stateMachine.ChangeState(BoxerBossCombatIdle);
        boxerBossAnimationData.Initialize();
    }

    private new void Update()
    {
        stateMachine.LogicUpdate();
        
    }

    private new void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public new void TakeDamage(string animationName, float Damage, float damageForce,Vector3 pos)
    {

        if (canTakeDamage)
        {

            if (animationName == "TakeDamageNormal")
            {

                stateMachine.ChangeState(BoxerBossTakeDamage);
                Debug.Log("Taka Damage:" + Damage);

            }
            else if (animationName == "TakeDamageHard")
            {
                stateMachine.ChangeState(BoxerBossTakeDamage);
                Debug.Log("Taka Damage:" + Damage);

            }
            Rb.AddForce((transform.position-pos) * damageForce, ForceMode2D.Impulse);
        }

    }
}
