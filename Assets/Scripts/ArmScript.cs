using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmScript : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(target.x, target.y, 0) - transform.position;

        // Construct a rotation as in the y+ case.
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, offset);

        // Apply a compensating rotation that twists x+ to y+ before the rotation above.
        transform.rotation = rotation * Quaternion.Euler(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime) * moveSpeed;
    }
}
