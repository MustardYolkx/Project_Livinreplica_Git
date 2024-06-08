using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEventTrigger : MonoBehaviour
{

    Player player;

    private void Awake()
    {
        player =GetComponentInParent<Player>();
    }

    public void AnimationTransitionEvent()
    {
        player.AnimationTransitionEvent();
    }

    public void AnimationEnterEvent()
    {
        player.AnimationEnterEvent();
    }

    public void AnimationExitEvent()
    {
        player.AnimationExitEvent();
    }

    public void AnimationComboStartEvent()
    {
        player.AnimationComboStartEvent();
    }

    public void AnimationComboEndEvent()
    {
        player.AnimationComboEndEvent();
    }
}
