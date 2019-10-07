using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringScript : MonoBehaviour
{
    public int score;

    private GameObject[] SpookyArray;
    private GameObject[] SillyArray;
    private GameObject[] SweetArray;

    private bool spookyCulled = false;
    private bool sillyCulled = false;
    private bool sweetCulled = false;

    [SerializeField]
    private GameObject vineRemoval;

    private GameObject cursor;

    public int removalCost;

    private int scoreToAdd;

    private int multiplier;

    public GameObject[] cursors;

    public Text scoreText;
    public Text vineText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        removalCost = 5;
        multiplier = 0;
        GetNewCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Invoke("CullPumpkins", 2f);
        }
        if (Input.GetKeyDown("b"))
        {
            VineRemoval();
        }
        scoreText.text = score.ToString();
        vineText.text = removalCost.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void GetNewCursor()
    {
        int index = Random.Range(0, cursors.Length);
        Instantiate(cursors[index], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }

    public void VineRemoval()
    {
        if (score >= removalCost)
        {
            cursor = GameObject.FindGameObjectWithTag("Cursors");
            Destroy(cursor);
            score -= removalCost;
            removalCost += 5;
            Instantiate(vineRemoval, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    public void CullPumpkins()
    {
        SpookyArray = GameObject.FindGameObjectsWithTag("Spooky");
        foreach (GameObject pumpkin in SpookyArray)
        {
            if(pumpkin.GetComponent<PumpkinScript>().completed == true)
            {
                scoreToAdd += 1;
                Destroy(pumpkin);
                spookyCulled = true;
            }
        }

        SillyArray = GameObject.FindGameObjectsWithTag("Silly");
        foreach (GameObject pumpkin in SillyArray)
        {
            if (pumpkin.GetComponent<PumpkinScript>().completed == true)
            {
                scoreToAdd += 1;
                Destroy(pumpkin);
                sillyCulled = true;
            }
        }

        SweetArray = GameObject.FindGameObjectsWithTag("Sweet");
        foreach (GameObject pumpkin in SweetArray)
        {
            if (pumpkin.GetComponent<PumpkinScript>().completed == true)
            {
                scoreToAdd += 1;
                Destroy(pumpkin);
                sweetCulled = true;
            }
        }

        if (spookyCulled == true) {
            multiplier += 1;
        }
        if (sillyCulled == true)
        {
            multiplier += 1;
        }
        if (sweetCulled == true)
        {
            multiplier += 1;
        }
        score += (scoreToAdd * multiplier);
        multiplier = 0;
        scoreToAdd = 0;
        spookyCulled = false;
        sillyCulled = false;
        sweetCulled = false;
        /*
        if (culled == true)
        {
            UpdateScore();
        }
        */
    }


}
