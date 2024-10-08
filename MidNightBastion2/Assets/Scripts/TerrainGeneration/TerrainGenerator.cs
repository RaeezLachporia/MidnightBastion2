using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
public class TerrainGenerator : MonoBehaviour
{

    public int depth = 20;
    public int width = 300;
    public int height = 300;
    public float scale = 20f;
    public float offSetX = 100f;
    public float offSetY = 100f;
    private void Start()
    {
        offSetX = Random.Range(0f, 9999f);
        offSetY = Random.Range(0f, 9999f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        GetComponent<NavMeshSurface>().BuildNavMesh();

       
    }
    
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float [,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float Xcordinate = (float)x / width * scale + offSetX;
        float Ycordinate = (float)y / height *scale + offSetY;

        return Mathf.PerlinNoise(Xcordinate, Ycordinate);
    }
}
