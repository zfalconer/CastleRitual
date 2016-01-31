/*
 *Purpose: This allows ai for enemies to find player 
 */

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public string targetTag;
	public float cycleMax;

	private GameObject target;

	private bool isTracking;

	private float cycleTime;

	// Use this for initialization
	void Awake () 
	{
		target = GameObject.FindGameObjectWithTag (targetTag);
	}

	// Update is called once per frame
	void Update () 
	{
		//if it can't find the tag then it should just target the player
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");


		if (cycleTime >= 0 && cycleTime <= cycleMax) 
		{
			if (cycleTime <= (cycleMax * .65f))
				this.GetComponent <NavMeshAgent> ().destination = target.transform.position;
		}

		if (Vector3.Distance (this.transform.position, target.transform.position) < 3)
			Kill ();
	}

	public void Kill ()
	{
		Destroy (target.gameObject);
	}
		
}
