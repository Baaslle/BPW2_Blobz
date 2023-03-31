using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour
{
    public Sprite doorClosed;
    public Sprite doorOpen;
    public SpriteRenderer sprRndDoor;
    public BoxCollider2D doorBox;

    public SpriteRenderer sprRndButton;
    public Sprite buttonLit;
    public Sprite buttonUnlit;

    public AudioSource buttonaudio;
    private bool buttonisPressed = false;

    public AudioSource dooraudio;
    private bool doorisOpened = false;

    public AudioSource doorCloseaudio;
 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob"))
        { 
            openDoor();
            buttonPressed();

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blob"))
        {
            closedDoor();
            buttonUnpressed();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob"))
        {
            closedDoor();
            buttonUnpressed();
        }

    }

    public void buttonPressed()
    {
        sprRndButton.sprite = buttonLit;

        if (!buttonisPressed)
        {
            buttonisPressed = true;
            buttonaudio.Play();
        }
    }

    public void buttonUnpressed()
    {
        sprRndButton.sprite = buttonUnlit;

        buttonisPressed = false;
    }

    public void closedDoor()
    {
        doorBox.enabled = true;
        sprRndDoor.sprite = doorClosed;

        doorisOpened = false;

        doorCloseaudio.Play();

    }

    public void openDoor()
    {
        doorBox.enabled = false;
        sprRndDoor.sprite = doorOpen;

        if (!doorisOpened)
        {
            doorisOpened = true;
            dooraudio.Play();
        }
    }
}
