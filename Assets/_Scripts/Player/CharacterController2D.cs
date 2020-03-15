using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PHYSICS CONTROLLER FOR ENTITIES (CLAMPS VELOCITY, IS PHYSICS CAPABLE)
public class CharacterController2D : MonoBehaviour
{
    #region Properties
    public Vector2 velocity
    {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }
    #endregion

    public Rigidbody2D rb;
    public float speed = 1f;
    public CharacterController2D(Rigidbody2D r, float s)
    {
        rb = r;
        speed = s;
    }

    public void move(Vector2 v, float cap)
    {
        rb.AddForce(v);
        //Clamp speed
        velocity = new Vector2(Mathf.Clamp(velocity.x, -cap, cap), velocity.y);
        
    }
}
