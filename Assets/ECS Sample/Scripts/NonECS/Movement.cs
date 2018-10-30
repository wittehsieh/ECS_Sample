using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Transform Target;
    public float VelocityAmount;
    public float AcceleratAmount;

    private Vector3 velocity;

    private void Start()
    {
        velocity = transform.position.normalized * VelocityAmount;
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
        velocity = (velocity + AcceleratAmount * Time.deltaTime * (Target.position - transform.position).normalized).normalized * VelocityAmount;
    }
}
