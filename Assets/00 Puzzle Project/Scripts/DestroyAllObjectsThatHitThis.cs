using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class DestroyAllObjectsThatHitThis : MonoBehaviour 
{

	public Text missedDrops;

	public AudioSource missSound;

	private int MissedDrops;

	public Flowchart flowchart;

	void OnTriggerEnter2D(Collider2D collisionObject) 
	{
		// remove the falling object from gameplay
		Destroy(collisionObject.gameObject);

		// this plays the sound file
		missSound.Play ();

		// add a number to the Drops integer (number)
		MissedDrops = MissedDrops + 1;

		//Sends the value of integer MissedDrops into the Fungus integer MissedScore
		flowchart.SetIntegerVariable ("MissedScore", MissedDrops);
		
	}

}
