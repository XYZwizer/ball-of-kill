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
    Vector3 MousePos;
    Vector2 SumNormal;
    public Rigidbody2D body;
    public float moveSpeed;
    public float JumpSpeed;
    public float MaxSpeed;
    public float StickForce;
    Collider2D PlayerCollider;

    bool dead = false;

    static Vector2 NoWall = new Vector2(0, 0);
    static Vector2 Gravity = new Vector2(0, -100.0f);

    void move() {
        if (dead) { return; };

        ContactPoint2D[] points = new ContactPoint2D[4];
        body.GetContacts(points);
        SumNormal = points[0].normal + points[1].normal + points[2].normal + points[3].normal;

        if (Input.GetButtonDown("Jump")) {
            body.AddForce(SumNormal * JumpSpeed);
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            inputvec.x = Input.GetAxis("Horizontal");
            inputvec.y = SumNormal.x != 0 ? Input.GetAxis("Vertical") : 0;
            body.AddForce((inputvec * moveSpeed) * Time.deltaTime);

        }

        if (SumNormal == NoWall) {
            body.AddForce(Gravity * Time.deltaTime);
        } else {
            body.AddForce(-SumNormal * StickForce * Time.deltaTime);
        }
    }
    void Start() {
        PlayerCollider = gameObject.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        move();
        if (Input.GetButtonDown("Dash")) {
            Debug.Log("DASH");
            MousePos = Input.mousePosition;
            Debug.DrawRay(MousePos, MousePos+ new Vector3(1,1,0), UnityEngine.Color.black, 1f);
        }
        body.velocity = Vector2.ClampMagnitude(body.velocity, MaxSpeed);
    }
    public void Die() {
        Debug.Log("the pain was unbearable");
        dead = true;
    }
}
