using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDialogueTrigger : MonoBehaviour
{
    public Enemy enemy;

    public string dialogue_name;
    
    public void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInParent<Player>();
        if(player != null)
        {
            player.playerInput.PlayerActions.Talk.started += DialogueOn;
        }
        
    }

  
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponentInParent<Player>();
        if (player != null)
        {
            player.playerInput.PlayerActions.Talk.started -= DialogueOn;
        }
    }
    private void DialogueOn(InputAction.CallbackContext obj)
    {
        enemy.FaceToPlayer();
        GameRoot.GetInstance().DialogueManager_Root.Push(GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[dialogue_name]);
        GameRoot.GetInstance().CurrentTalkEnemy = GetComponentInParent<Enemy>();
        GameRoot.GetInstance().UIManager_Root.Push(new DreamTalkPanel());
    }


}
