﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGen : MonoBehaviour {
    public float scale = 1f;
    public float speed = 10f;
    public float noiseStrength = 1f;
    public float noiseWalk = 1f;
    public Mesh mesh;

    private Vector3[] baseHeight;

    void Update ()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
        {
            baseHeight = mesh.vertices;
        }

        Vector3[] vertices = new Vector3[baseHeight.Length];

        for (int i=0;i<vertices.Length;i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)    ) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
