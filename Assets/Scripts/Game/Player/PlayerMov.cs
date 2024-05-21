using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float move_Speed = 6f;
    public Sprite spriteSu;
    public Sprite spriteGiu;
    public Sprite spriteSinistra;
    public Sprite spriteDestra;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    Vector3 movDir3;
    Vector2 movDir;
    private Quaternion originalRotation;
    private bool ruotatoaDestra = false;
    private bool ruotatoaSinistra = false;
    private bool ruotatoInAlto = false;
    private bool ruotatoInBasso = false;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //  rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        originalRotation = transform.rotation;
       // GameEventManager.instance.startUpLevel.onStartUpLevel += StartUpLevel_onStartUpLevel;
    }

    private void StartUpLevel_onStartUpLevel()
    {
        move_Speed = 4f;
    }

    void Update()
    {
        Vector3 movDir = new Vector2();
        if (Input.GetKey(KeyCode.D))
        {
            movDir.x += 1;
            if (!ruotatoaDestra)
            {
                transform.rotation = originalRotation;
                ruotatoaSinistra = false;
                ruotatoInAlto = false;
                ruotatoInBasso = false;
                 transform.Rotate(Vector3.forward, 90f);
                ruotatoaDestra = true;
            }
            spriteRenderer.sprite = spriteDestra;
         
        }
      

        if (Input.GetKey(KeyCode.A))
        {
            movDir.x -= 1;
            if (!ruotatoaSinistra)
            {
                transform.rotation = originalRotation;
                ruotatoaDestra = false;    
                ruotatoInAlto = false;
                ruotatoInBasso = false;
                transform.Rotate(Vector3.forward, -90f);
                ruotatoaSinistra = true;
            }
            spriteRenderer.sprite = spriteSinistra;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movDir.y -= 1;
            
            if (!ruotatoInAlto)
            {
                transform.rotation = originalRotation;
                ruotatoaSinistra = false;
                ruotatoaDestra = false;
                ruotatoInBasso = false;
                ruotatoInAlto = true;
            }
            spriteRenderer.sprite = spriteGiu;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movDir.y += 1;
          
            if (!ruotatoInBasso)
            {
                transform.rotation = originalRotation;
                ruotatoaSinistra = false;
                ruotatoaDestra = false;
                ruotatoInAlto = false;
                transform.Rotate(Vector3.forward, 180f);
                ruotatoInBasso = true;
            }
            spriteRenderer.sprite = spriteGiu;
        }
        movDir3 = new Vector3(movDir.x, movDir.y).normalized;

        if (movDir != Vector3.zero)
        {
        //    GameEventManager.instance.playerMoving.PlayerMoving();
        }
       
       
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + movDir3 * move_Speed * Time.fixedDeltaTime);
    }
}
