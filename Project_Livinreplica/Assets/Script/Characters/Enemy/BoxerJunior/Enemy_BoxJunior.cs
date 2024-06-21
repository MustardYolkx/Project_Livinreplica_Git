using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BoxJunior : Enemy,IDamagable
{
    #region State Instance
    public BoxerJuniorIdle BoxerJuniorIdle { get; private set; }
    public BoxerJunior_Attack1 BoxerJuniorAttack1 { get; private set; }
    public BoxerJunior_CombatIdle BoxerJuniorCombatIdle { get; private set; }
    public BoxerJunior_TakeDamage BoxerJuniorTakeDamage { get; private set; }

    public BoxerJunior_CombatWalk BoxerJunior_CombatWalk { get; private set; }

    public BoxerJuniorDialogue BoxerJunior_Dialogue { get; private set; }
    #endregion
    // Start is called before the first frame update
    private new void Awake()
    {
        base.Awake();


        #region Generate State Instance
        
    BoxerJuniorIdle = new BoxerJuniorIdle(stateMachine, this);
        BoxerJuniorAttack1 = new BoxerJunior_Attack1(stateMachine, this);
        BoxerJuniorCombatIdle = new BoxerJunior_CombatIdle(stateMachine, this);
        BoxerJuniorTakeDamage = new BoxerJunior_TakeDamage(stateMachine, this);
        BoxerJunior_CombatWalk = new BoxerJunior_CombatWalk(stateMachine, this);
        #endregion
    }

    private new void Start()
    // Start is called before the first frame update
    {
        base.Start();
        stateMachine.ChangeState(BoxerJuniorIdle);

    }

    private new void Update()
    {
        stateMachine.LogicUpdate();
    }

    private new void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public new void TakeDamage(string animationName, float Damage)
    {
        Debug.Log("hit");
        if (canTakeDamage)
        {
            
            if (animationName == "TakeDamageNormal")
            {

                stateMachine.ChangeState(BoxerJuniorTakeDamage);
                Debug.Log("Enemy Taka Damage:" + Damage);
                
            }
            else if (animationName == "TakeDamageHard")
            {
                stateMachine.ChangeState(BoxerJuniorTakeDamage);
                Debug.Log("Enemy Taka Damage:" + Damage);

            }

        }

    }

    public override void ChangeToCombatState()
    {
        stateMachine.ChangeState(BoxerJuniorCombatIdle);
    }
}
