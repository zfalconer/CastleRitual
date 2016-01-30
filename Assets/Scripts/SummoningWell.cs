/*
 *Purpose: This is used to summon the monsters
 *by collecting mana
 */

using UnityEngine;
using System.Collections;

public class SummoningWell : MonoBehaviour 
{

	public enum MonsterType 
	{
		Light, Dark
	}

	public MonsterType type;

	private float mana;
	// Use this for initialization
	void Start () 
	{
		mana = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mana > 100);
			//spawnstuff
	}

	void OnTriggerEnter (Collider collider)
	{
	}
}
