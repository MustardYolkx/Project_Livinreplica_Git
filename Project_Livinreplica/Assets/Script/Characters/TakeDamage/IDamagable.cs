using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public void TakeDamage(string animationName, float Damage,float damageForce,Vector3 pos);

    
}
