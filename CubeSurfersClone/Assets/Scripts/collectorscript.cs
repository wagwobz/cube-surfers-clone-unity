using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectorscript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject player;
    public Camera mycamera;
    int collectorhit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("collect"))
        {
            GameManager.GetComponent<GameManager>().Instantiatecube();

            collectorhit++;

            Debug.Log("collectorscript");
            Debug.Log("colhit" + collectorhit);
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("turner"))
        {
            Debug.Log("turnerhit");
            player.transform.Rotate(0, 90, 0);
            mycamera.GetComponent<camerascript>().offsetsetter(new Vector3(-10,5,-3));
            player.GetComponent<SwerweMovement>().SwerweDirectionSetter(2);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (other.transform.CompareTag("crystal"))
        {
            Debug.Log("crystal");
            Destroy(other.gameObject);
            GameManager.GetComponent<GameManager>().CrystalCountIncrement();
        }

        if (other.gameObject.CompareTag("finish"))
        {
            switch (other.gameObject.name)
            {
                case "Finish 1x":
                    GameManager.GetComponent<GameManager>().ScoreMultiplierSetter(1);
                    break;

                case "Finish 2x":
                    GameManager.GetComponent<GameManager>().ScoreMultiplierSetter(2);
                    break;

                case "Finish 3x":
                    GameManager.GetComponent<GameManager>().ScoreMultiplierSetter(3);
                    break;

                case "Finish 4x":
                    GameManager.GetComponent<GameManager>().ScoreMultiplierSetter(4);
                    break;
            }
        }

        if (other.gameObject.CompareTag("fullfinish"))
        {
            GameManager.GetComponent<GameManager>().ScoreMultiplierSetter(10);
        }

    }
}
