using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class flightcontroll : MonoBehaviour
{
    public float FlySpeed =5;
    public float YawAmount = 120;

    private float Yaw;
    private float Takeoff;

    private int horz;
    private int vert;
    public string receivedstring;

    SerialPort serial = new SerialPort("COM3", 9600);


    void Update()
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;
        
        if (!serial.IsOpen)
            serial.Open();
        receivedstring = serial.ReadLine();
        string[] datas = receivedstring.Split(',');
        int values = int.Parse(datas[0]);
        int values2 = int.Parse(datas[1]);

        //inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0,30,Mathf.Abs(horizontalInput))* -Mathf.Sign(horizontalInput);

        //apply rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch+Vector3.forward*roll);


        if (values < 90 && values > 20)
        {
            horz = 1;
        }
        else if (values < 20 && values > -20)
        {
            horz = 0;
        }
        else if (values < -20 && values > -90)
        {
            horz = -1;
        }
        if (values2 < 90 && values2 > 20)
        {
            vert = 1;
        }
        else if (values2 <20 && values2 > -20)
        {
            vert = 0;
        }
        else if (values2 < -20 && values2 > -90)
        {
            vert = -1;
        }

    }

}
