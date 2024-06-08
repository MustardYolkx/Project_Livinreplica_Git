using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{

    public EnemyStateMachine stateMachine;
    public EnemyState enemyState;
    // Start is called before the first frame update

    private void Awake()
    {
        stateMachine = new EnemyStateMachine(this);
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void TakeDamage(string animationName, float Damage)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float Damage)
    {
        throw new System.NotImplementedException();
    }
}
