using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    Transform arm;
    public GameObject intended_target;
    Transform intended_target_Transform;
    Transform current_target;
    public UnityEngine.Object bullet_type;

    Bounds Selfbounds;
    Bounds Tragetbounds;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        intended_target_Transform = intended_target.transform;
        arm = this.transform.GetChild(1).transform;
        Debug.Log(arm);

        Selfbounds = gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds;
        Tragetbounds = intended_target.GetComponent<Renderer>().bounds;
    }

    public void Die() {
        gameObject.GetComponent<WalkScript>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
        if (current_target != null) {
            var direction = (arm.position - current_target.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            arm.rotation =  Quaternion.RotateTowards(arm.rotation, targetRotation, 50f * Time.deltaTime);
            if (arm.rotation == targetRotation) {
                //fire
                current_target = null;
                hit = Physics2D.Raycast(arm.position, -direction);
                if (hit) {
                    
                    UnityEngine.Object Bullet = Instantiate(bullet_type);
                    Transform BulletTransform = Bullet.GameObject().transform;

                    BulletTransform.position = hit.point;
                    BulletTransform.rotation = targetRotation;
                    BulletTransform.localScale = new Vector3(1,1 , Vector3.Distance(hit.point, arm.position));

                    if (hit.transform == intended_target_Transform) {
                        intended_target.GetComponent<PlayerScript>().Die();
                    }
                };
                
            }
        } else {

            var direction_of_potential_target = (this.transform.position - intended_target_Transform.position).normalized;
            //var Rotation = Quaternion.LookRotation(direction_of_potential_target);
            hit = Physics2D.Raycast(arm.position, -direction_of_potential_target);
            if (hit.transform == intended_target_Transform) {
                current_target = intended_target_Transform;
            }
        }


        if (Selfbounds.Intersects(Tragetbounds) && intended_target.GetComponent<PlayerScript>().isDashing) {
            Die();
        }
    }
    //private void OnCollisionEnter(Collision collision) {
    //    PlayerScript PlayerS = collision.gameObject.GetComponent<PlayerScript>();
    //
    //    if (PlayerS != null) {
    //        if (PlayerS.isDashing) {
    //            Die();
    //        }
    //    }
    //}
}
