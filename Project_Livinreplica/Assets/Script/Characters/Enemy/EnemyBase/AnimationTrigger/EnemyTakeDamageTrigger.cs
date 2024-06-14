using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageTrigger : MonoBehaviour
{
   public Enemy enemy { get; private set; }

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }



}
