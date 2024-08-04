using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public Enemy enemy;
    private List<IDamagable> detectedDamagable = new List<IDamagable>();

    private bool canHit;

    public void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public void Update()
    {
        if(enemy.CanHit)
        {
            CheckMeleeAttack();
        }
        else
        {

        }
    }
    public void AnimationDamageTrigger()
    {
        CheckMeleeAttack();
    }

    public void TurnOnDamageTrigger()
    {
        enemy.CanHit= true;
    }

    public void TurnOffDamageTrigger()
    {
        enemy.CanHit = false;
    }
    public void CheckMeleeAttack()
    {
        foreach (IDamagable item in detectedDamagable)
        {
            item.TakeDamage(enemy.targetTakeDamAnim, enemy.currentAttackDamage,enemy.currentDamageForce,transform.position);
            //Debug.Log("Hit");
        }
    }
    public void AddDetected(Collider2D collider)
    {
        IDamagable damagableItem = collider.GetComponentInParent<IDamagable>();
        if(enemy.enemySO.LayerData.IsPlayerLayer(collider.gameObject.layer) )
        {
            if (damagableItem != null)
            {
                detectedDamagable.Add(damagableItem);
                //Debug.Log("Add");
            }
        }
        
    }

    public void RemoveDetected(Collider2D collider)
    {
        IDamagable damagableItem = collider.GetComponentInParent<IDamagable>();
        if (enemy.enemySO.LayerData.IsPlayerLayer(collider.gameObject.layer))
        {
            if (damagableItem != null)
            {
                detectedDamagable.Remove(damagableItem);
                //Debug.Log("Remove");
            }
        }
    }
}
