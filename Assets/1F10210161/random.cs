using UnityEngine;
using System.Collections;

public class random : MonoBehaviour
{
    public GameObject cube;
    private BoxCollider2D cubeCollider; // 追加

    void Start()
    {
        GenerateCube();
    }

    public void GenerateCube()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(-5.0f, 5.0f);
        cube.tag = "Cube";
        GameObject newCube = Instantiate(cube, new Vector2(x, y), Quaternion.identity);
        cubeCollider = newCube.AddComponent<BoxCollider2D>(); // 追加
    }   
}

