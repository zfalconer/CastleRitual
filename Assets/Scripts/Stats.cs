using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public float health = 100f;
	public float maxHealth = 100f;
	public float stamina = 100f;
	public float staminaRegen = 20f;
	public float maxStamina = 100f;
	public float mana = 100f;
	public float manaRegen = 5f;
	public float maxMana = 100f;
	public GameObject Character;
    public string spawnerContainer;
    public GameObject[] items = new GameObject[3] { null, null, null };
    public string alignment;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
		stamina += staminaRegen * Time.deltaTime;
		StaminaUse (0f);
		if (stamina > maxStamina) {
			stamina = maxStamina;
		}
		SpellCast (0f);
		if (mana > maxMana) {
			mana = maxMana;
		}
	}

	public virtual void Damage(float damage){
		health -= damage;
		if (health > maxHealth) {
			health = maxHealth;
		}
		if (health <= 0f) {
			health = 0f;
			Destroy(Character);
			//death();
		}
	}

	public virtual bool SpellCast(float depletion){
		if (mana - depletion < 0f) {
			mana = 0f;
			return false;
		}
		mana -= depletion;
		return true;
	}

	public virtual void StaminaUse(float fatigue){
		stamina -= fatigue;
	}

    public virtual void Death()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag(spawnerContainer);
        for (int num = 0; num < 3; num++)
        {
            if(items[num] != null)
            {
                GameObject[] itemSpawnerMessage = GameObject.FindGameObjectsWithTag(items[num].GetComponent<Item>().spawnerContainer);
                itemSpawnerMessage[0].GetComponent<SpawnerScript>().spawned = false;
                items[num] = null;
            }
        }
        spawners[0].GetComponent<SpawnerScript>().spawned = false;
    }
}
