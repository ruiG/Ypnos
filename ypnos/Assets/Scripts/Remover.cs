using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour
{
	public GameObject deadAnimation;


	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			// .. stop the Health Bar following the player
			/*if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
			{
				GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
			}*/

			// ... instantiate the splash where the player falls in.
			//Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			col.SendMessage("Die");	
		}
	}

}