using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour 
{
	public GameObject playerController;

	private GameObject goodKid;
	private GameObject evilKid;

	// Use this for initialization
	void OnLevelWasLoaded (int i)
	{
		if (i == 1)
		{
			Debug.Log ("Wooo");
			GameObject.Find ("GoodSpawnerContainer").GetComponent <SpawnerScript> ().spawningItem = goodKid;
			GameObject.Find ("EvilSpawnerContainer").GetComponent <SpawnerScript> ().spawningItem = evilKid;
		}
			
	}

	//pick good kid passing in evil kid
	public void PickGood (GameObject evil)
	{
		goodKid = playerController;
		playerController.GetComponent <PlayerStats> ().alignment = "Good";
		evilKid = evil;
	}

	//pick evil kid passing in the evil kid
	public void PickEvil (GameObject good)
	{
		goodKid = good;
		playerController.GetComponent <PlayerStats> ().alignment = "Evil";
		evilKid = playerController;
	}

	public bool HasPicked ()
	{
		if (goodKid != null || evilKid != null)
			return true;

		return false;
	}
}
