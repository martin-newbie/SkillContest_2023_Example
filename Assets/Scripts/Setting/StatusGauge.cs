using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class StatusGauge : MonoBehaviour
{
    public float height = 1;
    [SerializeField]float changeSpeed;

    Mesh mesh;
    Vector3[] vertices;
    MeshFilter filter;

    [SerializeField, Range(0, 1)] float a, b, c, d, e;

    private void Start()
    {
        mesh = new Mesh();
        vertices = new Vector3[6];

        filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;
    }

    private void Update()
    {
        SetMeshVertices();
    }

    void SetMeshVertices()
    {
        if (filter == null) filter = GetComponent<MeshFilter>();

        vertices[0] = new Vector3(0, 0);
        vertices[1] = Vector3.Lerp(vertices[1], new Vector3(0, height) * a, Time.deltaTime * changeSpeed);
        vertices[2] = Vector3.Lerp(vertices[2], new Vector3(height * Mathf.Cos((90 - 72) * Mathf.Deg2Rad), height * Mathf.Sin((90 - 72) * Mathf.Deg2Rad)) * b, Time.deltaTime * changeSpeed);
        vertices[3] = Vector3.Lerp(vertices[3], new Vector3(height * Mathf.Cos((90 - 72 * 2) * Mathf.Deg2Rad), height * Mathf.Sin((90 - 72 * 2) * Mathf.Deg2Rad)) * c, Time.deltaTime * changeSpeed);
        vertices[4] = Vector3.Lerp(vertices[4], new Vector3(height * Mathf.Cos((90 + 72 * 2) * Mathf.Deg2Rad), height * Mathf.Sin((90 + 72 * 2) * Mathf.Deg2Rad)) * d, Time.deltaTime * changeSpeed);
        vertices[5] = Vector3.Lerp(vertices[5], new Vector3(height * Mathf.Cos((90 + 72) * Mathf.Deg2Rad), height * Mathf.Sin((90 + 72) * Mathf.Deg2Rad)) * e, Time.deltaTime * changeSpeed);

        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5, 0, 5, 1};
    }

    public void SetGaugeValue(float _a, float _b, float _c, float _d, float _e)
    {
        a = _a;
        b = _b;
        c = _c;
        d = _d;
        e = _e;
    }
}
