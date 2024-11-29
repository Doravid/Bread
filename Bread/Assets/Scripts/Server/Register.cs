using System.Collections;
using System.Net.Cache;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField username, password;

    public void CallRegister()
    {
        StartCoroutine(RegisterUser());
    }
    IEnumerator RegisterUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", username.text);
        form.AddField ("password", password.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
        }
        else { Debug.LogWarning("User creating failed. Err: " + www.text); }
    }

    public void VerifyInputs()
    {
        GetComponent<Button>().interactable = (username.text.Length >= 2 && password.text.Length >= 6);
    }
}
