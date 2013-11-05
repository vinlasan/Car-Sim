using UnityEngine;
using System.Collections;

public class s_Pedal : MonoBehaviour 
{
	
	public GameObject Brake;
	public GameObject Accelerator;
	
	public string keyBrake;
	public string keyAccelerate;
	
	public float brakeNeutral;
	public float brakeForward;
	public float accelerationNetral;
	public float accelerationForward;
	
	//Transform temp;
	//Transform temp2;
	
	
	
	void Start()
	{		
		brakeNeutral = Brake.transform.position.z;
		brakeForward = brakeNeutral + 10;
		
		accelerationNetral = Brake.transform.position.z;
		accelerationForward = brakeNeutral + 10;
	}
	

	void Update () 
	{
		Vector3 temp = Brake.transform.position;
		Vector3 temp2 = Accelerator.transform.position;
		
		if (Input.GetKeyDown(keyBrake)) 
		{
			temp.z = brakeForward;
		}
		else 
		{
			temp.z = brakeNeutral;
		}
		
		if (Input.GetKeyDown(keyAccelerate)) 
		{
			temp2.z = accelerationForward;
		}
		else 
		{
			temp2.z = accelerationNetral;
		}
		
		
		
		/*
		Vector3 RestrictPositions = transform.position; //copy to auxilary variable
		if(RestrictPositions.x >= xAxisMax)
			RestrictPositions.x = xAxisMax;//modify components
		if(RestrictPositions.x <= xAxisMin)
			RestrictPositions.x = xAxisMin;//modify components
		if(RestrictPositions.y >= yAxisMax)
			RestrictPositions.y = yAxisMax;//modify components
		if(RestrictPositions.y <= yAxisMin)
			RestrictPositions.y = yAxisMin;//modify components
		transform.position = RestrictPositions;//save modified value
		*/
		
		
		
		
		/*
		while (Input.GetKeyDown(keyBrake)) 
		{
			if (Brake.transform.position.z < brakeNeutral) 
			{
				MovePedal(Brake, true);//move brake forward
			}
		}
		
		
		if (Input.GetKeyDown(keyBrake) && Brake.transform.position.z < brakeNeutral)//asking if brake is forward
		{	
			MovePedal(Brake, true);//move brake forward
		}
				
		if (Input.GetKeyDown(keyBrake) && Brake.transform.position.z > brakeForward)//asking if brake is back
		{
			MovePedal(Brake, false);//move brake back
		}		
		
		if (Input.GetKeyDown(keyAccelerate) && Accelerator.transform.position.z < accelerationNetral)//asking if accelerator is forward
		{
			MovePedal(Accelerator,true);//move accelerator forward
		}
		
		if (Input.GetKeyDown(keyAccelerate) && Accelerator.transform.position.z > accelerationForward)//asking if accelerator is back
		{
			MovePedal(Accelerator,true);//move accelerator back
		}
		*/
	}
	
	/*
	public static void MovePedal (GameObject pedal, bool keyState) 
	{	
		Transform pedalTransform = pedal.transform;
		
		if (keyState == true) 
		{
			pedalTransform.position.z = pedalTransform.position.z + 10;
		}

		if (keyState == false) 
		{
			pedalTransform.transform.position.z = pedalTransform.transform.position.z - 10;
		}
		
		
		
		
		float MoveSpeed = 5f;
		float Movement = MoveSpeed * Time.deltaTime;
		
		if (keyState == true)
		{
			pedalTransform.Translate(Vector3.forward * Movement);
		}
		
		if (keyState == false)
		{
			pedalTransform.Translate(Vector3.back * Movement);
		}
	}
	*/
	
}
