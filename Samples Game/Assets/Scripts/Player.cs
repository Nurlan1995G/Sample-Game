using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f, thrust = 1000f;
    Rigidbody rb;

    public Text scoreText;

    private int _score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //rb.AddForce(new Vector3(h, 1, v));
        rb.velocity = transform.TransformDirection(new Vector3(v, rb.velocity.y, -h));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cube")
        {
            rb.AddForce(new Vector3(-1, 1, 0) * thrust);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
           _score++;
           Destroy(other.gameObject);

           if (_score != 5)
              scoreText.text = "Score:" + _score;
           else
              scoreText.text = "You win!";
        }
    }
}
