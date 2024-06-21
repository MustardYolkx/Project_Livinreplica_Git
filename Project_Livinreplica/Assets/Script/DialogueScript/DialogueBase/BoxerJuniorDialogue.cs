using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerJuniorDialogue : BaseDialogue
{
    private static string name = "Enemy_BoxerJunior";
    private static string path = "Dialogue/BoxerJunior/Dialogue";

    private Scene_NPCList.Time morning = Scene_NPCList.Time.Morning;
    private Scene_NPCList.Scenes sceneMorning = Scene_NPCList.Scenes.TempleteScene_Morning;


    public static readonly DialogueInfo dialogueInfo = new DialogueInfo(path, name);

    public BoxerJuniorDialogue() : base(dialogueInfo)
    {
        base.npcShowScene.Add(morning, sceneMorning);
    }
}
