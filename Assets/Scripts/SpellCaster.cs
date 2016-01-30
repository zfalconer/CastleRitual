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
		if (Input.GetKeyDown (KeyCode.Mouse0) && spellTimer == 0) 
		{
			Debug.Log ("Called");
			Spell1 ();
		}

		if (Input.GetKeyDown (KeyCode.Mouse1) && spellTimer == 0) 
		{
			Spell2 ();
		}
			
		if (spellTimer > 0 && spellTimer < spellDelay1)
			spellTimer += Time.fixedDeltaTime;
		else
			spellTimer = 0;
	}

	//this is for the light bolt
	private void Spell1 ()
	{
		gameObject.GetComponent <Stats> ().SpellCast (20);
        GameObject bulletClone = (GameObject)Instantiate(bolt1, barrel.transform.position, barrel.transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
        Debug.Log ("spell 1");
        spellTimer += spellDelay1;

    }

	//this is for the heavy bolt
    private void Spell2 ()
	{
	    gameObject.GetComponent <Stats> ().SpellCast (35);
        GameObject bulletClone = (GameObject)Instantiate(bolt1, barrel.transform.position, barrel.transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
        Debug.Log ("Spell 2");
        spellTimer += spellDelay2;

    }
}
