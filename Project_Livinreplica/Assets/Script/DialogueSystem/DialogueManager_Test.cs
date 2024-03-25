using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_Test 
{
    /// <summary>
    /// The stack to store Dialogue File
    /// </summary>
    public Stack<BaseDialogue> stack_Dialogue;

    public TextAsset dialogDataFile;

    /// <summary>
    /// store the panel name correspond to the obj
    /// </summary>
    public Dictionary<string, TextAsset> dict_dialogueDateFile;

    public GameObject canvasObj;

    private static DialogueManager_Test instance;


    public static DialogueManager_Test GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("Dialogue_Manager doesn't exist");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public DialogueManager_Test()
    {
        instance = this;
        stack_Dialogue = new Stack<BaseDialogue>();
        dict_dialogueDateFile= new Dictionary<string, TextAsset>();
    }


    //public GameObject GetSingleObject()
    //{
    //    if (dict_uiObj.ContainsKey(uiType.Name))
    //    {
    //        return dict_uiObj[uiType.Name];
    //    }
    //    if (canvasObj == null)
    //    {
    //        canvasObj = UI_Method.GetInstance().FindCanvas();

    //    }

    //    GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.Path), canvasObj.transform);
    //    return gameObject;
    //}
    
    public TextAsset GetDialogueFile(DialogueInfo dialogueInfo)
    {
        if (dict_dialogueDateFile.ContainsKey(dialogueInfo.Name))
        {
            return dict_dialogueDateFile[dialogueInfo.Name];
        }
        if (canvasObj == null)
        {
            canvasObj = UI_Method.GetInstance().FindCanvas();
        }
        dialogDataFile = Resources.Load<TextAsset>("Dialogue/"+ dialogueInfo.Name + "/Dialogue");
        return dialogDataFile;
    }

    public void CreateNewOperation(BaseDialogue base_Dialogue)
    {
        GameObject dialogueOperating = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Dialogue/DialogueOperation"), canvasObj.transform);
        dialogueOperating.GetComponent<DIalogueOperation>().GetDialogueFile(dialogDataFile);
        dialogueOperating.GetComponent<DIalogueOperation>().GetSpritesDic(base_Dialogue.baseInfo.Name);
    }
    /// <summary>
    /// Push a panel to the stack
    /// </summary>
    /// <param name="basePanel_push">the panel you want to push</param>
    public void Push(BaseDialogue base_Dialogue)
    {
        Debug.Log($"{base_Dialogue.baseInfo.Name} has been pushed");

        if (stack_Dialogue.Count > 0)
        {
            stack_Dialogue.Peek().OnDisable();
        }
       
        
        if (stack_Dialogue.Count == 0)
        {
            stack_Dialogue.Push(base_Dialogue);
        }
        else
        {
            if (stack_Dialogue.Peek().baseInfo.Name != base_Dialogue.baseInfo.Name)
            {
                stack_Dialogue.Push(base_Dialogue);
            }
        }

        //base_Dialogue.OnStart();
    }
    /// <summary>
    /// Pop out a panel from stack
    /// </summary>
    /// <param name="isLoad">when true, pop out all the panels in stack</param>
    public void Pop(bool isLoad)
    {
        if (isLoad)
        {
            if (stack_Dialogue.Count > 0)
            {
                stack_Dialogue.Peek().OnDisable();
                stack_Dialogue.Peek().OnDestroy();
                GameObject.Destroy(dict_dialogueDateFile[stack_Dialogue.Peek().baseInfo.Name]);
                dict_dialogueDateFile.Remove(stack_Dialogue.Peek().baseInfo.Name);
                stack_Dialogue.Pop();
                Pop(true);
            }
        }
        else
        {
            stack_Dialogue.Peek().OnDisable();
            stack_Dialogue.Peek().OnDestroy();
            GameObject.Destroy(dict_dialogueDateFile[stack_Dialogue.Peek().baseInfo.Name]);
            dict_dialogueDateFile.Remove(stack_Dialogue.Peek().baseInfo.Name);
            stack_Dialogue.Pop();

            if (stack_Dialogue.Count > 0)
            {
                stack_Dialogue.Peek().OnEnable();
            }

        }
    }
}
