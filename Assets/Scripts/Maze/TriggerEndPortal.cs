using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEndPortals : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D penguin) {
        SceneManager.LoadScene(2);        
    }
}
