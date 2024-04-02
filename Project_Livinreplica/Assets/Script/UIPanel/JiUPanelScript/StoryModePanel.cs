using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryModePanel : BasePanel
{
    /// <summary>
    /// panel for defualt interaction page
    /// </summary>
    private static string name = "StoryModePanel";
    private static string path = "Panel/JiUPanel/StoryModePanel";

    public static readonly UI_Type uI_Type = new UI_Type(path, name);

    public StoryModePanel() : base(uI_Type)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "LoadGameButton").onClick.AddListener(OpenLoadGamePanel);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "NewGameButton").onClick.AddListener(OpenNewGamePanel);
        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "StoryModeBackButton").onClick.AddListener(BackToStartGamePanel);
    }

    private void OpenLoadGamePanel()
    {
        Scene2 scene2 = new Scene2();
        GameRoot.GetInstance().SceneControl_Root.LoadScene(scene2.SceneName, scene2);
    }

    private void OpenNewGamePanel()
    {

    }

    private void BackToStartGamePanel()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);
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
