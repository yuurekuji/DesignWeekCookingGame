using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WokMovement : MonoBehaviour
{

    private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;

    public float speed;

    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            //accel = j.GetAccel();

            orientation = j.GetVector();

            Vector3 moveFront = new Vector3(0, 0, gyro.y / speed);
            Vector3 moveRot = new Vector3(gyro.y / speed, 0, 0);

            Quaternion deltaRotation = Quaternion.Euler(-moveRot * Time.fixedDeltaTime * 70);

            rb.MovePosition(rb.position + moveFront * Time.fixedDeltaTime * 4f);
            rb.MoveRotation(rb.rotation * deltaRotation);
            
        }


    }
}
