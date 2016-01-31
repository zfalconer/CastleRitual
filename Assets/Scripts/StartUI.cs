using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour 
{
	public Transform mainMenu;
	public Transform selectButtons;
	public Transform timmy;
	public Transform tommy;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			mainMenu.gameObject.SetActive (true);
			selectButtons.gameObject.SetActive (false);
			timmy.gameObject.SetActive (false);
			tommy.gameObject.SetActive (false);
		}
	}

	public void CharacterSelect()
	{
		mainMenu.gameObject.SetActive (false);
		selectButtons.gameObject.SetActive (true);
		timmy.gameObject.SetActive (true);
		tommy.gameObject.SetActive (true);
	}

	public void StartGame ()
	{
		if (GameObject.Find ("ChoosingObject").GetComponent <CharacterSelect> ().HasPicked ()) 
		{
			SceneManager.LoadScene (1);
			DontDestroyOnLoad (GameObject.Find ("ChoosingObject"));
		}
	}
}
