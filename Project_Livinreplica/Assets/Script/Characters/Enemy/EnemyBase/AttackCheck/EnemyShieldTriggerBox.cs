using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldTriggerBox : MonoBehaviour
{
    public Enemy enemy;
    public void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void TurnOffTakeDamage(Collider2D collider)
    {
        if (enemy.enemySO.LayerData.IsPlayerAttack(collider.gameObject.layer))
        {
            if(enemy.CheckPlayer(10f))
            {
                
            }
            else
            {
                enemy.isSheild = false;
            }
           

        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TurnOffTakeDamage(collision);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }
}
