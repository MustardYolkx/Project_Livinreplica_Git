using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BoxierSenior : Enemy,IDamagable
{

    #region State Instance
    public BoxerSenior_DefendState BoxerSeniorDefend { get; private set; }

    public BoxerSenior_IdleState BoxerSeniorIdle { get; private set; }

    public BoxerSeniorTakeDamage BoxerSeniorTakeDamageState { get; private set; }

    public BoxerSeniorAttack1 BoxerSeniorAttack1 { get; private set; }

    public BoxerSeniorTakeDamage BoxerSeniorTakeDamage { get; private set; }
    #endregion
    
    private new void Awake()
    {
        base.Awake();
        

        #region Generate State Instance
        BoxerSeniorDefend = new BoxerSenior_DefendState(stateMachine,this);
        BoxerSeniorIdle = new BoxerSenior_IdleState(stateMachine, this);
        BoxerSeniorTakeDamageState = new BoxerSeniorTakeDamage(stateMachine, this);
        BoxerSeniorAttack1 = new BoxerSeniorAttack1(stateMachine, this);

        BoxerSeniorTakeDamage = new BoxerSeniorTakeDamage(stateMachine, this);
        #endregion
    }

    private new void Start()
        // Start is called before the first frame update
    {
        base.Start();
        stateMachine.ChangeState(BoxerSeniorIdle);
        
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
        if (canTakeDamage)
        {
            Debug.Log("sub Take Damage");
            if (animationName == "TakeDamageNormal")
            {
                if (!isSheild)
                {
                    stateMachine.ChangeState(BoxerSeniorTakeDamageState);
                    Debug.Log("Taka Damage:" + Damage);
                }
                else
                {
                    
                }
            }
            else if (animationName == "TakeDamageHard")
            {
                stateMachine.ChangeState(TakeDamageHardState);
                Debug.Log("Taka Damage:" + Damage);

            }

        }
    }
}
