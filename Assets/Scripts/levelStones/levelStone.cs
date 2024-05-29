using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class levelStone : MonoBehaviour,  IPointerClickHandler
{
    private const string saveKeyPlayer = "PLAYER_DATA";
    private PlayerData data = new PlayerData();
    int stoneCount = 0;
    List<int> allFreeStoneCount = new List<int> {01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 
    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25};
    bool isFirstStep = true;
    private string saveKey = "levelStoneData";
    private GameObject gameObject;
    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;

    public GameObject stone1Opponent;
    public GameObject stone2Opponent;
    public GameObject stone3Opponent;

    public GameObject errorText;
    public TMP_Text textEnd;

    private void errorMessage()
    {
        errorText.SetActive(true);
        Debug.Log(" error");
        Invoke("errorMessageOff", 5f);
    }

    private void errorMessageOff()
    {
        errorText.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var data = saveHelper.Load<levelStoneData> (saveKey);
        if (name == "Button")
        {
            return;
        }
        stoneCount = data.stoneCount;
        allFreeStoneCount = data.allFreeStoneCount;
        Debug.Log("allFreeStoneCount: " + allFreeStoneCount.Count);
        string stoneName = name;
        stoneName = stoneName.Substring(stoneName.Length - 2);

        if (stoneCount < 3) {
            stoneCount++;

            allFreeStoneCount.Remove(int.Parse(stoneName));

            stoneName = "free" + stoneName;
            Debug.Log("stoneName: " +  stoneName);
            gameObject = GameObject.Find(stoneName);
            gameObject.SetActive(false);
            switch (stoneCount)
            {
                case 1:
                    stone1.SetActive(true);
                    break;
                case 2:
                    stone2.SetActive(true);
                    break;
                case 3:
                    stone3.SetActive(true);
                    break;
            }
            saveHelper.Save(saveKey, getLevelStoneData());
        }
        else {
            errorMessage();
        }
    }

    private bool playerIsWin() {
        if(allFreeStoneCount.Count == 0)
            return false;
        return true;
    }

    public void takeButton() {

        stone1.SetActive(false);
        stone2.SetActive(false);
        stone3.SetActive(false);
        stone1Opponent.SetActive(false);
        stone2Opponent.SetActive(false);
        stone3Opponent.SetActive(false);

        var data = saveHelper.Load<levelStoneData>(saveKey);
        stoneCount = data.stoneCount;
        allFreeStoneCount = data.allFreeStoneCount;
        isFirstStep = data.isFirstStep;

        Debug.Log( "TakeButton \n allFreeStoneCount.Count: " + allFreeStoneCount.Count + "is" + isFirstStep);
        if(allFreeStoneCount.Count == 0) {
            textEnd.text = "Вы проиграли! Попробуйте еще раз.";
            textEnd.color = new Color (1, 1, 1, 1);
        }

        Invoke("computerStep", 2f);
        
    }

    //
    private void computerStep() {
        if (!isFirstStep) {
           getStoneCount();
        }
        stoneCountIsVisible();
        removeStone(stoneCount);
        
    }

    private void stoneCountIsVisible()
    {
        switch (stoneCount)
        {
            case 1:
                stone1Opponent.SetActive(true); 
                break;
            case 2:
                stone1Opponent.SetActive(true);
                stone2Opponent.SetActive(true); 
                break;
            case 3:
                stone1Opponent.SetActive(true); 
                stone2Opponent.SetActive(true);
                stone3Opponent.SetActive(true);
                break;
        }
    }

    //get count stone for +- optimal strategy (not player)
    private void getStoneCount()
    {
        if (allFreeStoneCount.Count > 3) {
            int four = (allFreeStoneCount.Count - 1) / 4 * 4;
            if (four == allFreeStoneCount.Count) {
                    stoneCount = UnityEngine.Random.Range(1, 4);
            }
            stoneCount = UnityEngine.Random.Range(1, allFreeStoneCount.Count - four + 1);
        }
        else {
            stoneCount = allFreeStoneCount.Count != 1 ? allFreeStoneCount.Count - 1 : 1;
        }
    }

    public void removeStone(int count)
    {
        int rnd = 0;
        string stoneName = "";
        for (int i = 0; i < count; i++) {
            rnd = allFreeStoneCount[UnityEngine.Random.Range(0, allFreeStoneCount.Count)];
            if (rnd < 10) 
                stoneName = "free0" + rnd;
            else 
                stoneName = "free" + rnd;
            Debug.Log( " allFreeStoneCount.Count: " + allFreeStoneCount.Count + "\n" +"Random: " + rnd + " name: " + stoneName);
            gameObject = GameObject.Find(stoneName);
            gameObject.SetActive(false);
            allFreeStoneCount.Remove(rnd);
        }
        if(allFreeStoneCount.Count == 0) {
            textEnd.text = "Вы выиграли!";
            textEnd.color = new Color (1, 1, 1, 1);
            saveHelper.Save(saveKeyPlayer, getPlayerData());
            Invoke("switchScene", 5f);
        }
        stoneCount = 0;
        saveHelper.Save(saveKey, getLevelStoneData());
    }
    public levelStoneData getLevelStoneData() {
        var stoneData = new levelStoneData() {
            stoneCount = stoneCount,
            allFreeStoneCount = allFreeStoneCount,
            isFirstStep = false
        };
        return stoneData;
    } 

    private void switchScene()
    {
        SceneManager.LoadScene(2);
    }
    public PlayerData getPlayerData() {
        var playerData = new PlayerData() {
            audioVolume = data.audioVolume,
            level = 4
        };
        return playerData;
    }
}
