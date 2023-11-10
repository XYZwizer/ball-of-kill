using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3[] waypoints;
    int wayindex = 0;
    int direction = 1;
    public float walkSpeed = 0.001f;
    float walkTime = 0.0f;

    void Start() {
        //StartPos = transform.position;
        //waypoints.
    }

    // Update is called once per frame
    void Update() {
        walkTime += walkSpeed * Time.deltaTime;
        
        transform.position = Vector3.Lerp(waypoints[wayindex], waypoints[wayindex+ direction], walkTime);
        if (walkTime > 1.0f) {
            Debug.Log(wayindex.ToString() + "direction:" + direction.ToString());
            wayindex += direction;
            if (wayindex == waypoints.Length-1 || wayindex == 0) {
                direction = -direction;
                //wayindex += direction*2;
            }
            
            walkTime = 0.0f;
            Debug.Log(wayindex.ToString() + "direction:" + direction.ToString());
        }

    }
}
