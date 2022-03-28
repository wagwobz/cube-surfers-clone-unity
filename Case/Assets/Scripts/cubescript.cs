using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour
{
    [SerializeField]
    int index;
    public GameObject GameManager; 
    public GameObject collector;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        index = GameManager.GetComponent<GameManager>().ListIndexGet(gameObject) + 1;
    }

    public void Indexer(int _index)
    {
        index = _index;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("obstacle"))
        {
            Debug.Log("cubescript");
            GameManager.GetComponent<GameManager>().RemoveFromList(index-1);
            gameObject.transform.parent = null;
            other.GetComponent<BoxCollider>().enabled = false;
            
        }

        if (other.transform.CompareTag("finish"))
        {
            Debug.Log("finish");
            GameManager.GetComponent<GameManager>().RemoveFromList(index - 1);
            Destroy(gameObject);
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if (other.gameObject.CompareTag("fullfinish"))
        {
            Debug.Log("fullfinish");
            GameManager.GetComponent<GameManager>().RemoveFromList(index - 1);
            Destroy(gameObject);
        }

        if (other.transform.CompareTag("lava"))
        {
            StartCoroutine(lavadelay());
        }
    }

    IEnumerator lavadelay()
    {
        yield return new WaitForSeconds(0.3f);
        GameManager.GetComponent<GameManager>().RemoveFromList(index - 1);
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);
    }



    }
