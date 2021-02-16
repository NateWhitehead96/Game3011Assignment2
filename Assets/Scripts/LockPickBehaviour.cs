using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickBehaviour : MonoBehaviour
{
    private Vector3 MoveVector;
    

    private SpriteRenderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveVector = new Vector3(1, 0, 0);
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKey("a") && transform.position.x >= -4)
        {
            transform.position -= MoveVector * Time.deltaTime;
        }
        if(Input.GetKey("d") && transform.position.x <= 4)
        {
            transform.position += MoveVector * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //renderer.color = Color.Lerp(Color.black, Color.red, Time.deltaTime);
        renderer.color = Color.gray;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //transform.position = new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, 0);
        print("in the lock");
        if(Input.GetKey("space"))
        {
            print("Unlocking the easy box");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        renderer.color = Color.black;
    }

}
