using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class SpawnerScript : MonoBehaviour
{
    public GameObject[] spawners;
    public string spawnerTag;
    public GameObject spawningItem;
    public bool spawned;
    public float spawnTime = 1.5f;
    public float timeLeft = 0;
    // Use this for initialization
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag(spawnerTag);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && !spawned)
        {
            Spawn();
        }

		//if there is no object that was spawned respawn it
		if (!GameObject.Find (spawningItem.name + "(Clone)"))
			spawned = false;
    }

    void Spawn()
    {
        if (!spawned) {
            GameObject spawner = spawners[Mathf.FloorToInt(Random.Range(0, spawners.Length))];
            if (!spawner.GetComponent<SpawnerPoint>().Spawn(spawningItem))
            {
                Spawn();
            }
            spawned = true;
        }
        
=======
public class SpawnerScript : MonoBehaviour {
	public GameObject[] spawners;
    public string spawnerTag;
    public GameObject spawningItem;
	public bool spawned;
    public float spawnTime = 1.5f;
    public float timeLeft = 0;
	// Use this for initialization
	void Start () {
        spawners = GameObject.FindGameObjectsWithTag(spawnerTag);
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0 && !spawned)
        {
            Spawn();
        }
	}

	bool Spawn () {
        GameObject spawner = spawners[Mathf.FloorToInt( Random.Range(0, spawners.Length) )];
        GameObject clone = (GameObject)Instantiate(spawningItem, spawner.transform.position, spawner.transform.rotation);
        if (clone != null)
        {
            spawned = true;
            return true;
        }
        else
        {
            return false;
        }
>>>>>>> 48c6847797a9c0053e9a1c658cdd9ed1505b505b
    }


}
