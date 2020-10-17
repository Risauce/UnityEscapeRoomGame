using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class ObjectClicker : MonoBehaviour
{

    public RawImage foodImage;
    public RawImage keyImage;
    public Image foodEnableImage;
    public Image keyEnableImage;

    public AudioSource butt;


    public Text winLoseText;
    public Text timerText;
    public float timeLeft;

    public GameObject wizard;
    public GameObject runeDoor;
    public GameObject lastDoor;

    public static bool key;
    public static bool bread;

    private Ray ray;
    private List<GameObject> runeAnswer = new List<GameObject>();
    private int added=0;
    private bool foundInAnswer = false;


    private void Start()
    {
        foodImage.enabled = false;
        keyImage.enabled = false;
        winLoseText.text =  "";

        butt = GetComponent<AudioSource>();


        key = false;
        bread = false;
    }

    public void Update()
    {

        timeLeft -= Time.deltaTime;
        timerText.text = timeLeft.ToString();

        if (timeLeft < 0)
        {
            winLoseText.text = "You ran out of time! You Lose.";
            winLoseText.enabled = true;

            //if (Input.GetMouseButtonDown(0))
            //{
                SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            //}

        }

        

        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            //Declare a RaycastHit variable
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Create a ray that extends from camera lens to mouseclick

            

            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))    //use the ray to see what gets hit travelling 100 units
            {                          //The out hit is the output of the ray, what it hit
                if (hit.transform != null)  //If not null we hit something in 100 units
                {
                    print("Hit Something!");

                    if (hit.transform.gameObject.CompareTag("WizardFood"))   //if the object has a Rigidbody grab it
                    {

                        Destroy(hit.transform.gameObject);
                        foodImage.enabled = true;

                    }
                    else if (hit.transform.gameObject.CompareTag("Key"))   //if the object has a Rigidbody grab it
                    {

                        Destroy(hit.transform.gameObject);
                        keyImage.enabled = true;

                    }
                    else if (hit.transform.gameObject.CompareTag("Rune")) //Runes!----------------------------------
                    {
                        butt.PlayOneShot(butt.clip);
                        if (hit.transform.gameObject.GetComponent<Light>().enabled == true)
                        {
                            hit.transform.gameObject.GetComponent<Light>().enabled = false;
                            butt.PlayOneShot(butt.clip);
                            runeAnswer.Remove(hit.transform.gameObject);
                            added--;
                            print(added);
                        }
                        else
                        {
                            hit.transform.gameObject.GetComponent<Light>().enabled = true;
                            butt.PlayOneShot(butt.clip);
                            foreach (GameObject rune in runeAnswer)
                            {
                                if (rune.gameObject.name == hit.transform.gameObject.name)
                                {
                                    foundInAnswer = true;
                                }
                            }
                            if (!foundInAnswer)
                            {
                                print("Got into Adding");
                                runeAnswer.Add(hit.transform.gameObject);
                                added++;
                            }
                            if (added == 3)
                            {
                                print("Got to 3 added");
                                if (runeAnswer[0].gameObject.name == "Blue Rune" && runeAnswer[1].gameObject.name == "Orange Rune" && runeAnswer[2].gameObject.name == "Yellow Rune")
                                {
                                    print("Opened!");
                                    //runeDoor.gameObject.transform.Rotate(0, 0, -90);
                                    Destroy(runeDoor);

                                }
                                else
                                {
                                    print("Failed!");
                                    foreach (GameObject rune in runeAnswer)
                                    {
                                        rune.GetComponent<Light>().enabled = false;

                                    }
                                    runeAnswer.RemoveRange(0, 3);
                                    added = added - 3;
                                    print(added);
                                }

                            }
                        }


                    }
                    else if (hit.transform.gameObject.CompareTag("Treasure"))   //if the object has a Rigidbody grab it
                    {
                        winLoseText.text = "You Greedy Sonfabitch!";
                        winLoseText.enabled = true;
                        SceneManager.LoadScene("Lose", LoadSceneMode.Single);

                    }
                    else if (hit.transform.gameObject.CompareTag("DecoyCell"))
                    {
                        winLoseText.text = "Better not talk to him.";
                    }
                    else if (hit.transform.gameObject.CompareTag("Mushroom"))
                    {
                        winLoseText.text = "The wizard can't eat that.";
                    }
                    else if (hit.transform.gameObject.CompareTag("fakeRune"))
                    {
                        winLoseText.text = "It's a rune. I wonder what it means...";
                    }
                    else if (hit.transform.gameObject.CompareTag("Wizard"))
                    {
                        if (bread == true)
                        {
                            foodImage.enabled = false;
                            foodEnableImage.enabled = false;

                            print("You Fed Him Food!");
                            winLoseText.text = "Thank you, its Wind, Fire, Sun.";
                            winLoseText.enabled = true;

                        }
                        else
                        {
                            winLoseText.text = "Please help me, an evil demon has taken my castle and locked me up! I'm very hungry.";
                            winLoseText.enabled = true;
                        }


                    }
                    else if (hit.transform.gameObject.CompareTag("Chain"))
                    {
                        if (key)
                        {
                            keyImage.enabled = false;
                            keyEnableImage.enabled = false;

                            print("You unlocked the chains!");

                            wizard.gameObject.GetComponent<Animator>().SetTrigger("brokeChains");
                            winLoseText.text = "Thank you for freeing me, I will clear the way out.";
                            winLoseText.enabled = true;
                            Destroy(lastDoor);
                            /*
                            Vector3 destination = new Vector3(-2.58650f, -7.814474f, -5.3913f);
                            Vector3 currentPos = wizard.gameObject.transform.position;
                            Vector3 nextPos = Vector3.MoveTowards(currentPos, destination, Time.deltaTime);

                            wizard.gameObject.transform.position = destination;
                            */
                        }
                        else
                        {
                            winLoseText.text = "The Chains are locked.";
                            winLoseText.enabled = true;


                        }
                    }

                    else
                        winLoseText.text = "";


                }
            }
        }
    }

}
