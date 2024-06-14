using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public Enemy enemy;
    private List<IDamagable> detectedDamagable = new List<IDamagable>();

    public void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void AnimationDamageTrigger()
    {
        CheckMeleeAttack();
    }

    public void CheckMeleeAttack()
    {
        foreach (IDamagable item in detectedDamagable)
        {
            item.TakeDamage(enemy.targetTakeDamAnim, enemy.currentAttackDamage);
            Debug.Log("Hit");
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
                Debug.Log("Add");
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
                Debug.Log("Remove");
            }
        }
    }
}
