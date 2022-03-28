using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public GameObject target;
    float smoothspeed=0.1f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPos = target.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothspeed);
        transform.position = smoothPos;
        transform.LookAt(target.transform);

    }

    public void offsetsetter(Vector3 _offset)
    {
        offset = _offset;
    }
}
