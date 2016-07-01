using UnityEngine;
using System.Collections;

public class persoController : MonoBehaviour {

    #region Variables
    //Déclarations des variables
    public Animator anim;
    public float speed = 5f;
    public Rigidbody2D perso;

    public Transform checksol;
    bool toucheLeSol = false;
    float rayonSol = 0.3f;
    public LayerMask Sol;

    bool aDroite = true; 
    #endregion


    // Use this for initialization
    void Start ()
    {
        //Récupération du component animator
        anim = GetComponent<Animator>();
        perso = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Récuparation de l'input de l'axe Horizontal
        float x = Input.GetAxis("Horizontal");
        //Donne a la variable speed (dans Unity) le déplacement du personnage
        anim.SetFloat("speed", Mathf.Abs(x));
        transform.Translate(x * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && toucheLeSol == true)
        {
            perso.AddForce(new Vector2(0, 225));
        }

        //Avance
        if (x > 0 && !aDroite)
        {
            changerDirection();
        }

        //Recule
        if (x < 0 && aDroite)
        {
            changerDirection();
        }
    }

    void FixedUpdate()
    {
        toucheLeSol = Physics2D.OverlapCircle(checksol.position, rayonSol, Sol);
        anim.SetBool("Sol", toucheLeSol);
    }

    void changerDirection()
    {
        aDroite = !aDroite;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
