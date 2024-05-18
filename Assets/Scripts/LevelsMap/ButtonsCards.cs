using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonsClards : MonoBehaviour, IPointerClickHandler
{
    public GameObject monster;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name + " GameObgect");
        monster.SetActive(true); 
        SceneManager.LoadScene(3);  
    }
}
