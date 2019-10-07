using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour
{
    [SerializeField] // This is the object placed directly under the mouse
    private GameObject finalObject;

    [SerializeField] // This is the object placed adjacent to the finalObject
    private GameObject otherObject;

    [SerializeField] // This is the object placed adjacent to the finalObject
    private GameObject vineRemoval;

    private Vector3 otherRot = Vector3.right;

    private Vector2 mousePos;

    private int rotationVector = 0;

    private int currentRot = 0;

    [SerializeField] // This is the layer we're checking for other objects to make sure there's no overlap
    private LayerMask allTilesLayer;

    public GameObject[] cursors;

    private GameObject newCursor;

    private bool badPos = false;

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

            if (badPos == false)
            {
                Instantiate(finalObject, transform.position, Quaternion.identity);
                Instantiate(otherObject, transform.position + otherRot, Quaternion.identity);
                GetNewCursor();
                // Maybe SFX
                // This is when the tile is placed and a new, random cursor is created
                Destroy(gameObject);
            } else
            {
                // Maybe SFX
                // This is when there is something underneath the mouse, and the current domino is not placed
            }
        }

        if (Input.GetMouseButtonDown(1)) // when right-clicking, rotate the display and update where the otherObject gets placed relative to the finalObject
        {

            transform.Rotate(0, 0, 90);
            if (currentRot == 0)
            {
                otherRot = Vector3.up;
            }
            if (currentRot == 1)
            {
                otherRot = Vector3.left;
            }
            if (currentRot == 2)
            {
                otherRot = Vector3.down;
            }
            if (currentRot == 3)
            {
                otherRot = Vector3.right;
            }
            currentRot += 1;
            if (currentRot == 4)
            {
                otherRot = Vector3.right;
                currentRot = 0;
            }
        }

        if (Input.GetKeyDown("b"))
        {
            Instantiate(vineRemoval, transform.position, Quaternion.identity);
            Destroy(gameObject);
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
        if (other.gameObject.layer == 10)
        {
            badPos = true;
        } 
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.layer == 10)
        {
            badPos = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.layer == 10)
        {
            badPos = false;
        }
    }
}
