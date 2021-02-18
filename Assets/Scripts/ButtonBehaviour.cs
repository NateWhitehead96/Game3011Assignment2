using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void OnEasy()
    {
        SceneManager.LoadScene("MainScene");
        LockPickBehaviour.level++;
    }
    public void OnMedium()
    {
        SceneManager.LoadScene("LockMedium");
        LockPickBehaviour.level++;
    }
    public void OnHard()
    {
        SceneManager.LoadScene("LockHard");
        LockPickBehaviour.level++;
    }
}
