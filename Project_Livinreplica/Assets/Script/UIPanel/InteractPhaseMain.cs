using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPhaseMain : BasePanel
{
    private static string name = "InteractPhaseMain";
    private static string path = "Panel/InteractPhaseMain";

    public static readonly UI_Type uI_Type = new UI_Type(path, name);

    public InteractPhaseMain() : base(uI_Type)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        List<string> list = UI_Method.GetInstance().GetNPCList();
        GameObject panel = UI_Method.GetInstance().FindObjectInChild(ActiveObj, "NPCList");
        GameObject optionButton = Resources.Load<GameObject>("Panel/OptionButton");
        Dictionary<string,GameObject> npcButton = UI_Method.GetInstance().InstantiateNPCListButton(list, panel, optionButton);
        foreach(GameObject buttonOBJ in npcButton.Values)
        {
            buttonOBJ.GetComponent<Button>().onClick.AddListener
            (
                 delegate 
                
                    {
                        ConversationStart(npcButton);
                                
                    }
                    
                
            );
        }
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "PlayerAvater").onClick.AddListener(OpenPlayerAvater);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Inventory").onClick.AddListener(OpenInventory);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Map").onClick.AddListener(OpenMap);
        //UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "NPC").onClick.AddListener(ConversationStart);
    }
    private void Close()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);
    }
    private void OpenPlayerAvater() 
    {
        GameRoot.GetInstance().UIManager_Root.Push(new PlayerAvaterPanel());
    }
    private void OpenInventory()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new InventoryPanel());
    }
    private void OpenMap()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new MapPanel());
    }
    private void ConversationStart(Dictionary<string, GameObject> dic)
    {
        BaseDialogue baseDia = UI_Method.GetInstance().FindDialogueInButton(dic);
        GameRoot.GetInstance().DialogueManager_Root.Push(baseDia);
        GameRoot.GetInstance().UIManager_Root.Push(new DialogueOperationPanel());
        //string name = UI_Method.GetInstance().GetOrAddComponentInChild<Text>(ActiveObj, "Name").ToString();
        //string path = "Dialogue/DialogueBase/" + name + "_Dialogue";
        

    }
    private void OpenNewScene()
    {
        Scene2 scene2 = new Scene2();
        GameRoot.GetInstance().SceneControl_Root.LoadScene(scene2.SceneName, scene2);
    }
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
