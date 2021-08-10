using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Transform endpoint;
    public float Speed { get; private set; } //ENCAPSULATION

    private void Awake()
    {
        Speed = 0.7f;
    }

    private void OnCollisionStay(Collision other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, Speed * Time.deltaTime);
    }

    public void SetConveyorSpeed(float speed)
    {
        Speed = speed;
    }
}
