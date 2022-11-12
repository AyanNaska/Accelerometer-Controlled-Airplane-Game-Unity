using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class flight_controll : MonoBehaviour
{

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 100.0f;

    private Rigidbody _rigidBody;
    private int rollf;
    private int pitchf;

    public string receivedstring;

    private int horz;
    private int vert;

    private float values;
    private float values2;

    SerialPort serial = new SerialPort("COM3", 9600);
    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!serial.IsOpen)
            serial.Open();
        receivedstring = serial.ReadLine();
        string[] datas = receivedstring.Split(',');
        values = float.Parse(datas[0]);
        values2 = float.Parse(datas[1]);
      /*  if (values < 90 && values > 10)
        {
            horz = 1;
        }
        else if (values < 10 && values > -10)
        {
            horz = 0;
        }
        else if (values < -10 && values > -90)
        {
            horz = -1;
        }
        if (values2 < 90 && values2 > 10)
        {
            vert = 1;
        }
        else if (values2 < 10 && values2 > -10)
        {
            vert = 0;
        }
        else if (values2 < -10 && values2 > -90)
        {
            vert = -1;
        }
        Debug.Log(vert);
      */
    }

    void FixedUpdate()
    {
        UpdateFunction();
    }

    void UpdateFunction()
    {

        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        roll = (values/100) * (Time.fixedDeltaTime * RotationSpeed);
        pitch = (values2/100) * (Time.fixedDeltaTime * RotationSpeed);
        yaw = roll;
        AddRot.eulerAngles = new Vector3(-pitch, -yaw, roll);
        _rigidBody.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward*100;
        AddPos = _rigidBody.rotation * AddPos;
        _rigidBody.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);
    }
}
