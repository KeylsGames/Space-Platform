using UnityEngine;
using System.Collections;

//Code by Luc Manon

public class persoController : MonoBehaviour {

    #region Variables

    //Déclarations des variables

    //Variables pour l'animation/déplacement
    public Animator anim;
    public float speed = 5f;
    public Rigidbody2D perso;
    bool aDroite = true;

    //Variables pour le saut
    public Transform checksol;
    bool toucheLeSol = false;
    float rayonSol = 0.3f;
    public LayerMask Sol;

    //Variables pour la mort
    public LayerMask solMortel;
    bool doitMourir = false;

    #endregion

    /// <summary>
    /// Pour l'initialisation
    /// </summary>
    void Start()
    {
        //Récupération du component animator
        anim = GetComponent<Animator>();
        perso = gameObject.GetComponent<Rigidbody2D>(); //Initialise le perso comme un RigidBody2D, nécessaire pour le saut
    }

    /// <summary>
    /// Update est appelé 1 fois par frame
    /// </summary>
    void Update()
    {
        //Récuparation de l'input de l'axe Horizontal
        float x = Input.GetAxis("Horizontal");
        //Donne a la variable speed (dans Unity) le déplacement du personnage
        anim.SetFloat("speed", Mathf.Abs(x));
        transform.Translate(x * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && toucheLeSol == true) //Choisis comme touche de saut la flèche directionnelle haut
        {
            perso.AddForce(new Vector2(0, 225)); //Permet de sauter
        }

        //Avance
        if (x > 0 && !aDroite)
        {
            changerDirection(); //change la direction/sens du sprite vers la droite
        }

        //Recule
        if (x < 0 && aDroite)
        {
            changerDirection(); //change la direction/sens du sprite vers la gauche
        }
    }

    /// <summary>
    /// FixedUpdate pour travailler sur le RigidBody2D
    /// </summary>
    void FixedUpdate()
    {
        toucheLeSol = Physics2D.OverlapCircle(checksol.position, rayonSol, Sol); //Bool passe a true si le perso touche le sol
        anim.SetBool("Sol", toucheLeSol); //Passe le booléen à true et permet de sauter

        doitMourir = Physics2D.OverlapCircle(checksol.position, rayonSol, solMortel); //Bool passe a true si un sol mortel est touché
        anim.SetBool("solMortel", doitMourir); //Passe le booléen à true et lance l'animation de mort
    }

    /// <summary>
    /// Permet de changer la direction d'un sprite
    /// </summary>
    void changerDirection()
    {
        aDroite = !aDroite;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    } 
}
