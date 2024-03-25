using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEditor.Rendering;
//using UnityEngine.Rendering;
//using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class DialogueManager : MonoBehaviour
{

    public TextAsset dialogDateFile;

    public SpriteRenderer spriteLeft;
    
    public SpriteRenderer spriteRight;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public List<Sprite> sprites = new List<Sprite>();

    Dictionary<string,Sprite> imageDic = new Dictionary<string,Sprite>();

    public int dialogIndex;

    public string[] dialogueRows;

    public Button nextButton;

    public GameObject optionButton;

    public Transform buttonGroup;

    public List<CharacterInfo> characters= new List<CharacterInfo>();
    // Start is called before the first frame update

    private void Awake()
    {
        imageDic["NPC1"] = sprites[0];
        imageDic["NPC2"] = sprites[1];
        CharacterInfo NPC1 = new CharacterInfo();
        NPC1.name = "NPC1";
        characters.Add(NPC1);
        CharacterInfo NPC2 = new CharacterInfo();
        NPC2.name = "NPC2";
        characters.Add(NPC2);
    }
    void Start()
    {
        ReadText(dialogDateFile);
        ShowDialogueRow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string name, string text)
    {
        nameText.text = name;
        dialogueText.text = text;
    }

    public void UpdateImage(string name,string position)
    {
        if (position == "Left")
        {
            spriteLeft.sprite = imageDic[name];
        }
        else if(position == "Right")
        {
            spriteRight.sprite = imageDic[name];
        }
    }

    public void ReadText(TextAsset textAsset)
    {
        dialogueRows = textAsset.text.Split('\n');
    }

    public void ShowDialogueRow()
    {
        for (int i =0;i<dialogueRows.Length;i++)
        {
            string[] cells = dialogueRows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                dialogIndex = int.Parse(cells[5]);

                nextButton.gameObject.SetActive(true);
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
            }
        }
    }

    public void OnClickNext()
    {
        ShowDialogueRow();
    }

    public void GenerateOption(int index)
    {
        string[] cells = dialogueRows[index].Split(",");

        if (cells[0] == "&")
        {
            GameObject button = Instantiate(optionButton, buttonGroup);
            //Connect to next index
            button.GetComponentInChildren<TextMeshProUGUI>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener
                (
                    delegate
                    {
                        OnOptionClick(int.Parse(cells[5]));
                        if (cells[6] != "")
                        {
                            string[] effect = cells[6].Split("@");
                            cells[7] = Regex.Replace(cells[7], @"[\r\n]", "");
                            OptionEffect(effect[0], int.Parse(effect[1]), cells[7]);
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
        for(int i = 0;i<buttonGroup.childCount;i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }

    public void OptionEffect(string effect, int param, string target)
    {
        if(effect == "Favorability+1")
        {
            foreach(var npc in characters)
            {
                if(npc.name == target)
                {
                    npc.favorability += param;
                }
            }
        }
    }
}
