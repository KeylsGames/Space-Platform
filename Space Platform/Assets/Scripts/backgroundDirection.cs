using UnityEngine;
using System.Collections;

//Code by Luc Manon

//Pire escroquerie du monde pour faire suivre un background :DD
//Le background suit le personnage, et s'inverse quand il change de direction pour rester fluide.

public class backgroundDirection : MonoBehaviour {

    #region Variables

    //Déclarations des variables
    public Transform player;
    public bool aDroite; 
    #endregion

    /// <summary>
    /// Pour l'initialisation
    /// </summary>
    void Start ()
    {
	
	}
	
	/// <summary>
    /// Update est appelé 1 fois par frame
    /// </summary>
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

    /// <summary>
    /// Permet de changer la direction du background
    /// </summary>
    void changerDirection()
    {
        aDroite = !aDroite;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    } 

}
