using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Rotator : MonoBehaviour 
{
	public float Movespeed = 25f;
	public float Turnspeed = 0.8f;
	public Rigidbody rb = null;
	private int horz;
	SerialPort serial = new SerialPort("COM3",9600);
    void Update () 
	{

		if (!serial.IsOpen)
						serial.Open (); 

		int values = int.Parse (serial.ReadLine ());
		if(values<341&& values > 0)
        {
			horz = -1;
        }
		else if (values < 682 && values > 342)
		{
			horz = 0;
		}
		else if (values < 1024 && values > 683)
		{
			horz = 1;
		}
		Debug.Log(horz);
		//transform.localEulerAngles = new Vector3(0,rotation,0);

		float vert = Input.GetAxis("Vertical");     // wasd, arrows, left-analog gamepad
													//float horz = Input.GetAxis("Horizontal");   // -1..0..1

		rb.AddRelativeForce(Vector3.back * vert * Movespeed, ForceMode.Acceleration);
		rb.AddRelativeTorque(Vector3.up * horz * Turnspeed, ForceMode.VelocityChange);
	}

}
