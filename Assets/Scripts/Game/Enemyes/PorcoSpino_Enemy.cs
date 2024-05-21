using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcoSpino_Enemy : Hittable
{
    public float moveSpeed = 3f; // Velocità di movimento del nemico
    public float rotationSpeed = 100f; // Velocità di rotazione del nemico
    public float rotationAngle = 45f; // Angolo massimo di rotazione del nemico

   // private bool moveRight = true;

    // Angolo massimo di rotazione del nemico

    private bool rotateRight = true;
    protected override void GetHit()
    {
        Die();
    }


    public void Update()
    {
        {
            //    // Movimento laterale del nemico
            //    if (moveRight)
            //    {
            //        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //    }
            //    else
            //    {
            //        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //    }

            //    // Rotazione del nemico
            //    if (transform.rotation.eulerAngles.z >= rotationAngle && transform.rotation.eulerAngles.z <= 180f)
            //    {
            //        moveRight = false;
            //    }
            //    else if (transform.rotation.eulerAngles.z <= 360 - rotationAngle && transform.rotation.eulerAngles.z > 180f)
            //    {
            //        moveRight = true;
            //    }

            //    if (moveRight)
            //    {
            //        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            //    }
            //    else
            //    {
            //        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            //    }
            //}
            {
                // Rotazione del nemico
                if (transform.rotation.eulerAngles.z >= rotationAngle && transform.rotation.eulerAngles.z <= 180f)
                {
                    rotateRight = false;
                }
                else if (transform.rotation.eulerAngles.z <= 360 - rotationAngle && transform.rotation.eulerAngles.z > 180f)
                {
                    rotateRight = true;
                }

                if (rotateRight)
                {
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}




