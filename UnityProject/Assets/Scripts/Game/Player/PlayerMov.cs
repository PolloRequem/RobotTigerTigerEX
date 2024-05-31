using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMov : MonoBehaviour
{

    public float moveSpeed = 6f;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;
    private bool controlsEnabled = true;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameEventManager.instance.endLevel.onEndLevel += EndLevel_onEndLevel;
        GameEventManager.instance.startUpLevel.onStartUpLevel += StartUpLevel_onStartUpLevel1;
    }

    private void StartUpLevel_onStartUpLevel1()
    {
        moveSpeed = 4f;
    }

    private void EndLevel_onEndLevel()
    {
      
       StartCoroutine( DisableControlsAndMoveUp());
    }

    private IEnumerator DisableControlsAndMoveUp()
    {

        spriteRenderer.sprite = spriteUp;
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        controlsEnabled = false;
        yield return new WaitForSeconds(.5f);
        moveDirection = Vector2.up; 
    
    
    }


    void Update()
    {
        if (controlsEnabled)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = 1;
            SetSpriteAndRotation(spriteRight, 90f);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -1;
            SetSpriteAndRotation(spriteLeft, -90f);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y = -1;
            SetSpriteAndRotation(spriteDown, 0f);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y = 1;
            SetSpriteAndRotation(spriteUp, 180f);
        }
    }

    private void SetSpriteAndRotation(Sprite sprite, float rotationZ)
    {
        spriteRenderer.sprite = sprite;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 currentPosition = rb2D.position;
        Vector2 newPosition = currentPosition + moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb2D.MovePosition(newPosition);
    }
}
