/*
 *Purpose: This allows ai for enemies to find player 
 */

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{

	public float speed;

	private GameObject target;

	//this is used to check and see if there is a clear path
	private bool clearPath = true;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		if (clearPath) 
		{
			if (target)
				MoveTo (target.transform);
		} else 
		{
			MoveTo (FindClosestDoor());
			if (Vector3.Distance(FindClosestDoor().position, this.transform.position) < 3)
				clearPath = true;
		}

		Debug.Log (clearPath);
	}

	//this detects things in its line of site
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Wall") 
		{
			clearPath = false;
		}
	}

	private Transform FindClosestDoor ()
	{
		GameObject[] doorList = GameObject.FindGameObjectsWithTag ("Door");
		//initalizing values
		float maxDist = Vector3.Distance (doorList[0].transform.position, this.transform.position);
		Transform door = doorList[0].transform;

		for (int i = 1; i < doorList.Length; i++)
		{
			if (Vector3.Distance (doorList [i].transform.position, this.transform.position) < maxDist) 
			{
				maxDist = Vector3.Distance (doorList [i].transform.position, this.transform.position);
				door = doorList [i].transform;
			}
		}

		return door;
	}

	//moves the character to the object
	private void MoveTo(Transform transform)
	{
		this.transform.LookAt (transform);

		this.transform.Translate (0f, 0f, speed);
	}

	private void Attack ()
	{

	}
}
