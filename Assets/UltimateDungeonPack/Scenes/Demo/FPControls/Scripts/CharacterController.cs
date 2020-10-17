/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    public float speed = 10.0f;
    public float sprintSpeed = 1000f;
    public AudioClip audioFile;


    private float translation;
    private float straffe;
    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update() {

        float speedModifier = 1;
        if (Input.GetKey(KeyCode.LeftShift)) {
            speedModifier = sprintSpeed;
        } else {
            speedModifier = speed;
        }
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speedModifier * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speedModifier * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (translation !=0 || straffe != 0)
        {
            GetComponent<AudioSource>().volume = .5f;

        }
        else
            GetComponent<AudioSource>().volume = 0f;

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
                Cursor.lockState = CursorLockMode.Locked;

        }


    }
    
     void FixedUpdate()
     {
        


        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUp = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);

        if (Input.GetKeyDown("space") && rb.transform.position.y <= 0.5f)
        {
            Vector3 jump = new Vector3(0f, 200f, 0f);

            rb.AddForce(jump);
        }

        rb.AddForce(movement * speed);*/

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene("WizardTower", LoadSceneMode.Single);
        }
    }
    
      




}