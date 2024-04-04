using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Custom/AttackBar")]
public class AttackBar : ScriptableObject
{
    public List<Attack> currentAttacks;
}

