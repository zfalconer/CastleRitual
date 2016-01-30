using UnityEngine;
using System.Collections;

public class TwinAI : MonoBehaviour 
{
	//all possible mana orb points
	private GameObject[] points;
	private WeightedMap map;

	private GameObject target;
	private GameObject manaOrb;
	private Vector3 homePosition;

	private bool isReturn = false;
	// Use this for initialization
	void Start () 
	{
		//finds the tags of all of the orbs
		points = GameObject.FindGameObjectsWithTag ("Orb");
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
			//find the mana orb
			this.GetComponent <NavMeshAgent> ().destination = target.transform.position;

			//if we are near the mana orb then we get it
			if (Vector3.Distance (this.transform.position, target.transform.position) < 3)
			{
				manaOrb = target;
				target = null;
				isReturn = true;
			}
		}

		if (isReturn) 
		{
			this.GetComponent <NavMeshAgent> ().destination = homePosition;
			if (Vector3.Distance (this.transform.position, homePosition) < 3)
				isReturn = false;
		}
	}
}
