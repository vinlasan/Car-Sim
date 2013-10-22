using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour 
{

	GameObject Car;
	float iceSpeedModifier;
	
	// Use this for initialization
	void Start () {
		Car = GameObject.Find("car");
		iceSpeedModifier = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Car.GetComponent<driving>().drivingSpeed += iceSpeedModifier;
	}
	
	void OnTriggerEnter(Collider c)
	{
		print(c.name + "Has entered the trigger");
		
		iceSpeedModifier = 0.5f;
		Car.GetComponent<driving>().turningSpeed = 5f;
		Car.rigidbody.drag = 5;
	}
	
	void OnTriggerExit()
	{
		iceSpeedModifier = 0;
		Car.GetComponent<driving>().turningSpeed = 30;
	}
}
