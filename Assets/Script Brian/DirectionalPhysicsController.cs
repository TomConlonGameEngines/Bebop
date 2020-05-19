using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPhysicsController : MonoBehaviour
{
    Rigidbody rb;

    public float power = 100;
    public float rotPower = 30;

    Quaternion q = Quaternion.identity;

    public LayerMask lm;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (q * transform.forward) * 5.0f);

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        RaycastHit rch;
        if (Physics.Raycast(transform.position, Vector3.down, out rch, 1000, lm))
        {
            float angle = Vector3.Angle(Vector3.up, rch.normal);
            Vector3 axis = Vector3.Cross(Vector3.up, rch.normal);
            q = Quaternion.AngleAxis(angle, axis);
        }

        force = Input.GetAxis("Vertical") * (q * transform.forward) * power;
        rb.AddForce(force);
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * rotPower);
    }

    public Vector3 force;
}
