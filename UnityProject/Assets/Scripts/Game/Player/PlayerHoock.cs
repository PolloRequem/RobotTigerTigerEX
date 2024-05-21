using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHook : MonoBehaviour
{
    public Animator animator;
    private bool isHooking = false;

    private BoxCollider2D boxCollider2D;


    public void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isHooking)
        {
            isHooking = true;

            animator.SetTrigger("hoock");
            StartCoroutine(MyCoroutine());
            boxCollider2D.enabled = true;



        }


       
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NonColpibile") && isHooking)
        {
            print("nonColpibile");
            animator.SetTrigger("RitornaHOOCK");
            isHooking = false;
        }
        if (other.CompareTag("Enemy") && isHooking)
        {
           
            other.GetComponent<Hittable>().BasicHit();
          
            isHooking = false;
        }
    }

    IEnumerator MyCoroutine()
    {
      
        yield return new  WaitForSeconds(0.5f);
        isHooking = false;
        boxCollider2D.enabled = false;

    }
}