using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject boidPrefab;
    public int numBoids = 20;
    public float spawnRadius = 5f;
    public GameObject[] allBoids;

    [Header("Flock Settings")]
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float neighborDistance = 3f;
    public float rotationSpeed = 4f;

    void Start()
    {
        allBoids = new GameObject[numBoids];
        for (int i = 0; i < numBoids; i++)
        {
            Vector3 pos = this.transform.position + Random.insideUnitSphere * spawnRadius;
            allBoids[i] = Instantiate(boidPrefab, pos, Quaternion.identity);
            allBoids[i].GetComponent<Boid>().manager = this;
        }
    }
}
