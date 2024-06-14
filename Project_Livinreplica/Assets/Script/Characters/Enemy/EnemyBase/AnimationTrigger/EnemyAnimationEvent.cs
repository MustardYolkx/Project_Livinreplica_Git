using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public void AnimationTransitionEvent()
    {
        enemy.AnimationTransitionEvent();
    }

    public void AnimationEnterEvent()
    {
        enemy.AnimationEnterEvent();
    }

    public void AnimationExitEvent()
    {
        enemy.AnimationExitEvent();
    }
    public void AnimationComboChange()
    {
        enemy.AnimationComboChange();
    }

}
