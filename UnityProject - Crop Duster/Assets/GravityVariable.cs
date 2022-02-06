using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityVariable : MonoBehaviour
{
    public float gravity = 9.81f;
    private Rigidbody Object;

    private void Start()
    {
        Object = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        Object.AddForce(Vector3.down * gravity * Object.mass);
    }
}
