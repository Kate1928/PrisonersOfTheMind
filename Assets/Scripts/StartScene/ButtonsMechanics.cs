using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMechanics : MonoBehaviour
{
     private const string saveKeyPlayer = "PLAYER_DATA";
    public GameObject moreFragment;
    public GameObject HelpFragment;
    public GameObject signInFragment;
    public GameObject signUpFragment;

    public GameObject startFragment;
    // Start is called before the first frame update
    public void startButton()
    {
        var data = saveHelper.Load<PlayerData>(saveKeyPlayer);
        if (data.level >= 1) {
            SceneManager.LoadScene(2);
        }
        SceneManager.LoadScene(1);
    }

    public void helpButton()
    {
        HelpFragment.SetActive(true);
    }

    public void moreButton()
    {
        moreFragment.SetActive(true);
    }

    public void moreClose()
    {
        moreFragment.SetActive(false);
    }
    
    public void closeHelp()
    {
        HelpFragment.SetActive(false);
    }

    public void signInButton()
    {
        signInFragment.SetActive(true);
        startFragment.SetActive(false);
    }

    public void signUpButton()
    {
        signUpFragment.SetActive(true);
        startFragment.SetActive(false);
    }

    public void signInCloseButton()
    {
        signInFragment.SetActive(false);
        startFragment.SetActive(true);
    }

    public void signUpCloseButton()
    {
        signUpFragment.SetActive(false);
        startFragment.SetActive(true);
    }
}
