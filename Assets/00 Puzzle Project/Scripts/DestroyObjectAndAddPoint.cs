using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class DestroyObjectAndAddPoint : MonoBehaviour 

{
	public int Caught = 0;

	public AudioSource CatchSound;

	public Text scoreText;

	public Flowchart flowchart;

	// when objects collide
	void OnTriggerEnter2D(Collider2D collisionObject) 
	{

		// remove the object from gameplay
		Destroy(collisionObject.gameObject);

		// this plays the sound file
		CatchSound.Play ();

		// add a point to the player's score
		Caught = Caught + 1;

		//Sends the value of integer Caught into the Fungus integer CatchScore
		flowchart.SetIntegerVariable ("CatchScore", Caught);
	
	}
		
}
