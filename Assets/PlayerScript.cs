using Microsoft.Cci;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    Vector2 inputvec;
    bool inAir = false;
    public Rigidbody2D body;
    public float moveSpeed;
    public float JumpSpeed;
    public float MaxSpeed;
    Collider2D PlayerCollider;
    Collider2D currentCollider = null;

    void getInput() {
        inputvec.x = Input.GetAxis("Horizontal");
        inputvec.y = Input.GetAxis("Vertical");

    }
    void move() {
        if (Input.GetButtonDown("Jump"))
        {
            ContactPoint2D[] points = new ContactPoint2D[4];
            Debug.Log(body.GetContacts(points));
            Debug.Log(points);
            foreach (ContactPoint2D point in points) {
                body.AddForce((point.normal * JumpSpeed) * Time.deltaTime);
                Debug.Log(point.normal);
            }
        }
        if (Input.GetButton("Horizontal"))
        {
            //body.MovePosition(new Vector2(transform.position.x, transform.position.y) + (inputvec * moveSpeed) * Time.deltaTime);
            body.AddForce((inputvec * moveSpeed) * Time.deltaTime);
        };
    }
    void Start()
    {
        PlayerCollider = gameObject.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
        //currentCollider = collision.collider; //raplce with all contacts from riged body info
        //ColliderDistance2D collDis = currentCollider.Distance(PlayerCollider);
        //Debug.DrawRay(collDis.pointA, collDis.normal, Color.black, 1f);
        
        // body.drag = 2;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //inAir = true;
        //currentCollider = null;
        //body.drag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        move();
        body.velocity = Vector2.ClampMagnitude(body.velocity, MaxSpeed);
    }
}
