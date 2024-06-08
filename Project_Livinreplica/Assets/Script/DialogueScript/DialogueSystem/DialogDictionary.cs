using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDictionary
{
    /// <summary>
    /// store the panel name correspond to the obj
    /// </summary>
    public Dictionary<string, BaseDialogue> dict_dialogue;


    private static DialogDictionary instance;

    public static DialogDictionary GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("DialogDictionary doesn't exist");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public NPC1_Dialogue npc1;

    public DialogDictionary()
    {
        npc1 = new NPC1_Dialogue();
        dict_dialogue = new Dictionary<string, BaseDialogue>();

        dict_dialogue.Add("NPC1", npc1);
    }
}
