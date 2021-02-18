using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickBehaviour : MonoBehaviour
{
    [SerializeField] private float angle;
    public float turnRate;
    
    public static int level;
    private Rigidbody2D selfrb;

    public Transform playerSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        selfrb = GetComponent<Rigidbody2D>();
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey("w"))
        {
            // += -Vector3.up * level * Time.deltaTime;
            transform.position += -transform.up * level * Time.deltaTime;
        }
        if(Input.GetKey("s"))
        {
            transform.position += transform.up * level * Time.deltaTime;
        }

        if(Input.GetKey("a"))
        {
            angle -= turnRate * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if(Input.GetKey("d"))
        {
            angle += turnRate * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            print("hitting walls");
            transform.position = playerSpawn.position;
            transform.rotation = Quaternion.identity;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lock"))
        {
            if(Input.GetKey("space"))
            {
                print("opened lock");
                collision.GetComponent<LockScript>().levelLock.GetComponent<SpriteRenderer>().color = Color.green;
                collision.GetComponent<LockScript>().isLocked = false;
                StartCoroutine(OpeningLock());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
    IEnumerator OpeningLock()
    {
        yield return new WaitForSeconds(1);
        LockManager.instance.numLocks--;
    }
}
