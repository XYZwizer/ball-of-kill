using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class camScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CamTarget;
    //public Bounds bounds = new Bounds(new Vector3(2,2,2),new Vector3(2,2,100));
    public Vector3 tolances = new Vector3(10.5f, 10.5f, 0);
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0,0,0);
        //Vector3 desired_position = CamTarget.position + new Vector3(0, 1, -5);

        Vector3 PosOut = CamTarget.position + tolances;
        Vector3 NegOut = CamTarget.position - tolances;

        Vector3 dif = CamTarget.position - transform.position;


        if (transform.position.y > PosOut.y) { move.y =  3.5f* dif.y; }
        else if (transform.position.y < NegOut.y) { move.y = 2.0f * dif.y; };

        if (transform.position.x > PosOut.x) { move.x = 2.0f * dif.x; }
        else if (transform.position.x < NegOut.x) { move.x = 2.0f * dif.x; };

        transform.position = transform.position + (move*Time.deltaTime);
    }
}
