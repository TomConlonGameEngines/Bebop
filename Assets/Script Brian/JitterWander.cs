using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JitterWander : SteeringBehaviour
{
    public float power = 100;

    public Vector3 seekTarget;
    public float distance = 20;
    public float radius = 10;
    public float jitter = 100;

    public Vector3 target;
    public Vector3 worldTarget;

    public void OnDrawGizmos()
    {
        Vector3 localCP = Vector3.forward * distance;
        Vector3 worldCP = transform.TransformPoint(localCP);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(worldCP, radius);

        Vector3 localTarget = (Vector3.forward * distance) + target;
        worldTarget = transform.TransformPoint(localTarget);
        Gizmos.DrawSphere(worldTarget, 0.1f);
        Gizmos.DrawLine(transform.position, worldTarget);

    }


    public override Vector3 Calculate()
    {
        /*
        Vector3 force = Random.insideUnitSphere * power;
        return force;
        */

        /*
        if (Vector3.Distance(transform.position, seekTarget) < 5)
        {
            seekTarget = Random.insideUnitSphere * distance;
            seekTarget = transform.TransformPoint(seekTarget);
        }
        return boid.SeekForce(seekTarget);
        */

        Vector3 disp = jitter * Random.insideUnitSphere * Time.deltaTime;
        target += disp;
        target = Vector3.ClampMagnitude(target, radius);

        Vector3 localTarget = (Vector3.forward * distance) + target;

        worldTarget = transform.TransformPoint(localTarget);

        return worldTarget - transform.position;

    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        seekTarget = Random.insideUnitSphere * distance;
        seekTarget = transform.TransformPoint(seekTarget);
        */

        target = Random.insideUnitSphere * radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
