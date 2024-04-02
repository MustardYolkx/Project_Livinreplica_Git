using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scene_NPCList 
{

    public List<string> currentNPCList;

    public Dictionary<Scenes, List<string>> dict_allNPC;
   
    public enum Time
    {
        Morning,
        Afternoon,
        Evening,
    }

    public Time currentTime;

    private static Scene_NPCList instance;

    public enum Scenes
    {
        TempleteScene_Morning,
        TempleteScene_Afternoon,
        TempleteScene_Evening,

    }

    public Scenes currentScene;
    public static Scene_NPCList GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("Scene_NPCList doesn't exist");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public Scene_NPCList()
    {
        dict_allNPC = new Dictionary<Scenes, List<string>>();
        AddElementInDictionary();
        currentNPCList = new List<string>();

        currentTime = Time.Morning;
        currentScene = Scenes.TempleteScene_Morning;

        //ChangeDefualtSceneList(Scenes.TempleteScene_Morning, "NPC1", true);

        //currentNPCList = templeteNPCList;
    }

    /// <summary>
    /// Add a NPC in a certain Scene
    /// </summary>
    public void AddElementInDictionary()
    {
        dict_allNPC.Add(Scenes.TempleteScene_Morning, templeteMorning_NPCList);
    }

    public void ChangeTime(Time time)
    {
        currentTime = time;
        ChangeSceneList();
    }

    public void ChangeScene(Scenes sceneName)
    {
        currentScene= sceneName;
        ChangeSceneList();
    }

    /// <summary>
    /// Check current time and scene, and change currentNPCList to a certain sceneList;
    /// </summary>
    public void ChangeSceneList()
    {
        if(currentTime == Time.Morning)
        {
            if(currentScene == Scenes.TempleteScene_Morning)
            {
                currentNPCList = templeteMorning_NPCList;
            }
        }
        else if(currentTime == Time.Afternoon)
        {

        }
        else if(currentTime == Time.Evening)
        {

        }
    }

    public List<string> templeteMorning_NPCList = new List<string>();

    /// <summary>
    /// Add a character to a NPC list of a certain scene;
    /// </summary>
    /// <param name="targetScene">A scene you want to add a NPC</param>
    /// <param name="npcName">The name of the NPC you want to add</param>
    /// <param name="add">true == add, False == remove</param>
    public void ChangeDefualtSceneList(Scenes targetScene, string npcName, bool add)
    {
        if (add)
        {
            dict_allNPC[targetScene].Add(npcName);
        }
        if (!add)
        {

          dict_allNPC[targetScene].Remove(npcName);
            
        }
    }


    public void DeleteNPCInAllList(string name)
    {
        foreach(List<string> list in dict_allNPC.Values)
        {
            foreach (string item in list)
            {
                if(item == name)
                {
                    list.Remove(name);
                }
            }
        }
    }

    public void AutoAddNPC()
    {
        foreach(string npc in GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue.Keys)
        {
            foreach(Time time in GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[npc].npcShowScene.Keys)
            {
                Scenes scene = GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[npc].npcShowScene[time];                
                ChangeDefualtSceneList(scene, npc, true);
            }
            
        }
    }
}
