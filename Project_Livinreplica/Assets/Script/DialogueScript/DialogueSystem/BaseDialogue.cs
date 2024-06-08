using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BaseDialogue 
{
    public DialogueInfo baseInfo;

    public int favorability;

    public int startIndex;

    public bool isNameReveal;

    public Dictionary<Scene_NPCList.Time, Scene_NPCList.Scenes> npcShowScene;

    public Dictionary<string, Sprite> dict_sprites; 
    public BaseDialogue(DialogueInfo base_info)
    {
        baseInfo = base_info;

        dict_sprites= new Dictionary<string, Sprite>();
        npcShowScene = new Dictionary<Scene_NPCList.Time, Scene_NPCList.Scenes>();
        favorability = 0;  //set character favorability

        startIndex= 0;  //set dialogue start index
    }
    public virtual void OnStart()
    {
        Debug.Log($"{baseInfo.Name} Start working!");
        dict_sprites.Add(baseInfo.Name,Resources.Load<Sprite>(baseInfo.FilePath+"/Expressions"+"/Happy"));

        //UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }

    public virtual void OnEnable()
    {
        //UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    public virtual void OnDisable()
    {
        //UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

    public virtual void OnDestroy()
    {
        //UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }
}
