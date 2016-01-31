/*
 *purpose: This is the ai code for the twin 
 */

using UnityEngine;
using System.Collections;

public class TwinAI : MonoBehaviour 
{
	//tag that the items to find will have
	public string itemTag;

	//all of the points of interest on the map
	private GameObject[] points;
	private WeightedMap map;

	private GameObject target;
	private Vector3 homePosition;

	private bool isReturn = false;
	// Use this for initialization
	void Awake () 
	{
		//finds the tags of all the items
		Debug.Log (itemTag);
		points = GameObject.FindGameObjectsWithTag (itemTag);
		map = new WeightedMap (points);
		homePosition = this.transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		//if there is no target get one 
		if (!isReturn && target == null) 
		{
			target = map.PopHeighestWeight ();

			if (target == null)
				isReturn = true;
		}
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

		//if we are close to the player then 
		if (Vector3.Distance (this.transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) < 6)
			this.GetComponent <SpellCaster> ().enabled = true;
		else
			this.GetComponent <SpellCaster> ().enabled = false;


	}
}
