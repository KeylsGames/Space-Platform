using UnityEngine;
using System.Collections;

public class SuivrePeix : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("La caméra suit peix le petit gobelin :3");
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.position.x + 5, player.position.y / 2, -10);
	}
}
