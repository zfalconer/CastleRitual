using UnityEngine;
using System.Collections;

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
        
    }


}
