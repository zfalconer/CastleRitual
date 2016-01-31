using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Item : MonoBehaviour {
    public string spawnerContainer;
    public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<Stats>().alignment == gameObject.tag)
        {
            PickUp(col.gameObject, gameObject);
        }
    }

    public void PickUp(GameObject pickup, GameObject item)
    {
        for (int num = 0; num < 3; num++) {
            if(pickup.GetComponent<Stats>().items[num] == null)
            {
                pickup.GetComponent<Stats>().items[num] = item.GetComponent<Item>().prefab;
                Destroy(item);
                if(num == 3)
                {
                    SceneManager.LoadScene("titleScene");
                }
                break;
            }
        }
    }
}
