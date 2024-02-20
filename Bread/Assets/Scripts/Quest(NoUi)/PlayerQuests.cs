using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerQuests : ScriptableObject
{
    private List<int> _quests;

    public List<int> Quests {  
        get { return _quests; } 
        set { _quests = value; }


    }
    public void setQuests(List<int> quests)
    {
        _quests = quests;
    }

}
