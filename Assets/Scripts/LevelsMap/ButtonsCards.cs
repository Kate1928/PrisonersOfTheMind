using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonsClards : MonoBehaviour
{
    public Sprite monster1;
    public Sprite monster2;
    public Sprite monster3;
    public GameObject card1, card2, card3;
    private const string saveKey = "PLAYER_DATA";
    private PlayerData data = new PlayerData();
    void Start() {
        data = saveHelper.Load<PlayerData>(saveKey);
        switch (data.level)
        {
            case 2:
                card1.GetComponent<Image>().sprite = monster1;
                break;
            case 3:
                card1.GetComponent<Image>().sprite = monster1;
                card2.GetComponent<Image>().sprite = monster2;
                break;
            case 4:
                card1.GetComponent<Image>().sprite = monster1;
                card2.GetComponent<Image>().sprite = monster2;
                card3.GetComponent<Image>().sprite = monster3;
                break;
        }
    }

    public void buttonsClardsClick(int cardNumber) {
        data = saveHelper.Load<PlayerData>(saveKey);
        switch (cardNumber)
        {
            case 1:
                if (data.level >= cardNumber) {
                    GetComponent<Image>().sprite = monster1;
                    SceneManager.LoadScene(3);
                }
                break;
            case 2:
                if (data.level >= cardNumber) {
                    GetComponent<Image>().sprite = monster2;
                    SceneManager.LoadScene(4);
                }
                break;
            case 3:
                if (data.level >= cardNumber) {
                    GetComponent<Image>().sprite = monster3;
                    SceneManager.LoadScene(5);
                }
                break;
        }    
    }
   
}
