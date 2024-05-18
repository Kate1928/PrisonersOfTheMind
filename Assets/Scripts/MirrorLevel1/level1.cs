using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    private GameObject ImagePart1;
    private GameObject ImagePart2;
    private GameObject ImagePart3;
    private GameObject ImagePart4;
    private GameObject ImageAll;
    private GameObject gameObject1;
    private GameObject imageEnd;

    private int countGameObgect = 0;
    private List<GameObject> gameObjects = new List<GameObject>();

    void Start()
    {
         
    }

    public void initImage(
        GameObject gameObject, 
        GameObject ImagePart1, 
        GameObject ImagePart2, 
        GameObject ImagePart3, 
        GameObject ImagePart4,
        GameObject imageEnd)
    {
        ImageAll = gameObject;
        this.ImagePart1 = ImagePart1;
        this.ImagePart2 = ImagePart2;
        this.ImagePart3 = ImagePart3;
        this.ImagePart4 = ImagePart4;
        this.imageEnd = imageEnd;
    }

    public GameObject getImage(String Part)
    {

        GameObject image = null;
        switch(Part)
        {
            case "1":
                image = ImagePart1;
                break;
            case "2":
                image = ImagePart2;
                break;
            case "3":
                image = ImagePart3;
                break;
            case "4":
                image = ImagePart4;
                break;
        }
        return image;
    }

    private bool isAllGameObgects()
    {
        if(PlayerPrefs.GetInt("CountGameObgect") > 11)
            return true;
        return false;
    }

    private bool isWin()
    {
        if (PlayerPrefs.GetString("Part1") == "1"
            && PlayerPrefs.GetString("Part2") == "2"
            && PlayerPrefs.GetString("Part3") == "3"
            && PlayerPrefs.GetString("Part4") == "4")
            return true;
        return false;
    }

    public void drawFourImage()
    {
        PlayerPrefs.SetInt("CountGameObgect", 0);
        countGameObgect = 0;
        ImageAll.SetActive(true);
        String Part = PlayerPrefs.GetString("Part1");
        UnityEngine.Debug.Log("gameObject: " + Part);
        gameObject1 = getImage(Part);
        if(gameObject1 != null) {
            gameObject1.transform.position = new Vector3(-0.3f, 0.6f, -0.6f);
            UnityEngine.Debug.Log("gameObject: " + gameObject1.name + "position: " + gameObject1.transform.position);
        }
        Part = PlayerPrefs.GetString("Part2");
        gameObject1 = getImage(Part);
        if(gameObject1 != null) {
            gameObject1.transform.position = new Vector3(0.3f, 0.6f, -0.6f);
            UnityEngine.Debug.Log("gameObject: " + gameObject1.name + "position: " + gameObject1.transform.position);
        }
        
        Part = PlayerPrefs.GetString("Part3");
        gameObject1 = getImage(Part);
        if(gameObject1 != null) {
            gameObject1.transform.position = new Vector3(-0.3f, -0.25f, -0.6f);
            UnityEngine.Debug.Log("gameObject: " + gameObject1.name + "position: " + gameObject1.transform.position);
        }
        
        Part = PlayerPrefs.GetString("Part4");
        gameObject1 = getImage(Part);
        if(gameObject1 != null) {
            gameObject1.transform.position = new Vector3(0.3f, -0.25f, -0.6f);
            UnityEngine.Debug.Log("gameObject: " + gameObject1.name + "position: " + gameObject1.transform.position);
        }
        UnityEngine.Debug.Log("gameObjects: " + gameObjects);

        if(isWin()) {
            UnityEngine.Debug.Log("isWin");
            imageEnd.SetActive(true);
            //StartCoroutine(ExampleCoroutine());
            ImageAll.SetActive(false);
            PlayerPrefs.DeleteAll();
            //StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
    }
    public void setStringPart(String part)
    {
        if(!PlayerPrefs.HasKey("Part1")){
        PlayerPrefs.SetString("Part1", part);
        }
        else if(!PlayerPrefs.HasKey("Part2")) {
            PlayerPrefs.SetString("Part2", part);
        }
        else if(!PlayerPrefs.HasKey("Part3")) {
            PlayerPrefs.SetString("Part3", part);
        }
        else if(!PlayerPrefs.HasKey("Part4")) {
            PlayerPrefs.SetString("Part4", part);
        }
        UnityEngine.Debug.Log("part: " + part);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void saveImagePart(GameObject gameObject)
    {
        countGameObgect = PlayerPrefs.GetInt("CountGameObgect");
        countGameObgect++;
        PlayerPrefs.SetInt("CountGameObgect", countGameObgect);
        UnityEngine.Debug.Log("Count: " + countGameObgect); 
        switch (gameObject.name)
            {
                case "Loading_free_purple1":
                    setStringPart("1");
                    break;
                case "Loading_free_purple2":
                    setStringPart("2");
                    break;
                case "Loading_free_purple3":
                    setStringPart("3");
                    break;
                case "Loading_free_purple4":
                    setStringPart("4");
                    break;
                case "Loading_free_greenCenter":
                    if(isAllGameObgects()) {
                        gameObject.SetActive(false);
                        drawFourImage();
                    }
                    else {
                        PlayerPrefs.DeleteAll();
                        restartLevel();
                    }
                    break;
            } 
            //Debug.Log(gameObjects.Count); 
    }

}
