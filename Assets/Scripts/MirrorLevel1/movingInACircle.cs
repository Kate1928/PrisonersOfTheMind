using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingInACircle : MonoBehaviour, IPointerClickHandler
{
    private Vector2 startPos;
    private GameObject gameObject;
    public GameObject hintWindow; 
    public GameObject ImageAll;
    public GameObject ImagePart1;
    public GameObject ImagePart2;
    public GameObject ImagePart3;
    public GameObject ImagePart4;
    public GameObject imageEnd;
    
    private Level1 level1 = new Level1();

    
     public void OnPointerClick(PointerEventData eventData)
    {
        
        Debug.Log(name + " GameObgect" + eventData.position + "startPos" + startPos);
        gameObject = GameObject.Find(name);
        gameObject.transform.localScale = new Vector2(0.4f,0.4f);
        level1.saveImagePart(gameObject);
    }
    
    private void Start() {
        level1.initImage(ImageAll, ImagePart1, ImagePart2, ImagePart3, ImagePart4, imageEnd);
    }


    void Update()
    {
        
    }

    public void OkButton()
    {
        hintWindow.SetActive(false);
    }

   
}
