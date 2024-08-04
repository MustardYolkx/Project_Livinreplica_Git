using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCheck : MonoBehaviour
{

    public Player player;
    private List<IDamagable> detectedDamagable = new List<IDamagable>();

    public void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    public void AnimationDamageTrigger()
    {
        CheckMeleeAttack();
    }

    public void CheckMeleeAttack()
    {
        foreach(IDamagable item in detectedDamagable)
        {
            item.TakeDamage(player.targetTakeDamAnim,player.currentAttackDamage,player.currentDamageForce,transform.position);
            //Debug.Log("Hit");
        }
    }
    public void AddDetected(Collider2D collider)
    {
        IDamagable damagableItem = collider.GetComponentInParent<IDamagable>();
        if (player.LayerData.IsDamagableLayer(collider.gameObject.layer))
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
        if (player.LayerData.IsDamagableLayer(collider.gameObject.layer))
        {
            if (damagableItem != null)
            {
                detectedDamagable.Remove(damagableItem);

            }
        }
    }
}
