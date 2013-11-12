using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	public GameObject player;
	public GUIText Score;
	// Use this for initialization
	void Start () {
		Score.fontSize = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c)
	{
		Score.fontSize = 50;
		Score.text = player.GetComponent<driving>().playerScore.ToString();
	}
}
