using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerweInputSystem : MonoBehaviour
{

    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _moveFactorX = Input.GetTouch(0).position.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.GetTouch(0).position.x;
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _moveFactorX = 0f;
            }
        }

       





    }
}
