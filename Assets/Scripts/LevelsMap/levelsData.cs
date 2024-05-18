using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class levelsData
{
    public int level;
    public bool isOpen;

    public levelsData() {
        level = 1;
        isOpen = false;
    }
}
