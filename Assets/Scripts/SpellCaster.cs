/*
 *Purpose: This allows the casting of spells 
 */


using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour 
{
	public float spellDelay1 = 1f;
    public float spellDelay2 = 1f;
    private float spellTimer;
    public float speed = 10f;

    public GameObject bolt1;
    public GameObject bolt2;
    public GameObject barrel;


	// Use this for initialization
	void Start () 
	{
		spellTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if there is a player tag us player input
		if (spellTimer == 0 && this.transform.root.tag == "Player")
			PlayerControls ();
		else if (spellTimer == 0)
			AIControls ();
			
			
			
		if (spellTimer > 0 && spellTimer < spellDelay1)
			spellTimer += Time.fixedDeltaTime;
		else
			spellTimer = 0;
	}

	//input by a player person 
	private void PlayerControls ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			Spell1 ();
		}

		if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			Spell2 ();
		}
	}

	private void AIControls ()
	{
		switch (Random.Range (1, 3))
		{
			case 1:
				Spell1 ();
				break;
			case 2:
				Spell2 ();
				break;
		}
	}

	//this is for the light bolt
	private void Spell1 ()
	{
		Stats stats = this.GetComponent <Stats> ();
		if (stats.mana >= 20) 
		{
			stats.SpellCast (20);
			GameObject bulletClone = (GameObject)Instantiate (bolt1, barrel.transform.position, barrel.transform.rotation);
			bulletClone.GetComponent<Rigidbody> ().velocity = barrel.transform.forward * speed;
			Debug.Log ("spell 1");
			spellTimer += spellDelay1;
		}

    }

	//this is for the heavy bolt
    private void Spell2 ()
	{
		Stats stats = this.GetComponent <Stats> ();
		if (stats.mana >= 35) 
		{
			gameObject.GetComponent <Stats> ().SpellCast (35);
			GameObject bulletClone = (GameObject)Instantiate (bolt1, barrel.transform.position, barrel.transform.rotation);
			bulletClone.GetComponent<Rigidbody> ().velocity = barrel.transform.forward * speed;
			Debug.Log ("Spell 2");
			spellTimer += spellDelay2;
		}

    }
}
