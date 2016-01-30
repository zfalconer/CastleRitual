/*
 *purpose: This is the ai code for the twin 
 */

using UnityEngine;
using System.Collections;

public class TwinAI : MonoBehaviour 
{
	//all of the points of interest on the map
	private GameObject[] points;
	private WeightedMap map;

	private GameObject target;
	private Vector3 homePosition;

	private bool isReturn = false;
	// Use this for initialization
	void Start () 
	{
		//finds the tags of all the items
		points = GameObject.FindGameObjectsWithTag ("Item");
		map = new WeightedMap (points);
		homePosition = this.transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		//if there is no target get one 
		if (!isReturn && target == null)
			target = map.PopHeighestWeight ();
		else if (!isReturn)
		{
			//find the item
			this.GetComponent <NavMeshAgent> ().destination = target.transform.position;

			//if we are near the item get it
			if (Vector3.Distance (this.transform.position, target.transform.position) < 3)
			{
				DestroyObject (target.transform.root.gameObject);
			}
		}

		//if is return is active go to the summonigng well
		if (isReturn) 
		{
			this.GetComponent <NavMeshAgent> ().destination = homePosition;
			if (Vector3.Distance (this.transform.position, homePosition) < 3)
				isReturn = false;
		}

		//sets the rule for when the ai should return back to its summoning well
		if (this.GetComponent <Stats> ().mana < (this.GetComponent <Stats> ().maxMana / 2))
			isReturn = true;
		else
			isReturn = false;
	}
}
