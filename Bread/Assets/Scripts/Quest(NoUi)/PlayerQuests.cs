using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Custom/PlayerQuests")]
public class PlayerQuests : ScriptableObject
{
    public List<Quest> completedQuests;
    public List<Quest> currentQuests;
}
