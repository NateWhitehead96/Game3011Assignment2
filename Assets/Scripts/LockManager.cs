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
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public LockScript[] locks;
    public int numLocks;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            numLocks = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LockMedium"))
        {
            numLocks = 2;
        }
        print(locks.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (locks.Length == 1)
        {
            for (int i = 0; i < locks.Length; i++)
            {
                if (locks[i].isLocked == false)
                {
                    //numLocks--;
                    FindObjectOfType<Timer>().isTiming = false;
                }
            }
        }
        if (locks.Length == 2)
        {
            for (int i = 0; i < locks.Length; i++)
            {
                if (locks[i].isLocked == false && locks[i + 1].isLocked == false)
                {
                    //numLocks--;
                    FindObjectOfType<Timer>().isTiming = false;
                }
            }
        }
        
    }
}
