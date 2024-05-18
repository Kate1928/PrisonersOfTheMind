using UnityEngine;

public class TriggerPortals : MonoBehaviour
{
    public GameObject NextPortal = null;
    private void OnTriggerEnter2D(Collider2D penguin) {
        if (NextPortal != null) {
            Debug.Log("NextPortal: " + NextPortal.name);
            penguin.transform.position = GameObject.Find(NextPortal.name).transform.position;
        }
        
    }
}
