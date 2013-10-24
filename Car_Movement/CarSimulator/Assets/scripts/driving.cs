using UnityEngine;
using System.Collections;

public class driving : MonoBehaviour 
{
	public float drivingSpeed;
	public float turningSpeed = 30;
	public bool onIce = false;
	float iceSpeedModifier;
	public float randomizeTurn = 0;
	

	// Use this for initialization
	void Start () 
	{
		iceSpeedModifier = 0;
	}
	
	
	IEnumerator slowDownTurnRand()
	{
		while (onIce == true) 
		{
			yield return new WaitForSeconds(.5f);
			if(Random.value < 0.5f)
			{
    			randomizeTurn = 20;
			}
			else
			{
    			randomizeTurn = -20;
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () 
	{	
		//StartCoroutine("slowDownTurnRand");
		
		if (randomizeTurn != 0 && onIce == false) 
		{
			randomizeTurn = 0;
		}
		
		//speed modifier while on ice
		if (drivingSpeed < 25) 
		{
			drivingSpeed += iceSpeedModifier;
		}
		
		//move forward
		if (Input.GetKey("mouse 0")) 
		{
			rigidbody.AddForce(transform.forward * drivingSpeed, ForceMode.Acceleration);
		}
		
		//always have acceleration while on ice
		if (onIce == true) 
		{
			rigidbody.AddForce(transform.forward * drivingSpeed, ForceMode.Acceleration);
		}
		
		//acceleration drag
		if (Input.GetKey("mouse 0") && onIce == false) 
		{
			rigidbody.drag = 4;
		}
		
		//turning
		float turn = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, turn + randomizeTurn, 0);
		
		
		//neutral
		if (Input.GetKeyUp("mouse 0") && onIce == false)
		{
			rigidbody.drag = 1;
		}
		
		//braking
		if (Input.GetKeyDown("mouse 1") && onIce == false) 
		{
			rigidbody.drag = 4.5f;
		}
	}
	
	
	void OnTriggerEnter()
	{	
		//make sure the update if staments know not to fire off while the car is on ice
		onIce = true;
		
		StartCoroutine(slowDownTurnRand());
		
		//value of speed increase per frame while on ice
		iceSpeedModifier = 0.4f;
		
		turningSpeed = 60;
		
		rigidbody.drag = 4;
	}
	
	void OnTriggerExit()
	{
		onIce = false;
		randomizeTurn = 0;
		iceSpeedModifier = 0;
		turningSpeed = 30;
		drivingSpeed = 30;
	}
}
