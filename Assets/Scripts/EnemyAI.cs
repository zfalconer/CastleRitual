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
		cycleMax = 25f;
	}

	// Update is called once per frame
	void Update () 
	{
		//if it can't find the tag then it should just target the player
		if (target == null)
		{
			//if tommy spawns then good will attack player and evil will attack target tag
			if (GameObject.Find ("Timmy(Clone)") != null) 
			{
				if (targetTag == "Good")
					target = GameObject.FindGameObjectWithTag (targetTag);
				else
					target = GameObject.FindGameObjectWithTag ("Player");
			//vice versa for tommy clone
			} else if (GameObject.Find ("Tommy(Clone)") != null)
			{
				if (targetTag == "Good")
					target = GameObject.FindGameObjectWithTag ("Player");
				else
					target = GameObject.FindGameObjectWithTag (targetTag);
			}

			Debug.Log (target.name + "followed by " + this.name);
		}


		//the total cycle of tracking and loitering
		if (cycleTime >= 0 && cycleTime <= cycleMax)
		{
			if (cycleTime <= (cycleMax * .45f)) 
			{
				Debug.Log ("tracking time " + cycleTime);
				this.GetComponent <NavMeshAgent> ().destination = target.transform.position;
			}

			cycleTime += Time.fixedDeltaTime;
		} else
			cycleTime = 0;

		if (Vector3.Distance (this.transform.position, target.transform.position) < 5)
			Kill ();
	}

	public void Kill ()
	{
		Destroy (target.gameObject);
	}
		
}
