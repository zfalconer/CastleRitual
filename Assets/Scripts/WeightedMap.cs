/*
 *Purpose: This assignes weights to transforms for pathing 
 */

using UnityEngine;
using System.Collections;

public class WeightedMap
{
	private GameObject[] transforms;
	private int[] weights;

	public WeightedMap (GameObject[] array)
	{
		transforms = array;
		
		weights = new int[array.Length]; 

		//randomly assigns the weights
		for (int y = 0; y < weights.Length; y++) 
		{
			weights [y] = (int)Random.Range (0, 100);
			Debug.Log (weights[y]);
		}
	}

	//this gets the heighest weighted transform
	public GameObject PopHeighestWeight ()
	{
		int index = 0;
		int max = weights [index];
		for (int i = 1; i < weights.Length; i++) 
		{
			if (max < weights [i]) 
			{
				index = i;
				max = weights [index];
			}
				
		}

		if (max == -1)
			return null;

		weights [index] = -1;
		return transforms[index];
	}
	
}
