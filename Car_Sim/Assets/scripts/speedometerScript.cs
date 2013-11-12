using UnityEngine;
using System.Collections;

public class speedometerScript : MonoBehaviour 
{
	
	int mph;
	
	Camera playerCamera;
	
	//GameObject speedometer;
	
	public GUIText speedometerDisplay;
	
	
	// Use this for initialization
	void Start () 
	{
		
		playerCamera = Camera.main;
		
		//GameObject.Find ("Gtext");
		
		//speedometerDisplay = speedometer.GetComponent<GUIText>();
	
		StartCoroutine("MPHdisplay");
		
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
		//StartCoroutine("MPHdisplay");
		//mph = (int)playerCamera.velocity.magnitude *2;
		//speedometerDisplay.text = mph + " MPH";
	}
	
	
	IEnumerator MPHdisplay()
	{
		mph = (int)playerCamera.velocity.magnitude * 2;
		speedometerDisplay.text = mph + " MPH";
		yield return new WaitForSeconds(.5f);
		StartCoroutine("MPHdisplay");
	}
}
