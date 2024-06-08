using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{

    private PlayerAttackCheck attackCheck;
    // Start is called before the first frame update
    void Start()
    {
        attackCheck = GetComponentInParent<PlayerAttackCheck>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        attackCheck.AddDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackCheck.RemoveDetected(collision);
    }
}
