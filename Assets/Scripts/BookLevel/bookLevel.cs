using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bookLevel : MonoBehaviour
{
    public GameObject informationText;
    public TMP_InputField answer;
    public TMP_Text textEnd;

    public GameObject helpFragment;
    public TMP_Text textHelp;

    public const string rightAnswer = "скорпион";
    public const string help1 = "Найдите синоним слову 'быстр'";
    public const string help2 = "3.14";
    public const string help3 = "Вспомните местоимения";

    public void informationTextOff()
    {
        informationText.SetActive(false);
    }

    public void setAnswer() {
        Debug.Log("answer: " + answer.text.ToLower());
        if (rightAnswer.Equals(answer.text.ToLower())) {
            textEnd.text = "Вы выиграли!";
            textEnd.color = new Color (1, 1, 1, 1);
            Invoke("switchScene", 5f);
        }
        else {
            textEnd.text = "Не верно. Попробуйте еще раз.";
            textEnd.color = new Color (1, 1, 1, 1);
            Invoke("errorMessageOff", 5f);
        }
    }

    private void errorMessageOff() {
        textEnd.color = new Color (1, 1, 1, 0);
    }

    public void helpButton(int numberHelp) {
        switch (numberHelp)
        {
            case 1:
                helpFragment.SetActive(true);
                textHelp.text = help1;
                break;
            case 2:
                helpFragment.SetActive(true);
                textHelp.text = help2;
                break;
            case 3:
                helpFragment.SetActive(true);
                textHelp.text = help3;
                break;
        }

    }
    public void helpFragmentOff()
    {
        helpFragment.SetActive(false);
    }

    private void switchScene()
    {
        SceneManager.LoadScene(2);
    }

}
