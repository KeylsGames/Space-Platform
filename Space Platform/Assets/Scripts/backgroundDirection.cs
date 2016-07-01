using UnityEngine;
using System.Collections;

public class backgroundDirection : MonoBehaviour {

    public Transform player;
    public bool aDroite;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");

        //Avance
        if (x > 0 && aDroite)
        {
            changerDirection();
        }

        //Recule
        if (x < 0 && !aDroite)
        {
            changerDirection();
        }
    }

    void changerDirection()
    {
        aDroite = !aDroite;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
