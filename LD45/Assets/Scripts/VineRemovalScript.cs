using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineRemovalScript : MonoBehaviour
{
    private Vector2 mousePos;

    public GameObject[] cursors;

    private GameObject vine;

    private GameObject newCursor;

    private bool goodPos = false;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast method of collision checking
            //Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            //RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, allTilesLayer);
            // if (rayHit.collider == null)

            if (goodPos == true)
            {
                Destroy(vine);
                GetNewCursor();
                // Maybe SFX
                // This is when the tile is placed and a new, random cursor is created
                Destroy(gameObject);
            }
            else
            {
                // Maybe SFX
                // This is when there is something underneath the mouse, and the current domino is not placed
            }
        }
    }

    void GetNewCursor()
    {
        int index = Random.Range(0, cursors.Length);
        Instantiate(cursors[index], transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "VineTile")
        {
            goodPos = true;
            vine = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "VineTile")
        {
            goodPos = true;
            vine = other.gameObject;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "VineTile")
        {
            goodPos = false;
        }
    }
}
