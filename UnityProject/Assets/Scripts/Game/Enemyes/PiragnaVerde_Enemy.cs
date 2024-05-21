using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiragnaVerde_Enemy : Hittable
{
  //  public GameObject gameObject;

    public float speed = 5f; // velocità di movimento del personaggio
    public float distance = 5f; // distanza da percorrere avanti e indietro

    private Vector3 startPosition; // posizione iniziale del personaggio
    private bool movingRight = true;

    protected override void GetHit()
    {
        Die();
    }
    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, gameObject.transform.position, speed * Time.deltaTime);

        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // muovo verso destra
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // muovo verso sinistra
        }

        // Controllo se il personaggio ha raggiunto la fine della sua corsa
        if (Mathf.Abs(transform.position.x - startPosition.x) >= distance)
        {
            // Cambio la direzione del movimento
            movingRight = !movingRight;

            // Inverto la scala del personaggio per farlo girare
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
    

