/*
 *Purpose: This allows the casting of spells 
 */


using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour 
{
	public float spellDelay = 1f;

	private float spellTimer;

	// Use this for initialization
	void Start () 
	{
		spellTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Mouse0) && spellTimer == 0) 
		{
			Spell1 ();
			spellTimer += spellDelay;
		}

		if (Input.GetKeyDown (KeyCode.Mouse1) && spellTimer == 0) 
		{
			Spell2 ();
			spellTimer += spellDelay;
		}

		if (spellTimer >= 1 && spellTimer < spellDelay)
			spellTimer += Time.fixedDeltaTime;
		else
			spellTimer = 0;
	}

	private void Spell1 ()
	{
		this.GetComponent <Stats> ().SpellCast (100f);
		Debug.Log ("spell 1");
	}

	private void Spell2 ()
	{
		this.GetComponent <Stats> ().SpellCast (100f);
		Debug.Log ("Spell 2");
	}
}
