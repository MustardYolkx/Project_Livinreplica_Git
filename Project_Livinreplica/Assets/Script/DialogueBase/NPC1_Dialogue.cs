using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_Dialogue : BaseDialogue
{
    private static string name = "NPC1";
    private static string path = "Dialogue/NPC1/Dialogue";

    private Scene_NPCList.Time morning = Scene_NPCList.Time.Morning;
    private Scene_NPCList.Scenes sceneMorning = Scene_NPCList.Scenes.TempleteScene_Morning;


    public static readonly DialogueInfo dialogueInfo = new DialogueInfo(path, name);

    public NPC1_Dialogue() : base(dialogueInfo)
    {
        base.npcShowScene.Add(morning, sceneMorning);
    }
}
