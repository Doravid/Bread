using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField username, password;
    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", username.text);
        form.AddField("password", password.text);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User Exists");
            var pID = UnityWebRequest.Post("http://localhost/sqlconnect/getid.php", form);
            yield return pID.SendWebRequest();
            int x = int.Parse(pID.downloadHandler.text);
            Debug.Log("PID: " + x);


        }
        else { Debug.LogWarning("User login failed. Err: " + www.downloadHandler.text); }
    }
}
