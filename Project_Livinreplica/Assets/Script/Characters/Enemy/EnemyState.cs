using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    public EnemyStateMachine stateMachine;
    public Enemy enemy;
    public EnemyState(EnemyStateMachine enemyStateMachine)
    {
        stateMachine= enemyStateMachine;
        
    }
    public virtual void Enter()
    {
        
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {

    }
}
