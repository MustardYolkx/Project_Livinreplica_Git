using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DreamTalkPanel : BasePanel
{
    private static string name = "DreamTalkPanel";
    private static string path = "Panel/DreamTalkPanel";

    private Image spriteLeft;

    private Image spriteRight;

    private TextMeshProUGUI nameText;

    private TextMeshProUGUI dialogueText;

    private List<Sprite> sprites = new List<Sprite>();

    //Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();

    private int dialogIndex;
    private bool nameReveal;

    private string[] dialogueRows;

    public GameObject nextButton;
    public GameObject optionButton;
    public Transform buttonGroup;

    public Dictionary<string, Sprite> imageLeftDic = new Dictionary<string, Sprite>();
    public Dictionary<string, Sprite> imageRightDic = new Dictionary<string, Sprite>();

    public static readonly UI_Type uI_Type = new UI_Type(path, name);

    public DreamTalkPanel() : base(uI_Type)
    {

    }


    private BaseDialogue targetDialogue;

    public override void OnStart()
    {
        base.OnStart();
        targetDialogue = GameRoot.GetInstance().DialogueManager_Root.stack_Dialogue.Peek();

        //Panel Set up//
        ReadFileText();
        InitialValue();

        spriteLeft = UI_Method.GetInstance().GetOrAddComponentInChild<Image>(ActiveObj, "LeftImage");
        spriteRight = UI_Method.GetInstance().GetOrAddComponentInChild<Image>(ActiveObj, "RightImage");
        nameText = UI_Method.GetInstance().GetOrAddComponentInChild<TextMeshProUGUI>(ActiveObj, "NameText");
        dialogueText = UI_Method.GetInstance().GetOrAddComponentInChild<TextMeshProUGUI>(ActiveObj, "DialogueText");
        //GetSpritesDic(targetDialogue.baseInfo.Name);
        //GetProtagnistSpritesDic("Protagnist");
        nextButton = UI_Method.GetInstance().FindObjectInChild(ActiveObj, "Next");
        buttonGroup = UI_Method.GetInstance().FindObjectInChild(ActiveObj, "ButtonGroup").transform;
        ShowDialogueRow();
        //Panel Set up//


        UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Next").onClick.AddListener(Next);
        

    }

    /// <summary>
    /// Get character image in Left Position in Resouorces
    /// </summary>
    /// <param name="name"></param>
    public void GetSpritesDic(string name)
    {
        string path = "Dialogue/" + name + "/Expressions";
        imageLeftDic.Add(name, Resources.Load<Sprite>(path + "/Happy"));
    }

    /// <summary>
    /// Get Character image in right position in Resources
    /// </summary>
    /// <param name="name"></param>
    public void GetProtagnistSpritesDic(string name)
    {
        string path = "Dialogue/" + name + "/Expressions";
        imageRightDic.Add(name, Resources.Load<Sprite>(path + "/Happy"));
    }
    private void InitialValue()
    {
        dialogIndex = targetDialogue.startIndex;
        nameReveal = targetDialogue.isNameReveal;

    }
    private void ReadFileText()
    {
        TextAsset file = Resources.Load<TextAsset>("Dialogue/" + targetDialogue.baseInfo.Name + "/Dialogue");
        Debug.Log(file);
        dialogueRows = file.text.Split('\n');
    }
    public void UpdateText(string name, string text, string position)
    {
        if (position == "Left")
        {
            if (nameReveal)
            {
                nameText.text = name;
                dialogueText.text = text;
            }
            else
            {
                nameText.text = "???";
                dialogueText.text = text;
            }
        }
        else if (position == "Right")
        {
            nameText.text = name;
            dialogueText.text = text;
        }

    }

    public void UpdateImage(string name, string position, string expression)
    {
        if (position == "Left")
        {
            //spriteLeft.sprite = imageLeftDic[name];
            spriteLeft.sprite = Resources.Load<Sprite>("Dialogue/" + name + "/Expressions/" + expression);
        }
        else if (position == "Right")
        {
            spriteRight.sprite = Resources.Load<Sprite>("Dialogue/" + name + "/Expressions/" + expression);
        }
    }

    public void ShowDialogueRow()
    {
        for (int i = 0; i < dialogueRows.Length; i++)
        {
            string[] cells = dialogueRows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[5], cells[3]);
                UpdateImage(cells[2], cells[3], cells[4]);

                dialogIndex = int.Parse(cells[6]);

                nextButton.gameObject.SetActive(true);
                NextButton(i);
                break;
            }
            else if (cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
            {
                nextButton.gameObject.SetActive(false);
                GenerateOption(i);
            }
            else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
            {
                Debug.Log("End");
                GameRoot.GetInstance().UIManager_Root.Pop(false);
            }
        }
    }
    public void NextButton(int index)
    {
        string[] cells = dialogueRows[index].Split(",");

       
            UI_Method.GetInstance().GetOrAddComponentInChild<Button>(ActiveObj, "Next").onClick.AddListener
        (
                   delegate
                   {
                       
                       if (cells[7] != "")
                       {
                           string[] effect = cells[7].Split("@");
                           cells[9] = Regex.Replace(cells[9], @"[\r\n]", "");
                           OptionEffect(effect[0], int.Parse(effect[1]), cells[8]);
                           Debug.Log("Cause Effect");
                       }
                   }
               );
        
    }
    public void GenerateOption(int index)
    {
        string[] cells = dialogueRows[index].Split(",");

        if (cells[0] == "&")
        {
            GameObject button = GameObject.Instantiate(Resources.Load<GameObject>("Dialogue/OptionButton"), buttonGroup);
            //Connect to next index
            button.GetComponentInChildren<TextMeshProUGUI>().text = cells[5];
            button.GetComponent<Button>().onClick.AddListener
                (
                    delegate
                    {
                        OnOptionClick(int.Parse(cells[6]));
                        if (cells[7] != "")
                        {
                            string[] effect = cells[7].Split("@");
                            cells[9] = Regex.Replace(cells[9], @"[\r\n]", "");
                            OptionEffect(effect[0], int.Parse(effect[1]), cells[8]);
                            Debug.Log("Cause Effect");
                        }
                    }
                );
            GenerateOption(index + 1);
        }

    }

    public void OnOptionClick(int id)
    {
        dialogIndex = id;
        ShowDialogueRow();
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            GameObject.Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }
    public void OptionEffect(string effect, int param, string target)
    {
        if (effect == "Favorability")
        {

            foreach (string npc in GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue.Keys)
            {
                Debug.Log(npc);
                Debug.Log(target);
                if (npc == target)
                {
                    GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[npc].favorability += param;
                    Debug.Log(GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[npc].favorability);
                }
            }
        }
        else if (effect == "NameReveal")
        {
            foreach (string npc in GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue.Keys)
            {
                if (npc == target)
                {
                    if (param == 0)
                    {
                        GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[npc].isNameReveal = false;
                    }
                    else if (param == 1)
                    {
                        GameRoot.GetInstance().Dialog_Dictionary_Root.dict_dialogue[npc].isNameReveal = true;
                    }
                }
            }
        }
        else if(effect == "Fight")
        {
            TurnToCombatState();
            GameRoot.GetInstance().UIManager_Root.Pop(false);
        }
    }

    public void TurnToCombatState()
    {
        GameRoot.GetInstance().CurrentTalkEnemy.ChangeToCombatState();
    }
    private void Close()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);
    }
    private void Next()
    {
        ShowDialogueRow();
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
