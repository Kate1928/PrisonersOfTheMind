using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonsClards : MonoBehaviour, IPointerClickHandler
{
    public Sprite monster1;
    public Sprite monster2;
    public Sprite monster3;
    private const string saveKey = "LEVELS_DATA";

    public void buttonsClardsClick(int cardNumber) {
        //var data = saveHelper.Load<levelsData>(saveKey);
        switch (cardNumber)
        {
            case 1:
                GetComponent<Image>().sprite = monster1;
                SceneManager.LoadScene(3);
                break;
            case 2:
                GetComponent<Image>().sprite = monster2;
                SceneManager.LoadScene(3);
                break;
            case 3:
                GetComponent<Image>().sprite = monster3;
                SceneManager.LoadScene(3);
                break;
        }    
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name + " GameObgect");
        //monster.SetActive(true); 
        //SceneManager.LoadScene(3);  
    }
}
