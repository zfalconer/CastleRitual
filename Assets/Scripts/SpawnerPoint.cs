using UnityEngine;
using System.Collections;

public class SpawnerPoint : MonoBehaviour {
    public bool spawned = false;
    public float countdown = 0.0f;
    public float spawnCounter = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0) { spawned = false; }
	}

    public bool Spawn( GameObject spawningItem)
    {
        if (!spawned)
        {
            GameObject clone = (GameObject)Instantiate(spawningItem, transform.position, transform.rotation);
            spawned = true;
            return true;
        }
        else { return false; }
    }
}
