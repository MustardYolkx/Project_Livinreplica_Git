using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionGamePanel : BasePanel
{
    /// <summary>
    /// panel for defualt interaction page
    /// </summary>
    private static string name = "OptionGamePanel";
    private static string path = "Panel/JiUPanel/OptionGamePanel";

    public static readonly UI_Type uI_Type = new UI_Type(path, name);

    public OptionGamePanel() : base(uI_Type)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        
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
