using TMPro;
using UnityEngine;

public class SetPassword : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TMP_InputField>().inputType = TMP_InputField.InputType.Password;
    }

}
