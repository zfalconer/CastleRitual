/*
 *Purpose: This closes and opens the door when 
 *an object enters the trigger area
 */

using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	public GameObject door;

	private Quaternion rotPos;
	// Use this for initialization
	void Start () 
	{
		rotPos = door.transform.localRotation;
	}

	void OnTriggerEnter (Collider collider)
	{
		Open ();
	}

	void OnTriggerExit (Collider Collider)
	{
		Close ();
	}

	private void Open ()
	{
		door.transform.localRotation = Quaternion.Euler (new Vector3 (door.transform.localRotation.x, 90, door.transform.localRotation.z));
	}

	private void Close ()
	{
		door.transform.localRotation = rotPos;
	}
}
