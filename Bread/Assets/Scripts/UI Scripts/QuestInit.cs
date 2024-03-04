using Den.Tools.GUI.Popup;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestInit : MonoBehaviour
{
    [SerializeField]
    private PlayerQuests quest;
    [SerializeField]
    private Quest questA;
    [SerializeField]
    private TextMeshProUGUI questName;
    [SerializeField]
    private Image questSymbol;
    public GameObject description;
    private void Start()
    {
        init();
    }
    public void init()
    {
        if (quest.completedQuests.Contains(questA))
            Destroy(this.GameObject());

        questName.text = questA.questName;
        questSymbol.sprite = questA.questIcon;
    }
    public void openQuest()
    {
        description.SetActive(true);
    }
}
