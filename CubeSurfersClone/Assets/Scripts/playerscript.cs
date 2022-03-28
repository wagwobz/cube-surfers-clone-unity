using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public GameObject GameManager;
    public float forward;
    public bool playerhit=false;
    int scoremultiplier;
    //private SwerweInput swerweInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhit == true)
        {
            transform.position = transform.position;
        }
    }

    private void FixedUpdate()
    {
        this.transform.Translate(0, 0, forward * Time.deltaTime);
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))

        {
            Debug.Log("gameover");
            forward = 0f;
            playerhit = true;
            GameManager.GetComponent<GameManager>().GameOver();
            
        }

        if (other.gameObject.CompareTag("lava"))

        {
            Debug.Log("gameover");
            forward = 0f;
            playerhit = true;
            GameManager.GetComponent<GameManager>().GameOver();

        }

        if (other.gameObject.CompareTag("finish"))

        {
            Debug.Log("playerfinish");
            forward = 0f;
            playerhit = true;
            GameManager.GetComponent<GameManager>().ScoreCalculate();
        }

        if (other.gameObject.CompareTag("fullfinish"))
        {
            Debug.Log("fullfinish");
            forward = 0f;
            playerhit = true;
            GameManager.GetComponent<GameManager>().ScoreCalculate();
        }
    }

    public bool PlayerHitBoolGetter()
    {
        return playerhit;
    }
}
