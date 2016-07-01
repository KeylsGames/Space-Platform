using UnityEngine;
using System.Collections;

//Code by Luc Manon

//Inutilisé actuellement

public class SuivrePeix : MonoBehaviour {


    #region Variables
    public Transform player; 
    #endregion

    /// <summary>
    /// Pour l'initialisation
    /// </summary>
    void Start ()
    {
        Debug.Log("La caméra suit peix le petit gobelin :3");
	}
	
	/// <summary>
    /// Update est appeplé 1 fois par frame
    /// </summary>
	void Update ()
    {
        //Régle la caméra par rapport au player
        transform.position = new Vector3(player.position.x + 5, player.position.y / 2, -10);
	}
}
