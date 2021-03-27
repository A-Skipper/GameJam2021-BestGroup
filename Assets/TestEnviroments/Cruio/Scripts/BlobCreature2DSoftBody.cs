using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobCreature2DSoftBody : MonoBehaviour
{


    public Mesh mesh;
    public Vector3[] vertices;
    public int CenterPoint;
    public int VerticiesCount;


    public List<GameObject> points;
    public GameObject ToBeSpawned;

        private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        VerticiesCount = vertices.Length;


        for (int i = 0; i < VerticiesCount; i++)
        {
            GameObject childObject = Instantiate(ToBeSpawned, gameObject.transform.position + vertices[i], Quaternion.identity) as GameObject;
            childObject.transform.parent = gameObject.transform;
            points.Add(childObject);
        }

        for (int j = 0; j < points.Count; j++)
        {
            if (j != CenterPoint)
            {
                if (j == points.Count - 1)
                {
                    points[j].GetComponent<HingeJoint2D>().connectedBody = points[0].GetComponent<Rigidbody2D>();
                }
                else
                {
                    points[j].GetComponent<HingeJoint2D>().connectedBody = points[j + 1].GetComponent<Rigidbody2D>();
                }
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = points[i].transform.localPosition;
        }
        mesh.vertices = vertices;
    }
}
