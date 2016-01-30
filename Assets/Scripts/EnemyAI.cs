/*
 *Purpose: This allows ai for enemies to find player 
 */

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	private GameObject target;

	// Use this for initialization
	void Start () 
	{
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
		Debug.Log ("Get Rekt");
	}
		
}
