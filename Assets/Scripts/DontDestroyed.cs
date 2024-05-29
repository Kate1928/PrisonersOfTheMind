using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instatnce;
    // Start is called before the first frame update
    void Start()
    {
        if (instatnce != null) {
            Destroy(gameObject);
        }
        else {
            instatnce = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
}
