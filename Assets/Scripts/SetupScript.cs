using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupScript : MonoBehaviour
{
    public Canvas HUD;
    public Canvas Options;
    public GameObject easylock;
    public GameObject player;
    public GameObject Lockman;

    public Text displayText;

    private void Start()
    {
        if (LockPickBehaviour.level == 1) // if its our first time playing we prompt the player
        {
            HUD.gameObject.SetActive(false);
            Options.gameObject.SetActive(false);
            easylock.SetActive(false);
            player.SetActive(false);
            Lockman.SetActive(false);

            displayText.text = "Your magical key must traverse the lock's mazes to open the chest! Using W to go forward, S to go backwards, A and D to turn make your way to the opening circles. Press Space to open the lock!";
            StartCoroutine(Whatever());
        }
        else Destroy(gameObject); // else skip this and play the level
    }
    IEnumerator Whatever()
    {
        yield return new WaitForSeconds(10);
        displayText.text = "Press space now to start!";
    }

    private void Update()
    {
        if(Input.GetKey("space"))
        {
            HUD.gameObject.SetActive(true);
            easylock.SetActive(true);
            player.SetActive(true);
            Lockman.SetActive(true);
            Destroy(gameObject);
        }
    }
}
