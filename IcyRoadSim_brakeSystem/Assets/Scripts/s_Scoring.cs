using UnityEngine;
using System.Collections;

public class s_Scoring : MonoBehaviour {
	
	public float ScoreTracker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider c) {
		
		if (gameObject.tag == "ParkedCar") {
			ScoreTracker = ScoreTracker-10f;
		}
		
		if (gameObject.tag == "Lamp") {
			ScoreTracker = ScoreTracker-8f;
		}
		
		if (gameObject.tag == "Building") {
			ScoreTracker = ScoreTracker-12f;
		}
		
		if (gameObject.tag == "Sidewalk") {
			ScoreTracker = ScoreTracker-6f;
		}
	}
}
