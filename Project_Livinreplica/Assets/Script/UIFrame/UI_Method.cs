using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Method 
{
    private static UI_Method instance;

    public static UI_Method GetInstance()
    {
        if(instance == null)
        {
            instance= new UI_Method();
            
        }
        return instance;
    }
    /// <summary>
    /// Get canvas in game scene
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if(gameObject == null )
        {
            Debug.LogError("Can't find canvas in game scene");
            return gameObject;
        }
        return gameObject;
    }

    public GameObject FindObjectInChild(GameObject panel,string childName)
    {
        Transform[] transform = panel.GetComponentsInChildren<Transform>();

        foreach(var tra in transform)
        {
            if(tra.gameObject.name == childName)
            {
                return tra.gameObject;
            }
        }

        Debug.LogError($"Can't find{childName} in {panel.name}");
        return null;
    }
    /// <summary>
    /// Add of get Component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Get_Obj"></param>
    /// <returns></returns>
    public T AddOrGetComponent<T>(GameObject gameObject) where T : Component
    {
        if (gameObject.GetComponent<T>() != null)
        {
            return gameObject.GetComponent<T>();
        }
        else
        {
            Debug.LogError($"Can't get component from{gameObject}");
            gameObject.AddComponent<T>();
            return gameObject.GetComponent<T>();
        }
        
    }

    public T GetOrAddComponentInChild<T>(GameObject gameObject, string childName) where T : Component
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();

        foreach (var tra in transforms)
        {
            if (tra.gameObject.name == childName)
            {
                if(tra.GetComponent<T>() != null)
                {
                    return tra.gameObject.GetComponent<T>();
                }
                else
                {
                    tra.gameObject.AddComponent<T>();
                    return tra.gameObject.GetComponent<T>();
                }
            }
        }

        Debug.LogError($"Can't find{childName} In {gameObject.name}");
        return null;
    }

    public List<string> GetNPCList()
    {
        Scene_NPCList npcList = GameObject.FindObjectOfType<Scene_NPCList>();
        return npcList.npcList;
    }

    public Dictionary<string,GameObject> InstantiateNPCListButton(List<string> npclist,GameObject listpanel,GameObject optionButton)
    {
        Dictionary<string, GameObject> dic = new Dictionary<string, GameObject>();
        foreach (string i in npclist)
        {
           GameObject button = GameObject.Instantiate<GameObject>(optionButton, listpanel.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = i;
            //button.GetComponent<Button>().onClick.AddListener();
           dic.Add(i,button);           
        }
        return dic;
    }
    public BaseDialogue FindDialogueInButton(Dictionary<string, GameObject> dic)
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        string name= clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        return GameRoot.GetInstance().Dialog_Dictionary.dict_dialogue[name];
        //GameObject button = dic[clickedButton.name];
        
        //return button.GetComponent<BaseDialogue>();
    }
}
