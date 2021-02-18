using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickBehaviour : MonoBehaviour
{
    [SerializeField] private float angle;
    public float turnRate;
    
    public static int level = 1;
    private Rigidbody2D selfrb;

    public Transform playerSpawn;
    private BoxCollider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        selfrb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(collider.size.x / level, collider.size.y / level); // reduce the size of collider base on player level to make the mazing easier
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() // movement 
    {
        if (Input.GetKey("w"))
        {
            // += -Vector3.up * level * Time.deltaTime;
            transform.position += -transform.up * Time.deltaTime;
        }
        if(Input.GetKey("s"))
        {
            transform.position += transform.up * Time.deltaTime;
        }

        if(Input.GetKey("a"))
        {
            angle -= turnRate * level * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if(Input.GetKey("d"))
        {
            angle += turnRate * level * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall")) // when hitting walls reset our position
        {
            print("hitting walls");
            transform.position = playerSpawn.position;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lock")) // when going over a lock pad visually show the user which lock it opens
        {
            if(Input.GetKey("space"))
            {
                print("opened lock");
                collision.GetComponent<LockScript>().levelLock.GetComponent<SpriteRenderer>().color = Color.green;
                collision.GetComponent<LockScript>().isLocked = false;
                //StartCoroutine(OpeningLock());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
    //IEnumerator OpeningLock()
    //{
    //    yield return new WaitForSeconds(1);
    //    LockManager.instance.numLocks--;
    //}
}
