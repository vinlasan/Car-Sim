using UnityEngine;
using System.Collections;

public class driving : MonoBehaviour 
{
	float drivingSpeed = 35;
	float turningSpeed = 40;
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
			yield return new WaitForSeconds(.1f);
			if(Random.value < 0.5f)//random.value returns a random between 0 and 1. All this does is jump between the two values.
			{
    			randomizeTurn = 1;
			}
			else
			{
    			randomizeTurn = -1;
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () 
	{	
		if (randomizeTurn != 0 && onIce == false)
		{
			randomizeTurn = 0;
		}
		
		drivingSpeed += iceSpeedModifier;
		
		//move forward
		if (Input.GetKey("mouse 1")) 
		{
			rigidbody.AddForce(transform.forward * drivingSpeed, ForceMode.Acceleration);
		}
		
		//always have acceleration while on ice
		if (onIce == true) 
		{
			rigidbody.AddForce(transform.forward * drivingSpeed, ForceMode.Acceleration);
		}
		
		//acceleration drag
		if (Input.GetKey("mouse 1") && onIce == false) 
		{
			rigidbody.drag = 4;
		}
		
		
		
		if (rigidbody.velocity.magnitude > 8) 
		{
			float turn = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;//turning speed at 40
			transform.Rotate(0, turn + randomizeTurn, 0);
			//print ("magnitude over 8");
		}
		
		if (rigidbody.velocity.magnitude > 5 && rigidbody.velocity.magnitude <= 7) 
		{
			float turn = Input.GetAxis("Horizontal") * (turningSpeed - 5) * Time.deltaTime;//turning speed at 35
			transform.Rotate(0, turn + randomizeTurn, 0);
			//print ("magnitude between 5 and 7");
		}
		
		if (rigidbody.velocity.magnitude > 3 && rigidbody.velocity.magnitude <= 5) 
		{
			float turn = Input.GetAxis("Horizontal") * (turningSpeed - 15) * Time.deltaTime;//turning speed at 25
			transform.Rotate(0, turn + randomizeTurn, 0);
			//print ("magnitude between 10 and 15");
		}
		
		if (rigidbody.velocity.magnitude <= 3 && rigidbody.velocity.magnitude > 1) 
		{
			float turn = Input.GetAxis("Horizontal") * (turningSpeed - 25) * Time.deltaTime;//turning speed at 15
			transform.Rotate(0, turn + randomizeTurn, 0);
			//print ("magnitude between 1 and 3");
		}
	
		if (rigidbody.velocity.magnitude < 1) 
		{
			float turn = Input.GetAxis("Horizontal") * (turningSpeed - 40) * Time.deltaTime;//turning speed at 0
			transform.Rotate(0, turn + randomizeTurn, 0);
			//print ("magnitude under 1");
		}
		
		
		
		//neutral
		if (Input.GetKeyUp("mouse 1") && onIce == false)
		{
			rigidbody.drag = .5f;
		}
		
		//braking
		if (Input.GetKeyDown("mouse 0") && onIce == false) 
		{
			rigidbody.drag = 2.5f;
		}
	}
	
	
	
	void OnTriggerStay(Collider other)
	{	
		//breaking on ice
		if (Input.GetKeyDown("mouse 0") && onIce == true) 
		{
			StartCoroutine(slowDownTurnRand());
		}
	}
	
	
	
	void OnTriggerEnter()
	{
		//make sure the update if staments know not to fire off while the car is on ice
		onIce = true;
			
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
		turningSpeed = 40;
		drivingSpeed = 35;
	}
}
