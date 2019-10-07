using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour
{
    
    private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private bool adjRight = false;
    private bool adjLeft = false;
    private bool adjUp = false;
    private bool adjDown = false;
    public bool completed = false;

    [SerializeField]
    private string tagCheck;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAdjacentRight();
        GetAdjacentLeft();
        GetAdjacentUp();
        GetAdjacentDown();
        if ((adjRight == true && adjLeft == true) ||
           (adjRight == true && adjUp == true) ||
           (adjRight == true && adjDown == true) ||
           (adjLeft == true && adjUp == true) ||
           (adjLeft == true && adjDown == true) ||
           (adjUp == true && adjDown == true))
        {
            completed = true;
        }
        if (Input.GetKeyDown("space"))
        {
            if (completed == true)
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Invoke("Ending", 0.5f);
        }
    }

    private void Ending()
    {
        
    }

    private void GetAdjacentRight()
    {
        Vector2 startPosition = new Vector2(transform.position.x + 1.0f, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.right, 0.5f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == tagCheck)
            {
                adjRight = true;
                if (hit.collider.gameObject.GetComponent<PumpkinScript>().completed == true)
                {
                    completed = true;
                };
            };
        }
    }
    private void GetAdjacentLeft()
    {
        Vector2 startPosition = new Vector2(transform.position.x - 1.0f, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.left, 0.5f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == tagCheck)
            {
                adjLeft = true;
                if (hit.collider.gameObject.GetComponent<PumpkinScript>().completed == true)
                {
                    completed = true;
                };
            };
        }
    }
    private void GetAdjacentUp()
    {
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y + 1.0f);
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.up, 0.5f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == tagCheck)
            {
                adjUp = true;
                if (hit.collider.gameObject.GetComponent<PumpkinScript>().completed == true)
                {
                    completed = true;
                };
            };
            
        }
    }
    private void GetAdjacentDown()
    {
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y - 1.0f);
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.down, 0.5f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == tagCheck)
            {
                adjDown = true;
                if (hit.collider.gameObject.GetComponent<PumpkinScript>().completed == true)
                {
                    completed = true;
                };
            };
        }
    }

}
