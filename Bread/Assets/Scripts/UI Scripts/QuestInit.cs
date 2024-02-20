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
    private int id;
    private void Start()
    {
        if (quest.Quests.Contains(id)){
            Destroy(this.GameObject());
        }
    }

}
