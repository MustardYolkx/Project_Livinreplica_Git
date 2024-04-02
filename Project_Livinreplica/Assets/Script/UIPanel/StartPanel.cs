using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "GameStartPanel";
    private static string path = "Panel/JiUPanel/GameStartPanel";

    public static readonly UI_Type uI_Type = new UI_Type(path, name);

    public StartPanel() : base(uI_Type)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "StoryModeButton").onClick.AddListener(OpenStoryModePanel);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "VSModeButton").onClick.AddListener(OpenVSPanel);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "OptionButton").onClick.AddListener(OpenOptionPanel);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "LeaveButton").onClick.AddListener(Close);
    }

    private void OpenStoryModePanel()
    {
        UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).alpha = 0;
        GameRoot.GetInstance().UIManager_Root.Push(new StoryModePanel());
    }

    private void OpenVSPanel()
    {

    }

    private void OpenOptionPanel()
    {
        UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).alpha = 0;
        GameRoot.GetInstance().UIManager_Root.Push(new OptionGamePanel());
        
    }

    private void Close()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);
    }
    public override void OnEnable()
    {
        UI_Method.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).alpha = 1;
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
