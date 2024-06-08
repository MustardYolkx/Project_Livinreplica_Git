using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public void TakeDamage(string animationName, float Damage);

    public void TakeDamage(float Damage);
}
