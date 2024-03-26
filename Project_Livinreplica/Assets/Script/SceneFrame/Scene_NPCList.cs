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
        TempleteScene,
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

        ChangeDefualtSceneList(Scenes.TempleteScene, "NPC1", true);

        currentNPCList = templeteNPCList;
    }

    public void AddElementInDictionary()
    {
        dict_allNPC.Add(Scenes.TempleteScene, templeteNPCList);
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

    public void ChangeSceneList()
    {
        if(currentTime == Time.Morning)
        {
            if(currentScene == Scenes.TempleteScene)
            {
                currentNPCList = templeteNPCList;
            }
        }
        else if(currentTime == Time.Afternoon)
        {

        }
        else if(currentTime == Time.Evening)
        {

        }
    }

    public List<string> templeteNPCList = new List<string>();

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
}
