using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBuild : MonoBehaviour
{
    public GameObject[,] LockNodes;
    public GameObject node;

    const int rows = 3;
    const int cols = 3;

    
    private void Awake()
    {
        LockNodes = new GameObject[rows, cols];
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                Vector3 newPos = new Vector3(x * 0.5f - 2f, y * -0.5f + 2f, 0);

                LockNodes[x, y] = Instantiate(node, newPos, Quaternion.identity);
            }
        }
    }
    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            print("Mouse held");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Vector2 mouse2D = new Vector2(mousePos.x, mousePos.y);
            print(mouse2D);
            RaycastHit2D hit = Physics2D.Raycast(mouse2D, Vector2.zero);
            if (hit.collider != null)
            {
                print("Hitting");
                for (int x = 0; x < rows; x++)
                {
                    for (int y = 0; y < cols; y++)
                    {
                        if (hit.collider.gameObject.transform.position == LockNodes[x, y].transform.position)
                        {
                            print("Hitting nodes");
                            LockNodes[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                        }


                    }
                }
            }
        }





    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(LockNodes[0, 0].transform.position, LockNodes[0, 1].transform.position);
        Gizmos.DrawLine(LockNodes[0, 1].transform.position, LockNodes[1, 1].transform.position);
        Gizmos.DrawLine(LockNodes[1, 1].transform.position, LockNodes[2, 1].transform.position);
    }
}
