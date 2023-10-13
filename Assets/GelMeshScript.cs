using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using UnityEngine;

public class GelMeshScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PointPrefab;
    Vector3[] Vertices = new Vector3[4];
    Vector2[] UVs;
    Mesh mesh;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        for (var i = 0; i < 10; i++)
        {
            Instantiate(PointPrefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < Points.Length; i++) {
        //    Vertices[i] = Points[i].transform.localPosition;
        //}
        //mesh.vertices = Vertices;
    }
}
