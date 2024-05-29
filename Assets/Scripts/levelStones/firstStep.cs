using System.Collections.Generic;
using UnityEngine;

public class firstStep : MonoBehaviour
{
    private string saveKey = "levelStoneData";
    public GameObject stone1Opponent;
    public GameObject stone2Opponent;
    private levelStone levelS = new levelStone();

    public GameObject informationText;

    [SerializeField]
    List<int> allFreeStoneCount1 = new List<int> {01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 
    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25};
    void Start()
    {
        
    }

    public levelStoneData getLevelStoneData() {
        var stoneData = new levelStoneData() {
            stoneCount = 0,
            allFreeStoneCount = allFreeStoneCount1,
            isFirstStep = false
        };
        return stoneData;
    }

    public void informationTextOff()
    {
        informationText.SetActive(false);
        
        stone1Opponent.SetActive(true);
        stone2Opponent.SetActive(true);

        saveHelper.Save(saveKey, getLevelStoneData());         
        levelS.removeStone(2);
    }
    
}
