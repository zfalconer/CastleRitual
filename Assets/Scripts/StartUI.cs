using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour 
{
	public Transform mainMenu;
	public Transform timmy;
	public Transform tommy;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void CharacterSelect()
	{
		mainMenu.gameObject.SetActive (false);
		timmy.gameObject.SetActive (true);
		tommy.gameObject.SetActive (true);
	}

	public void StartGame ()
	{
		SceneManager.LoadScene (1);
	}
}
