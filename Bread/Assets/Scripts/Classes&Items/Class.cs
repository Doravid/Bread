using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Class")]
public class Class : ScriptableObject
{
    public string className;
    public GameObject classModel;
    public PlayerBuff buff;
}

