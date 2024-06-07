using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Extensions;
using Firebase.Auth;
using Firebase;

public class ButtonsMechanics : MonoBehaviour
{
     private const string saveKeyPlayer = "PLAYER_DATA";
    public GameObject moreFragment;
    public GameObject HelpFragment;
    public GameObject signInFragment;
    public GameObject signUpFragment;

    public GameObject startFragment;
    public GameObject personIcon;

    void Start() {
        FirebaseUser user = FirebaseAuth.DefaultInstance.CurrentUser;
        if (user != null) {
            personIcon.SetActive(true);
        }
        else {
            personIcon.SetActive(false);
        }
        
        /*FirebaseAuth auth = FirebaseAuth.auth;
        auth.onAuthStateChanged((user) => {
            if (user != null) {
                personIcon.SetActive(true);
            }
            else {
                personIcon.SetActive(false);
            }
        });*/
    }
    // Start is called before the first frame update
    public void startButton() {
        var data = saveHelper.Load<PlayerData>(saveKeyPlayer);
        if (data.level >= 1) {
            SceneManager.LoadScene(2);
        }
        SceneManager.LoadScene(1);
    }

    public void helpButton() {
        HelpFragment.SetActive(true);
    }

    public void moreButton() {
        moreFragment.SetActive(true);
    }

    public void moreClose() {
        moreFragment.SetActive(false);
    }
    
    public void closeHelp() {
        HelpFragment.SetActive(false);
    }

    public void signInButton() {
        signInFragment.SetActive(true);
        startFragment.SetActive(false);
    }

    public void signUpButton() {
        signUpFragment.SetActive(true);
        startFragment.SetActive(false);
    }

    public void signInCloseButton() {
        signInFragment.SetActive(false);
        startFragment.SetActive(true);
    }

    public void signUpCloseButton() {
        signUpFragment.SetActive(false);
        startFragment.SetActive(true);
    }
}
