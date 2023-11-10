using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CamTarget;
    public Bounds bounds = new Bounds(new Vector3(2,2,2),new Vector3(2,2,100));
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<Camera>().orthographicSize;
        //Debug.Log(((this.transform.position + bounds.center) - CamTarget.position) * -Time.deltaTime);
        //transform.position += ((this.transform.position+bounds.center)- CamTarget.position)* -Time.deltaTime;
        Vector3 Outer = transform.position + bounds.size;
        Vector3 move = new Vector3(0, 0, 0);
        if (CamTarget.position.y > Outer.y) {move.y = 10;} 
        else if (CamTarget.position.y < -Outer.y) {move.y = -10;}
        if (CamTarget.position.x > Outer.x) {move.x = 10;}
        else if (CamTarget.position.x < -Outer.x) { move.x = -10; }
        transform.position += move*Time.deltaTime;
    }
}
