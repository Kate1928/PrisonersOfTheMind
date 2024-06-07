using TMPro;
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
    public GameObject allCards, restartButton;
    public TMP_Text textError;
    
    private Level1 level1 = new Level1();
    private const string saveKey = "MIRROR_LEVEL_DATA";

    
    public void OnPointerClick(PointerEventData eventData) {  
        Debug.Log(name + " GameObgect" + eventData.position + "startPos" + startPos);
        gameObject = GameObject.Find(name);
        gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
        level1.saveImagePart(gameObject);
    }
    
    private void Start() {
        level1.initImage(ImageAll, ImagePart1, ImagePart2, ImagePart3, ImagePart4, imageEnd, allCards, textError, restartButton);
    }


    void Update()
    {
        
    }

    public void OkButton() {
        hintWindow.SetActive(false);
    }

   
}
