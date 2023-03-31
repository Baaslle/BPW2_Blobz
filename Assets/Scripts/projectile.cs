using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D tempCollider;
    public BoxCollider2D boxCollider;
    private bool isStuck = false;
    public float stickTime = 7f;
    private float currentStickTime = 0f;

    public Animator blobAnimator;

    public AudioSource slimesplatter;
    private bool blobissplattered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        if (isStuck)
        {
            if(currentStickTime < stickTime)
            {
                currentStickTime += Time.deltaTime;
            } else
            {
                StartCoroutine(destroyAfterSec()); 
            }
        }

    }
 

    IEnumerator destroyAfterSec()
    {
        
        blobAnimator.SetBool("Destroy", true);

        if(!blobissplattered)
        {
            slimesplatter.Play();
            blobissplattered = true;
        }

        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        stopMoving();
    }

    private void stopMoving()
    {
        //tempCollider = gameObject.AddComponent<BoxCollider2D>();
        //tempCollider.size = boxCollider.size;

        Destroy(gameObject.GetComponent<Rigidbody2D>());
       
        isStuck = true;
    }
}
