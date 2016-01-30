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
			Spell1 ();
		}

		if (Input.GetKeyDown (KeyCode.Mouse1) && spellTimer == 0) 
		{
			Spell2 ();
		}

		if (spellTimer >= 0)
			spellTimer += Time.fixedDeltaTime;
		else
			spellTimer = 0;
	}

	private void Spell1 ()
	{
		this.GetComponent <Stats> ().SpellCast (100f);
        GameObject bulletClone = (GameObject)Instantiate(bolt1, barrel.transform.position, barrel.transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
        Debug.Log ("spell 1");
        spellTimer += spellDelay1;

    }

    private void Spell2 ()
	{
		this.GetComponent <Stats> ().SpellCast (100f);
        GameObject bulletClone = (GameObject)Instantiate(bolt1, barrel.transform.position, barrel.transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
        Debug.Log ("Spell 2");
        spellTimer += spellDelay2;

    }
}
