using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 0.000001f;

    void Start() {
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update() {
    }
}
