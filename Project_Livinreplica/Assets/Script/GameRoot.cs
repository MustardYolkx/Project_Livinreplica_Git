using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private Scene_NPCList npcList;
    public Scene_NPCList NPCList { get => npcList; } 

    private DialogDictionary diaDic;
    public DialogDictionary Dialog_Dictionary { get => diaDic; }

    private UI_Manager uiManager;
    public UI_Manager UIManager_Root { get => uiManager; }

    private SceneControl sceneControl;    

    public SceneControl SceneControl_Root { get => sceneControl; }

    private DialogueManager_Test dialogueManager;
    public DialogueManager_Test DialogueManager_Root { get => dialogueManager; }

    private static GameRoot instance;

    public static GameRoot GetInstance()
    {
        if(instance == null)
        {
            Debug.LogError("Can't get Gameroot");
            return instance;
        }
        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        uiManager = new UI_Manager();
        sceneControl = new SceneControl();
        diaDic= new DialogDictionary();
        dialogueManager= new DialogueManager_Test();
        npcList= new Scene_NPCList();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UIManager_Root.canvasObj = UI_Method.GetInstance().FindCanvas();

        Scene1 scene1 = new Scene1();

        SceneControl_Root.dict_scene.Add(scene1.SceneName, scene1);

        //NPC1_Dialogue npc1 = new NPC1_Dialogue();
        //Dialog_Dictionary.dict_dialogue.Add("NPC1", npc1);
        Debug.Log(Dialog_Dictionary);
        #region Push First Panel
        UIManager_Root.Push(new StartPanel());

        #endregion
    }
}
