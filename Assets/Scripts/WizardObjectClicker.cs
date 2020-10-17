using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WizardObjectClicker : MonoBehaviour
{
    
    public RawImage milkRI;
    public Image milkIM;
    public RawImage redPotionRI;
    public Image redPotIM;
    public RawImage greenPotionRI;
    public Image greenPotIM;
    public RawImage bluePotionRI;
    public Image bluePotIM;
    public RawImage keyRI;
    public Image keyIM;
    public RawImage scrollRI;
    public Image scrollIM;
    public RawImage chalkRI;
    public Image chalkIM;
    public RawImage wandRI;
    public Image wandIM;
    public RawImage robeRI;
    public Image robeIM;

    public AudioSource meow;




    public Text winLoseText;
    public Text timerText;
    public float timeLeft;

    public GameObject cat;
    public GameObject teleporter;
    public GameObject cabinet;
    public GameObject wardobe;
    public GameObject bucket;
    public GameObject calendar;

    public GameObject mainCam;
    public GameObject cabinetZoom;
    public GameObject bookZoom;

    public static bool redPot;
    public static bool greenPot;
    public static bool bluePot;
    public static bool key;
    public static bool milk;
    public static bool robe;
    public static bool wand;
    public static bool chalk;
    public static bool scroll;

    private Ray ray;
    private List<int> potionAnswer = new List<int>();
    private List<int> codeAnswer = new List<int>();
    private int added = 0;
    private int addedCode = 0;
    private bool foundInAnswer = false;


    private void Start()
    {
        chalkRI.enabled = false;
        redPotionRI.enabled = false;
        greenPotionRI.enabled = false;
        bluePotionRI.enabled = false;
        keyRI.enabled = false;
        milkRI.enabled = false;
        scrollRI.enabled = false;
        wandRI.enabled = false;
        robeRI.enabled = false;

        milk = false;
        key = false;
        redPot = false;
        bluePot = false;
        greenPot = false;
        robe = false;
        wand = false;
        chalk = false;

        meow = GetComponent<AudioSource>();

        winLoseText.text = "";
        mainCam.gameObject.SetActive(true);

    }

    public void Update()
    {

        timeLeft -= Time.deltaTime;
        timerText.text = timeLeft.ToString();

        if (timeLeft < 0)
        {
            winLoseText.text = "You ran out of time! You Lose.";
            winLoseText.enabled = true;
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }

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

                    if (hit.transform.gameObject.CompareTag("MilkBowl"))   //if the object has a Rigidbody grab it
                    {

                        Destroy(hit.transform.gameObject);
                        milkRI.enabled = true;

                    }
                    else if (hit.transform.gameObject.CompareTag("Key"))
                    {
                        Destroy(hit.transform.gameObject);
                        keyRI.enabled = true;
                    }
                    else if (hit.transform.gameObject.CompareTag("NoBread"))
                    {
                        winLoseText.text = "Kitty doesn't want bread.";
                        winLoseText.enabled = true;

                    }
                    else if (hit.transform.gameObject.CompareTag("Potion"))
                    {
                        if (hit.transform.gameObject.name == "Bottle_Health")
                        {
                            Destroy(hit.transform.gameObject);
                            redPotionRI.enabled = true;
                        }
                        if (hit.transform.gameObject.name == "Bottle_Mana")
                        {
                            Destroy(hit.transform.gameObject);
                            bluePotionRI.enabled = true;
                        }
                        if (hit.transform.gameObject.name == "Bottle_Endurance")
                        {
                            Destroy(hit.transform.gameObject);
                            greenPotionRI.enabled = true;
                        }

                    }
                    else if (hit.transform.gameObject.CompareTag("Wand"))
                    {
                        Destroy(hit.transform.gameObject);
                        wandRI.enabled = true;
                    }
                    else if (hit.transform.gameObject.CompareTag("Robe"))
                    {
                        Destroy(hit.transform.gameObject);
                        robeRI.enabled = true;

                        calendar.gameObject.SetActive(true);
                    }
                    else if (hit.transform.gameObject.CompareTag("Chalk"))
                    {
                        Destroy(hit.transform.gameObject);
                        chalkRI.enabled = true;
                    }
                    else if (hit.transform.gameObject.CompareTag("Scroll"))
                    {
                        Destroy(hit.transform.gameObject);
                        scrollRI.enabled = true;
                    }


                    else if (hit.transform.gameObject.CompareTag("Cat"))
                    {
                        if (milk == true)
                        {
                            milkRI.enabled = false;
                            milkIM.enabled = false;

                            cat.gameObject.GetComponent<Animator>().SetTrigger("fedMilk");

                            print("You Fed Him Food!");
                            winLoseText.text = "I approve. To escape you need to make a brew, but don't mix up the colors!";
                            winLoseText.enabled = true;
                            meow.PlayOneShot(meow.clip);
                        }
                        else
                        {
                            winLoseText.text = "FEED ME MORTAL. I REQUIRE SUSTENANCE";
                            winLoseText.enabled = true;
                            meow.PlayOneShot(meow.clip);
                        }                            

                    }
                    else if (hit.transform.gameObject.CompareTag("Wardrobe"))
                    {
                        if (key == true)
                        {
                            keyRI.enabled = false;
                            keyIM.enabled = false;

                            Destroy(hit.transform.gameObject);

                            print("You opened the Wardrobe");
                            winLoseText.text = "Lots of Stuff in Here!";
                            winLoseText.enabled = true;
                        }
                        else
                        {
                            winLoseText.text = "Locked.";
                        }

                    }
                    else if (hit.transform.gameObject.CompareTag("Cauldron"))
                    {
                        if (greenPot == true)
                        {
                            greenPotionRI.enabled = false;
                            greenPotIM.enabled = false;

                            potionAnswer.Add(3);
                            added++;
                            print(added);

                            print("You poured in the Green Potion");
                            winLoseText.text = "Green Potion In!";
                            winLoseText.enabled = true;

                            greenPot = false;
                        }
                        if (bluePot == true)
                        {
                            bluePotionRI.enabled = false;
                            bluePotIM.enabled = false;

                            potionAnswer.Add(2);
                            added++;
                            print(added);

                            print("You poured in the Blue Potion");
                            winLoseText.text = "Blue Potion In!";
                            winLoseText.enabled = true;

                            bluePot = false;
                        }
                        if (redPot == true)
                        {
                            redPotionRI.enabled = false;
                            redPotIM.enabled = false;

                            potionAnswer.Add(1);
                            added++;
                            print(added);

                            print("You poured in the Red Potion");
                            winLoseText.text = "Red Potion In!";
                            winLoseText.enabled = true;

                            redPot = false;
                        }
                        else
                        {
                            winLoseText.text = "Looks tasty.";
                            winLoseText.enabled = true;
                        }

                        if (added == 3)
                        {
                            print("Count: 3");
                            if (potionAnswer[0] == 1 && potionAnswer[1] == 2 && potionAnswer[2] == 3)
                            {
                                print("Got the Correct Answer.");
                                winLoseText.text = "Cat: Wow you actually did it... You can see through illusions now.";
                                meow.PlayOneShot(meow.clip);
                                winLoseText.enabled = true;
                                Destroy(bucket);

                            }
                            else
                            {
                                winLoseText.text = "You seemed to have messed up the potion. You Lose.";
                                SceneManager.LoadScene("Lose", LoadSceneMode.Single);
                            }
                                
                        }

                    }
                    else if (hit.transform.gameObject.CompareTag("CabinetDoor"))
                    {
                        /*
                        if (cabinetZoom.gameObject.activeInHierarchy == true)
                        {
                            print("Changed back to Main");
                            cabinetZoom.gameObject.SetActive(false);
                            mainCam.gameObject.SetActive(true);


                        }
                        else
                        {
                            print("Changed Cams");
                            mainCam.gameObject.SetActive(false);
                            cabinetZoom.gameObject.SetActive(true);
                        }
                        */
                                                                          

                    }

                    else if (hit.transform.gameObject.CompareTag("Teleportation")) //WIN ________________________________________________
                    {
                        if (chalk == true && scroll == true && robe == true && wand == true)
                        {
                            winLoseText.text = "YOU DID IT! YOU ESCAPED!";
                            SceneManager.LoadScene("Win", LoadSceneMode.Single);
                            
                        }
                        else
                            winLoseText.text = "You need more materials!";
                    }

                    else if (hit.transform.gameObject.CompareTag("Num1"))
                    {
                        codeAnswer.Add(1);
                        addedCode++;
                        print(addedCode);
                    }
                    else if (hit.transform.gameObject.CompareTag("Num2"))
                    {
                        codeAnswer.Add(2);
                        addedCode++;
                    }
                    else if (hit.transform.gameObject.CompareTag("Num3"))
                    {
                        codeAnswer.Add(3);
                        addedCode++;
                        print(addedCode);
                    }                    
                    else if (hit.transform.gameObject.CompareTag("Num4"))
                    {
                        codeAnswer.Add(4);
                        addedCode++;
                    }
                    else if (hit.transform.gameObject.CompareTag("Num5"))
                    {
                        codeAnswer.Add(5);
                        addedCode++;
                    }
                    else if (hit.transform.gameObject.CompareTag("Num6"))
                    {
                        codeAnswer.Add(6);
                        addedCode++;
                    }
                    else if (hit.transform.gameObject.CompareTag("Num7"))
                    {
                        codeAnswer.Add(7);
                        addedCode++;
                    }
                    else if (hit.transform.gameObject.CompareTag("Num8"))
                    {
                        codeAnswer.Add(8);
                        addedCode++;
                    }
                    else if (hit.transform.gameObject.CompareTag("Num9"))
                    {
                        codeAnswer.Add(9);
                        addedCode++;

                    }
                    else if (hit.transform.gameObject.CompareTag("Num0"))
                    {
                        codeAnswer.Add(0);
                        addedCode++;
                        print(addedCode);
                    }
                    else
                    {
                        //print("Got into Else");
                        winLoseText.text = "";
                    }

                    if (addedCode == 4)
                    {
                        print(addedCode);
                        if (codeAnswer[0] == 1 && codeAnswer[1] == 1 && codeAnswer[2] == 1 && codeAnswer[3] == 3)
                        {
                            //winLoseText.text = "You Opened the Safe!";
                            Destroy(cabinet);
                        }
                        else
                        {
                            //winLoseText.text = "Hmmm. Wrong combo.";
                            codeAnswer.RemoveRange(0, 5);
                            addedCode = 0;
                        }
                    }
                    



                }
                
            }
        }
    }
}
