using UnityEngine;
using System.Collections;

public class FollowGameObject : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	
	public Transform gameObj;		// Reference to the player.

	void Update ()
	{
		// Set the position to the player's position with the offset.
		transform.position = gameObj.position + offset;
	}
}
