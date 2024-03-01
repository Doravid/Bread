using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/PlayerBuff")]
public class PlayerBuff : ScriptableObject
{
    public int XP, Strength, MaxMana, MaxHealth, Gold;
    public bool alreadyApplied;
}

