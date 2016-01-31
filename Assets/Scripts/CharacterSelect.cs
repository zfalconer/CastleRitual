using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour 
{
	public GameObject playerController;

	private GameObject goodKid;
	private GameObject evilKid;

	// Use this for initialization
	void Start () 
	{
		if (goodKid != null && evilKid != null)
		{
			GameObject.Find ("GoodSpawnerContainer").GetComponent <SpawnerScript> ().spawningItem = goodKid;
			GameObject.Find ("EvilSpawnerContainer").GetComponent <SpawnerScript> ().spawningItem = evilKid;
		}
			
	}

	//pick good kid passing in evil kid
	public void PickGood (GameObject evil)
	{
		goodKid = playerController;
		evilKid = evil;
	}

	//pick evil kid passing in the evil kid
	public void PickEvil (GameObject good)
	{
		goodKid = good;
		evilKid = playerController;
	}
}
