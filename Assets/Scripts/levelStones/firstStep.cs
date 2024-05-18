using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class firstStep : MonoBehaviour
{
    private string saveKey = "levelStoneData";
    public GameObject stone1Opponent;
    public GameObject stone2Opponent;
    private levelStone levelS = new levelStone();
    [SerializeField]
    public TMP_Text tMP_Dropdown1;
    [SerializeField]
    public TMP_Text tMP_Dropdown2;

    [SerializeField]
    List<int> allFreeStoneCount1 = new List<int> {01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 
    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25};
    void Start()
    {
        PlayerPrefs.SetInt("isFirstStep", 0);
        stone1Opponent.SetActive(true);
        stone2Opponent.SetActive(true);

        saveHelper.Save(saveKey, getLevelStoneData());         

        //var j = saveHelper.Load<levelStoneData>(saveKey);
        //var list = saveHelper.stringToList(j.allFreeStoneCount);
        //Debug.Log( " listString: " + j.stoneCount + j.s + j.allFreeStoneCount.Count);
        levelS.removeStone(2);
        
        
        //tMP_Dropdown2.text = j.stoneCount.ToString();
    }

    public levelStoneData getLevelStoneData() {
        var stoneData = new levelStoneData() {
            stoneCount = 0,
            allFreeStoneCount = allFreeStoneCount1//saveHelper.listToString(allFreeStoneCount1)
        };
        return stoneData;
    }
    
}
