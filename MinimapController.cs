using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour {

    public Transform player;
	
	
	// Update after Player has moved
	void LateUpdate () {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //Rotate with Player
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
	}
}
