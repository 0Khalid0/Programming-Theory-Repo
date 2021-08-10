using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationPower;

    private Vector3 rotationDirection;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RandomVector3Generator();

        rb.AddTorque(rotationDirection * rotationPower);
    }

    private void RandomVector3Generator()
    {
        rotationDirection = new Vector3(Random.Range(-60, 60), Random.Range(-60, 60), Random.Range(-60, 60));
    }
}
