using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public FlockManager manager;
    private float speed;
    private Vector3 direction;

    void Start()
    {
        speed = Random.Range(manager.minSpeed, manager.maxSpeed);
        direction = Random.insideUnitSphere;
        direction.z = 0;
    }

    void Update()
    {
        if (manager != null)
        {
            ApplyFlockingRules();
        }

        transform.Translate(direction * speed * Time.deltaTime);

        Vector3 targetDirection = direction.normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, targetDirection), manager.rotationSpeed * Time.deltaTime);
    }

    void ApplyFlockingRules()
    {
        Vector3 cohesionVector = Vector3.zero;
        Vector3 separationVector = Vector3.zero;
        Vector3 alignmentVector = direction;
        int groupSize = 0;

        foreach (GameObject boid in manager.allBoids)
        {
            if (boid != this.gameObject)
            {
                float distance = Vector3.Distance(boid.transform.position, this.transform.position);
                if (distance <= manager.neighborDistance)
                {
                    cohesionVector += boid.transform.position;
                    groupSize++;

                    if (distance < 1f) // Too close, separate
                    {
                        separationVector = separationVector + (this.transform.position - boid.transform.position);
                    }

                    alignmentVector += boid.GetComponent<Boid>().direction;
                }
            }
        }

        if (groupSize > 0)
        {
            cohesionVector = (cohesionVector / groupSize - transform.position).normalized;
            alignmentVector = (alignmentVector / groupSize).normalized;

            direction = (cohesionVector + separationVector + alignmentVector).normalized;
        }
    }
}
