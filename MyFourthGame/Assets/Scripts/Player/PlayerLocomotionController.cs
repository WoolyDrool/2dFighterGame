using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLocomotionController : MonoBehaviour
{
    [Header("Main Movement")]
    public float movementSpeed = 10;
    public float jumpPower = 10;
    public bool isGrounded = true;
    public bool isJumping = false;
    public bool isMoving = false;
    public Rigidbody2D rb2d;
    public GameObject groundCheckOBJ;
    public bool playerCanMove = true;
    CharacterSheet cs;
    public int jumpCost = 10; 

    [Header("Animation")]
    public LayerMask groundLayers;
    public Animator charAnimator;
    public GameObject CharacterRig;


    private void Awake()
    {
        //movementSpeed = CharacterSheet.cs.movementSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        cs = this.GetComponent<CharacterSheet>();
        //movementSpeed = csInstance.movementSpeed;
        //Mathf.Round(movementSpeed);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 1.9f;
        charAnimator = GetComponentInChildren<Animator>();
        CharacterRig = GameObject.FindWithTag("PlayerRig");
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement


        if (playerCanMove)
        {
            //Face Rig Right
            //CharacterRig.transform.localScale = new Vector3(-1,1,1);

            //MAIN MOVEMENT
            float inputX = Input.GetAxisRaw("Horizontal") * movementSpeed;
            transform.Translate(new Vector2(inputX * Time.deltaTime, 0));

            if (inputX != 0)
            {
                isMoving = true;
            } else
            {
                isMoving = false;
            }

            //Animate the character
            if (inputX > 0 || inputX < 0)
            {
                charAnimator.SetBool("running", true);
            }
            else
            {
                charAnimator.SetBool("running", false);
            }


            //FLIP CHARACTER RIGHT
            if (inputX > 0)
            {
                CharacterRig.transform.localScale = new Vector3(-1, 1, 1);
            }

            if (inputX < 0)
            {
                CharacterRig.transform.localScale = new Vector3(1, 1, 1);
            }



            //Jumping
            if (Input.GetButtonDown("Jump") && isGrounded == true && cs.stamina >= jumpCost)
            {
                rb2d.velocity = new Vector2(0, jumpPower);
                isGrounded = false;
                charAnimator.SetBool("jumping", true);
                cs.UseStamina(jumpCost);
            }

            if (isGrounded)
            {
                charAnimator.SetBool("jumping", false);
                isJumping = false;
            }
            else
            {
                charAnimator.SetBool("jumping", true);
                isJumping = true;
            }

            isGrounded = Physics2D.OverlapArea(new Vector2(groundCheckOBJ.transform.position.x, 0), new Vector2(0, groundCheckOBJ.transform.position.y), groundLayers);
            #endregion

        }

    }

    public void Recalc()
    {
    }
}
}