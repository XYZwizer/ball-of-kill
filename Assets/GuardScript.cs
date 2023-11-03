using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    Transform arm;
    public GameObject looking_for_target;
    Transform target;
    public UnityEngine.Object bullet_type;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        arm = this.transform.GetChild(1).transform;
        Debug.Log(arm);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target != null) {
            var direction = (arm.position - target.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            arm.rotation =  Quaternion.RotateTowards(arm.rotation, targetRotation, 50f * Time.deltaTime);
            if (arm.rotation == targetRotation) {
                //fire
                target = null;
                hit = Physics2D.Raycast(arm.position, -direction);
                if (hit) {
                    
                    UnityEngine.Object Bullet = Instantiate(bullet_type);
                    Transform BulletTransform = Bullet.GameObject().transform;
                    BulletTransform.position = hit.point;
                    BulletTransform.rotation = Quaternion.Euler(arm.rotation.eulerAngles.x, 0, );
                    //BulletTransform.rotation = targetRotation;
                };
                
            }
        } else {
            target = looking_for_target.transform;
        }
    }
}
