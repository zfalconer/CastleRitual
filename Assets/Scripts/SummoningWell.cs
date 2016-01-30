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
		Good, Evil
	}

	public MonsterType type;

	void OnTriggerEnter (Collider collider)
	{
		switch (type)
		{
			case MonsterType.Good:
			{
				if (collider.transform.root.tag != "Evil")
					FillMana (collider);
				break;
			}

			case MonsterType.Evil:
			{
				if (collider.transform.root.tag != "Good")
					FillMana (collider);
				break;
			}

		}
	}
	
	private void FillMana (Collider collider)
	{
		//heals a persons mana if they are in the area
		if (collider.transform.root.GetComponent <PlayerStats> () != null)
			collider.transform.root.GetComponent <PlayerStats> ().SpellCast (-100f);
	}
}
