using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMechanics : MonoBehaviour
{
    const int MOVE_UP = 1;
    const int MOVE_DOWN = -1;
    const int MOVE_RIGHT = 2;
    const int MOVE_LEFT = -2;
    public GameObject penguin;
    public GameObject lightPlayer;
    private float direction = 0;
    private float directionX = 0;
    private float directionY = 0;
    private Vector2 startPos;
    private float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightPlayer.transform.position = penguin.transform.position;
        switch (direction)
        {
            case MOVE_UP:
                penguin.transform.Translate(0, (Speed > 0 ? Speed : -Speed) * Time.deltaTime, 0);
                break;
            case MOVE_DOWN:
                penguin.transform.Translate(0, (Speed < 0 ? Speed : -Speed) * Time.deltaTime, 0);
                break ;
            case MOVE_RIGHT:
                penguin.transform.Translate((Speed > 0 ? Speed : -Speed) * Time.deltaTime, 0, 0);
                break;
            case MOVE_LEFT:
                penguin.transform.Translate((Speed < 0 ? Speed : -Speed) * Time.deltaTime, 0, 0); 
                break;
        }
        
        if(Input.touchCount > 0)
        {
            
            //#if !UNITY_EDITOR
            if( Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //direction = 0;
                startPos = Input.GetTouch(0).position;
            }
                
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
                directionX = Input.GetTouch(0).position.x - startPos.x;
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
                directionY = Input.GetTouch(0).position.y - startPos.y;
            if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
                direction = directionY > 0 ? 1 : -1;
            else
                direction = directionX > 0 ? 2 : -2;
            //direction = 0;
            //#endif
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
            direction = -2;
        if(Input.GetKeyDown(KeyCode.RightArrow))
            direction = 2;
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
            direction = 1;
        if(Input.GetKeyDown(KeyCode.DownArrow))
            direction = -1;
    }
}
