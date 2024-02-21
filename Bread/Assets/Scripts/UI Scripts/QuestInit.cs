using Den.Tools.GUI.Popup;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestInit : MonoBehaviour
{
    [SerializeField]
    private PlayerQuests quest;
    [SerializeField]
    private Quest questA;
    private void Start()
    {
        Debug.Log(questA.id);
        Debug.Log(quest._quests.Count);
        if (quest._quests.Contains(89))
            Destroy(this.GameObject());
    }
}
