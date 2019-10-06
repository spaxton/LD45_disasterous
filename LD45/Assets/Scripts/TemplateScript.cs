using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;

    private int rotationVector = 0;

    [SerializeField]
    private LayerMask allTilesLayer;

    public GameObject[] cursors;

    private GameObject newCursor;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, allTilesLayer);

            if (rayHit.collider == null)
            {
                Instantiate(finalObject, transform.position, Quaternion.Euler(0,0, z: (0 + rotationVector)));
                GetNewCursor();
                Destroy(this);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0, 0, 90);
            rotationVector += 90;
        }
    }

    void GetNewCursor()
    {
        int index = Random.Range(0, cursors.Length);
        Instantiate(cursors[index], transform.position, Quaternion.identity);
    }
}
