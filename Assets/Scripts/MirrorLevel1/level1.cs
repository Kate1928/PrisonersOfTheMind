using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Level1 : MonoBehaviour
{
    private const string saveKeyPlayer = "PLAYER_DATA";
    private PlayerData data = new PlayerData();
    public struct cardInf {
        public bool isActive;
        public int number;
    }

    private const string saveKey = "MIRROR_LEVEL_DATA";
    private GameObject ImagePart1;
    private GameObject ImagePart2;
    private GameObject ImagePart3;
    private GameObject ImagePart4;
    private GameObject ImageAll;
    private GameObject allCards;
    private GameObject gameObject1, restartButton;
    private GameObject imageEnd;
    private TMP_Text textError;



    [SerializeField]
    public List<int> mirrors = new List<int>(); 

    void Start()
    {
         
    }

    public void initImage(
        GameObject gameObject, 
        GameObject ImagePart1, 
        GameObject ImagePart2, 
        GameObject ImagePart3, 
        GameObject ImagePart4,
        GameObject imageEnd,
        GameObject allCards,
        TMP_Text textError,
        GameObject restartButton)
    {
        ImageAll = gameObject;
        this.ImagePart1 = ImagePart1;
        this.ImagePart2 = ImagePart2;
        this.ImagePart3 = ImagePart3;
        this.ImagePart4 = ImagePart4;
        this.imageEnd = imageEnd;
        this.allCards = allCards;
        this.textError = textError;
        this.restartButton = restartButton;
    }

    public GameObject getImage(int Part)
    {
        GameObject image = null;
        switch(Part)
        {
            case 1:
                image = ImagePart1;
                break;
            case 2:
                image = ImagePart2;
                break;
            case 3:
                image = ImagePart3;
                break;
            case 4:
                image = ImagePart4;
                break;
        }
        return image;
    }

    private bool isWin()
    {
        bool isWin = true;
        for (int i = 0; i < 4; i++) {
            if (mirrors[i] != i + 1) {
                isWin = false;
            }
        }
        if (isWin)
            return true;
        return false;
    }

    public void drawFourImage()
    {
        ImageAll.SetActive(true);
        for (int i = 0; i < 4; i++) {
            var part = mirrors[i];
            gameObject1 = getImage(part);
            switch(i + 1)
            {
                case 1:
                    gameObject1.transform.position = new Vector3(-0.37f, 0.72f, -0.6f);
                    gameObject1.SetActive(true);
                    break;
                case 2:
                    gameObject1.transform.position = new Vector3(0.37f, 0.72f, -0.6f);
                    gameObject1.SetActive(true);
                    break;
                case 3:
                    gameObject1.transform.position = new Vector3(-0.37f, -0.72f, -0.6f);
                    gameObject1.SetActive(true);
                    break;
                case 4:
                    gameObject1.transform.position = new Vector3(0.37f, -0.72f, -0.6f);
                    gameObject1.SetActive(true);
                    break;
            }
        }
        
        if(isWin()) {
            UnityEngine.Debug.Log("isWin");
            imageEnd.SetActive(true);
            mirrors.Clear();
            saveHelper.Save(saveKey, getMirrorLevelData());
            //StartCoroutine(ExampleCoroutine());
            ImageAll.SetActive(false);
            allCards.SetActive(false);
            saveHelper.Save(saveKeyPlayer, getPlayerData());
            switchScene();
        }
        else {
            textError.color = new Color (1, 1, 1, 1);
            restartButton.SetActive(true);
        }
        
    }

    private void switchScene()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator ExampleCoroutine(bool restart)
    {
        yield return new WaitForSeconds(5);
        if(restart) {
            restartLevel();
        }
        else {
            switchScene();
        }
    }
    public void setIntPart(int part)
    {
        UnityEngine.Debug.Log("count: " + mirrors.Count); 
        mirrors.Add(part);
        UnityEngine.Debug.Log("count2: " + mirrors.Count); 
    }

    public void restartLevel() {
        mirrors.Clear();
        saveHelper.Save(saveKey, getMirrorLevelData());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void saveImagePart(GameObject gameObject) {
        var data = saveHelper.Load<mirrorLevelData>(saveKey);
        mirrors = data.mirrors;
        if(mirrors != null)
            UnityEngine.Debug.Log("Count: " + mirrors.Count); 
        
        if (gameObject.name == "ImageCenter") {
            if(mirrors != null && mirrors.Count == 4) {
                gameObject.SetActive(false);
                drawFourImage();
            }
            else {
                textError.color = new Color (1, 1, 1, 1);
                restartButton.SetActive(true);
            }
        }
        else {
            var gameObjectNumber = gameObject.name.Substring(gameObject.name.Length - 1);
            if (!mirrors.Exists(x => x == int.Parse(gameObjectNumber))) {
                setIntPart(int.Parse(gameObjectNumber));
            }
        }
        saveHelper.Save(saveKey, getMirrorLevelData()); 
    }
    public mirrorLevelData getMirrorLevelData() {
        var mirrorData = new mirrorLevelData() {
            mirrors = mirrors
        };
        return mirrorData;
    }

    public PlayerData getPlayerData() {
        var playerData = new PlayerData() {
            audioVolume = data.audioVolume,
            level = data.level < 2 ? 2 : data.level,
        };
        return playerData;
    }

}
