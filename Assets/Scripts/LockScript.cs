using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public GameObject levelLock;
    public bool isLocked;
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelLock.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnTriggerExit(Collider other)
    {
        levelLock.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
