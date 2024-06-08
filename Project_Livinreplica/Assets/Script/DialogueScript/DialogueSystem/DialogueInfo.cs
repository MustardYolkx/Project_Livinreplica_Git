using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInfo 
{
    private string filePath;

    private string name;

    public string FilePath { get => filePath; }
    public string Name { get => name; }

    /// <summary>
    /// Get UI information
    /// </summary>
    /// <param name="ui_path">The Path of Panel</param>
    /// <param name="ui_name">The Name of Panel</param>
    public DialogueInfo(string file_path, string ui_name)
    {
        filePath = file_path;
        name = ui_name;
    }
   
}
