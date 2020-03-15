using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player defining class, contains player traits, inherits Entity
public class Player : MonoBehaviour
{
    
    public float speed = 1f;
    public float jumpForce = 1f;
    public float maxSpeed = 10f;
    //sets force multiplier applied on wall jump SHOULD BE POSITIVE
    public Vector2 wallJumpForce = new Vector2(1, 0.5f);

    private LayerMask mask;
    private bool face;
    protected Rigidbody2D rb;
    protected CharacterController2D controller;

    #region Properties
        public BoxCollider2D groundBox;
        public bool isGrounded
        {
            get
            {
                //if (Physics2D.BoxCast(transform.position, new Vector2(spr.rect.width - .5f ,1), 0, Vector2.down, spr.rect.height / 2, mask) && velocity.y == 0)
                if (groundBox.IsTouchingLayers(mask))
                    return true;
                else
                    return false;
            }
        }

        public bool facingRight
    {
        get { return face; }
        set
        {
            face = value;
            Vector3 theScale = transform.localScale;
            theScale.x = face ? 1 : -1;
            transform.localScale = theScale;
        }
    }

        //Checks if player is next to wall and running against wall.
        //Returns 1 if clinging to right, -1 if left, 0 if not at all
        public BoxCollider2D wallBox;
        public int wallCling
        {
            get
            {
                if (wallBox.IsTouchingLayers(mask) && Input.GetAxisRaw("Horizontal") > 0.75f)
                {
                    return -1;
                }
                else if (wallBox.IsTouchingLayers(mask) && Input.GetAxisRaw("Horizontal") < -0.75f)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    #endregion


    #region Initialization
        private void Start()
        {
            controller = GetComponent<CharacterController2D>();
            rb = GetComponent<Rigidbody2D>();
            mask = LayerMask.GetMask("Ground");
        }
    #endregion
}
