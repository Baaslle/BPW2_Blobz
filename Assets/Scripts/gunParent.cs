using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunParent : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);


        if (rotationZ < -50 || rotationZ > 90)
        {

            if (Player.transform.eulerAngles.y <= 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);

            }
            else if (Player.transform.eulerAngles.y >= 180)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);

            }

        }
    }
}
