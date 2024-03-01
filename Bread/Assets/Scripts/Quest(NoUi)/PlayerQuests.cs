using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Custom/PlayerQuests")]
public class PlayerQuests : ScriptableObject
{
    public List<int> _quests;
    public List<Quest> _quests_;
}
