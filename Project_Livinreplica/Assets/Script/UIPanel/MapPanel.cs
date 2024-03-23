using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    private static string name = "MapPanel";
    private static string path = "Panel/MapPanel";

    public static readonly UI_Type uI_Type = new UI_Type(path, name);

    public MapPanel() : base(uI_Type)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Close);
        //UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Inventory").onClick.AddListener(OpenInventory);
        //UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Map").onClick.AddListener(OpenMap);
    }
    private void Close()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);
    }
    private void OpenPlayerAvater()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new InteractPhaseMain());
    }
    private void OpenInventory()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new InteractPhaseMain());
    }
    private void OpenMap()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new InteractPhaseMain());
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
