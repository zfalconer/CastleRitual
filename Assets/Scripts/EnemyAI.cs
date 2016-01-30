/*
 *Purpose: This allows ai for enemies to find player 
 */

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public string targetTag;

	private GameObject target;

	// Use this for initialization
	void Awake () 
	{
		target = GameObject.FindGameObjectWithTag (targetTag);

		//if it can't find the tag then it should just target the player
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		if (target != null) 
		{
			this.GetComponent <NavMeshAgent> ().destination = target.transform.position;

			if (Vector3.Distance (this.transform.position, target.transform.position) < 3)
				Kill ();
		}
	}

	public void Kill ()
	{
		Destroy (target.gameObject);
	}
		
}
