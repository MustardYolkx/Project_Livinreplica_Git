using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : SceneBase
{
    public readonly string SceneName = "Scene2";
    public override void EnterScene()
    {
        GameRoot.GetInstance().NPCList_Root.ChangeSceneList();
        GameRoot.GetInstance().UIManager_Root.Push(new InteractPhaseMain());
        
    }

    public override void ExitScene()
    {
        
    }
}
