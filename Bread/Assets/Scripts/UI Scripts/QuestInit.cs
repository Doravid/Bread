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
        if (quest._quests.Contains(questA.id))
            Destroy(this.GameObject());
    }
}
