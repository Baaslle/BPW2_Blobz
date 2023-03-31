using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public bool inTutorial = false;
    public TMP_Text tutorialText;

    private int phase = 0;
    public float delay;
    public float maxDelay;

    void Start()
    {
        inTutorial = true;
    }

    public void Update()
    {
        if (inTutorial)
        {
            if (delay < maxDelay)
            {
                delay += Time.deltaTime;
                return;
            }

            switch (phase)
            {
                case 0:

                    tutorialText.gameObject.SetActive(true);
                    tutorialText.text = "Move with WASD";
                    phase = 1;
                    delay = 0;
                    break;

                case 1:
                    if (checkForMove() == true)
                    {

                        delay = 0;
                        phase = 2;
                    }
                    break;

                case 2:

                    tutorialText.text = "Jump with the space bar";
                    
                    delay = 0;
                    
                    phase = 3;

                    break;

                case 3:

                    if (checkForJump() == true)
                    {
                        delay = 0;
                        phase = 4;
                    }
                    break;

                case 4:

                    tutorialText.text = "Shoot with Mouse1";
                    if (checkForShoot() == true)
                    {
                        delay = 0;
                        phase = 5;
                    }
                    break;

                case 5:

                    tutorialText.text = "Open the exit with the button";
                   
                    delay = 0;
                    phase = 6;
                    break;


            }
        }
    }
    private bool checkForShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            return true;
        }
        return false;
    }
    private bool checkForJump()
    {
        bool speedY = Input.GetButtonDown("Jump");

        if (speedY)
        {
            return true;
        }

        return false;
    }
    private bool checkForMove()
    {
        float speedX = Input.GetAxisRaw("Horizontal");

        if (speedX != 0)
        {
            return true;
        }

        return false;
    }
}
