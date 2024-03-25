using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_Dialogue : BaseDialogue
{
    private static string name = "NPC1";
    private static string path = "Dialogue/NPC1/Dialogue";

    

    public static readonly DialogueInfo dialogueInfo = new DialogueInfo(path, name);

    public NPC1_Dialogue() : base(dialogueInfo)
    {

    }
}
