using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    public GameObject cubeGameObject;
    private int GridSizeX = 10;
    private int GridSizeZ = 10;
    private float gridOffset = 1f;
    private int noiseHeight = 3;
    void Start()
    {
        for (int x = 0; x < GridSizeX; x++)
        {
            for (int z = 0; z < GridSizeZ; z++)
            {
                Vector3 pos = new Vector3(x * gridOffset, PerlinNoiseGeneration(x,z,8f), z * gridOffset);
                GameObject cube = Instantiate(cubeGameObject, pos, Quaternion.identity) as GameObject;
                cube.transform.SetParent(this.transform);
            }
        }
    }
    private float PerlinNoiseGeneration(int x, int z, float scale)
    {
        float xNoise = (x + this.transform.position.x) / scale;
        float zNoise = (z + this.transform.position.z) / scale;

        return Mathf.PerlinNoise(xNoise, zNoise);
    }
    
}
