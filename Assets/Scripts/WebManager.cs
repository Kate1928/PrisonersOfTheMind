using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class UserData
{
    public User userData;
    public Error error;
}
[System.Serializable]
public class User
{
    public int level;

    public User()
    {

    }
    
    public User(int lev)
    {
        level = lev;
    }

    public void Level(int lev)=> level = lev;
}
[System.Serializable]
public class Error
{
    public string textError;
    public bool isError;
}
[System.Serializable]
public class WebManager : MonoBehaviour
{
    [SerializeField] private string targetURL;
    public static UserData userData = new UserData();
    
    public string getUserData(UserData userData)
    {
        return JsonUtility.ToJson(userData);
    }

    public UserData setUserData(string userData)
    {
        return JsonUtility.FromJson<UserData>(userData);
    }
    
    void Start()
    {
        userData.error = new Error(){textError = "error", isError = true};
        userData.userData = new User(0);
        Debug.Log("userData");
        print(getUserData(userData));
    }

    public void Login(string login, string password)
    {
        StopAllCoroutines();
        StartCoroutine(Loginning(login, password));
    }
    IEnumerator Loginning(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("Login", login);
        form.AddField("Password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(targetURL, form))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("complete");
            }
        }
    }

}
