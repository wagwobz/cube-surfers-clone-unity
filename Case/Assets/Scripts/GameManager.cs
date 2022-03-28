using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cube;
    List<GameObject> cubelist;
    public GameObject player;
    public GameObject collector;
    int height;
    [SerializeField]
    private int scoremultiplier;
    [SerializeField]
    private int crystalcount;
    [SerializeField]
    private int finalscore;

    public Text crystaltext;
    public Text crystaltextcorner;
    public Text multipliertext;
    public Text totaltext;

    public GameObject finalpanel;
    public GameObject lostpanel;

    // Start is called before the first frame update
    void Start()
    {
        cubelist = new List<GameObject>();

        finalpanel.SetActive(false);
        lostpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<cubelist.Count; i++)
        {
            cubelist[i].transform.localPosition = new Vector3(0, -i-1, 0);
        }

        crystaltext.text = crystalcount.ToString();
        multipliertext.text = scoremultiplier.ToString();
        totaltext.text = finalscore.ToString();
        crystaltextcorner.text = crystalcount.ToString();
    }

    //Instantiate cube under the player and add it to the list
    public void Instantiatecube()
    {
        height++;
        GameObject cub = Instantiate(cube, player.transform);
        try
        {
            cubelist.Add(cub);
        }
        catch
        {

        }
        int position = cubelist.Count;
        cub.GetComponent<cubescript>().Indexer(position);
        Debug.Log(position);
        cub.transform.localPosition = new Vector3(0,-cubelist.IndexOf(cub), 0);
        player.transform.position = player.transform.position+ new Vector3(0, 1, 0);
        collector.transform.position = collector.transform.position + new Vector3(0, -1, 0);

        Debug.Log("instantiate");
    }

    /* list mechanics control
    public void RemoveCube()
    {
        height--;
        Destroy(cubelist[cubelist.Count - 2]);
        cubelist.Remove(cubelist[cubelist.Count - 2]);
        player.transform.position = new Vector3(0, height, 0);

    }
    */
    public int ListIndexGet(GameObject _cub)
    {
        int i = cubelist.IndexOf(_cub);
        return i;
    }

    public void RemoveFromList(int _index)
    {
        cubelist.Remove(cubelist[_index]);
        StartCoroutine(dropdowndelay());
    }

    public void AddToList(GameObject _cube)
    {
        cubelist.Add(_cube);
    }

    IEnumerator dropdowndelay()
    {
        yield return new WaitForSeconds(0.2f);
        player.transform.position = player.transform.position + new Vector3(0, -1, 0);
        collector.transform.position = collector.transform.position + new Vector3(0, +1, 0);
    }

    public void GameOver()
    {
        lostpanel.SetActive(true);
    }

    public void ScoreCalculate()
    {
        finalscore = crystalcount * scoremultiplier;
        finalpanel.SetActive(true);
    }

    public void ScoreMultiplierSetter(int i)
    {
        scoremultiplier = i;
    }

    public void CrystalCountIncrement()
    {
        crystalcount++;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
