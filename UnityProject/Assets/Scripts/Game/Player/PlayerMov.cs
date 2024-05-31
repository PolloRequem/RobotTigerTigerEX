using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour
{
    private float D_moveSpeed;
    private float U_moveSpeed;
    public float moveSpeed;
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


        SetDifficultySpeed();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      //  GameEventManager.instance.endLevel.onEndLevel += EndLevel_onEndLevel;
        GameEventManager.instance.startUpLevel.onStartUpLevel += StartUpLevel_onStartUpLevel1;
        moveSpeed = D_moveSpeed;
    }

    private void SetDifficultySpeed()
    {
        switch (GameStateManager.current_gameDifficulty)
        {
            case GameDifficulty.EASY:

                D_moveSpeed = 6f;
                U_moveSpeed = 4f;
                break;

            case GameDifficulty.NORMAL:

                D_moveSpeed = 6f;
                U_moveSpeed = 4f;
                break;

            case GameDifficulty.HARD:


                D_moveSpeed = 8f;
                U_moveSpeed = 6f;
                break;

            default:

                break;
        }

    }

    private void StartUpLevel_onStartUpLevel1()
    {
        moveSpeed = U_moveSpeed;
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

    #region // funzioni non implementate nel gioco finale
    //funzione non implementata
    private void EndLevel_onEndLevel()
    {

        //  StartCoroutine(DisableControlsAndMoveUp());
    }

    private IEnumerator DisableControlsAndMoveUp()
    {

        spriteRenderer.sprite = spriteUp;
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        controlsEnabled = false;
        yield return new WaitForSeconds(.5f);
        moveDirection = Vector2.up;


    }
    #endregion 
}