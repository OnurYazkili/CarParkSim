using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class car_sc : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float steeringAmount,speed,direction,escapeInput;
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
            steeringAmount=Input.GetAxis("Horizontal");
            speed=0f;
            direction = Mathf.Sign(Vector2.Dot(rb.velocity,rb.GetRelativeVector(Vector2.up)));
            rb.rotation -= steeringAmount * 0.01f * rb.velocity.magnitude * direction;
            rb.AddRelativeForce(Vector2.up*speed);
            rb.AddRelativeForce(-Vector2.right*rb.velocity.magnitude*steeringAmount/2);
        }
        else
        {
            steeringAmount=Input.GetAxis("Horizontal");
            speed=Input.GetAxis("Vertical")*1500f;
            direction = Mathf.Sign(Vector2.Dot(rb.velocity,rb.GetRelativeVector(Vector2.up)));
            rb.rotation -= steeringAmount * 0.01f * rb.velocity.magnitude * direction;
            rb.AddRelativeForce(Vector2.up*speed);
            rb.AddRelativeForce(-Vector2.right*rb.velocity.magnitude*steeringAmount/2);
        }

        if (EndGame.enabled == true)
        {
            steeringAmount=Input.GetAxis("Horizontal");
            speed=0f;
            direction = Mathf.Sign(Vector2.Dot(rb.velocity,rb.GetRelativeVector(Vector2.up)));
            rb.rotation -= steeringAmount * 0.01f * rb.velocity.magnitude * direction;
            rb.AddRelativeForce(Vector2.up*speed);
            rb.AddRelativeForce(-Vector2.right*rb.velocity.magnitude*steeringAmount/2);
        }
        

        
    }
     public void restartgame()
    {
        Canvas Canvas = GameObject.FindObjectOfType<Canvas>();
        Canvas.enabled = false ;
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