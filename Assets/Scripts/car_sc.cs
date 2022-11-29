using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class car_sc : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float strng,spd,drc,escapeInput;
    void Start()
    {
        transform.position = new Vector3(930,70,-2);
        Canvas Canvas = GameObject.FindObjectOfType<Canvas>();
        Canvas.enabled = false ;
        Canvas EndGame = GameObject.FindObjectOfType<Canvas>();
        EndGame.enabled = false;
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Canvas Canvas = GameObject.FindObjectOfType<Canvas>();

        Canvas EndGame = GameObject.FindObjectOfType<Canvas>();
        
        escapeInput = Input.GetAxis("Cancel");
        if (escapeInput == 1)
        {
            Canvas.enabled = true;
        }
        else if (escapeInput == 1 && Canvas.enabled == true)
        {
            Canvas.enabled = false;
        }

        if (Canvas.enabled == true)
        {
            strng=Input.GetAxis("Horizontal");
            spd=0f;
            var rbgrv=rb.GetRelativeVector(Vector2.up);
            var v2d=Vector2.Dot(rb.velocity,rbgrv);
            drc = Mathf.Sign(Vector2.Dot(rb.velocity,rb.GetRelativeVector(Vector2.up)));
            rb.rotation -= strng * 0.01f * rb.velocity.magnitude * drc;
            var forceUp = Vector2.up*spd;
            rb.AddRelativeForce(forceUp);
            var forceSt =-Vector2.right*rb.velocity.magnitude*strng/2;
            rb.AddRelativeForce(forceSt);
        }
        else
        {
            strng=Input.GetAxis("Horizontal");
            spd=Input.GetAxis("Vertical")*1500f;
            var rbgrv=rb.GetRelativeVector(Vector2.up);
            var v2d=Vector2.Dot(rb.velocity,rbgrv);
            drc = Mathf.Sign(v2d);
            rb.rotation -= strng * 0.01f * rb.velocity.magnitude * drc;
            var forceUp = Vector2.up*spd;
            rb.AddRelativeForce(forceUp);
            var forceSt =-Vector2.right*rb.velocity.magnitude*strng/2;
            rb.AddRelativeForce(forceSt);
        }

        if (EndGame.enabled == true)
        {
            strng=Input.GetAxis("Horizontal");
            spd=0f;
            var rbgrv=rb.GetRelativeVector(Vector2.up);
            var v2d=Vector2.Dot(rb.velocity,rbgrv);
            drc = Mathf.Sign(v2d);
            rb.rotation -= strng * 0.01f * rb.velocity.magnitude * drc;
            var forceUp = Vector2.up*spd;
            rb.AddRelativeForce(forceUp);
            var forceSt =-Vector2.right*rb.velocity.magnitude*strng/2;
            rb.AddRelativeForce(forceSt);
        }

        
    }
     public void restartgame()
    {
        Canvas EndGame = GameObject.FindObjectOfType<Canvas>();
        EndGame.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void continuegame()
    {
        Canvas Canvas = GameObject.FindObjectOfType<Canvas>();
        Canvas.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D crash)
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter2D(Collider2D parked)
    {
        Canvas EndGame = GameObject.FindObjectOfType<Canvas>();
        EndGame.enabled = true;
    }
}