using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockManager : MonoBehaviour
{
    private static LockManager Instance;

    public static LockManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = GameObject.FindObjectOfType<LockManager>();
            }
            return Instance;
        }
    }
   
    public LockScript[] locks;
    public int numLocks;
    public Canvas optionCanvas;
    public bool passed;
    // Start is called before the first frame update
    void Start()
    {
        optionCanvas.gameObject.SetActive(false);
        passed = false;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            numLocks = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LockMedium"))
        {
            numLocks = 2;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LockHard"))
        {
            numLocks = 3;
        }
        print(locks.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (locks.Length == 1)
        {
            if (locks[0].isLocked == false)
            {
               //numLocks--;
                FindObjectOfType<Timer>().isTiming = false;
                passed = true;
            }
        }
        if (locks.Length == 2)
        {
            if (locks[0].isLocked == false && locks[1].isLocked == false)
            {
                //numLocks--;
                FindObjectOfType<Timer>().isTiming = false;
                passed = true;
            }
        }
        if (locks.Length == 3)
        {
            if (locks[0].isLocked == false && locks[1].isLocked == false && locks[2].isLocked == false)
            {
                //numLocks--;
                FindObjectOfType<Timer>().isTiming = false;
                passed = true;
            }
        }
        if(FindObjectOfType<Timer>().isTiming == false)
        {
            optionCanvas.gameObject.SetActive(true);
        }
    }
}
