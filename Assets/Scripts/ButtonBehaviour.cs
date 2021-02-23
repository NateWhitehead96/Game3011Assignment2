using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void OnEasy()
    {
        SceneManager.LoadScene("MainScene");
        if (LockManager.instance.passed)
        {
            LockPickBehaviour.level++;
        }
    }
    public void OnMedium()
    {
        SceneManager.LoadScene("LockMedium");
        if (LockManager.instance.passed)
        {
            LockPickBehaviour.level++;
        }
    }
    public void OnHard()
    {
        SceneManager.LoadScene("LockHard");
        if (LockManager.instance.passed)
        {
            LockPickBehaviour.level++;
        }
    }
}
