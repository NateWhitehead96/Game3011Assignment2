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
        if(isLocked == false)
        {
            levelLock.GetComponent<SpriteRenderer>().color = Color.green;
        }
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
