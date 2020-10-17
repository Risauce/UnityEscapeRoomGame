using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateImage : MonoBehaviour
{

    public Image theImage;
    // Start is called before the first frame update
    void Start()
    {
        theImage.enabled = false;
        enabled = false;
    }

    public void switchActive()
    {
        if (theImage.enabled)
        {
            theImage.enabled = false;

            if (theImage.gameObject.CompareTag("BreadImage"))
            {
                print("Bread Disabled!");
                ObjectClicker.bread = false;
            }
            else if (theImage.CompareTag("KeyImage"))
            {

                ObjectClicker.key = false;
            }
            else if (theImage.CompareTag("MilkBowl"))
            {
                WizardObjectClicker.milk = false;
            }

            else if (theImage.CompareTag("redPotion"))
            {
                WizardObjectClicker.redPot = false;
            }
            else if (theImage.CompareTag("bluePotion"))
            {
                WizardObjectClicker.bluePot = false;
            }
            else if (theImage.CompareTag("greenPotion"))
            {
                WizardObjectClicker.greenPot = false;
            }

            else if (theImage.CompareTag("Key"))
            {
                WizardObjectClicker.key = false;
            }
            else if (theImage.CompareTag("Wand"))
            {
                WizardObjectClicker.wand = false;
            }
            else if (theImage.CompareTag("Robe"))
            {
                WizardObjectClicker.robe = false;
            }
            else if (theImage.CompareTag("Chalk"))
            {
                WizardObjectClicker.chalk = false;
            }
            else if (theImage.CompareTag("Scroll"))
            {
                WizardObjectClicker.scroll = false;
            }


        }
        else
        {
            theImage.enabled = true;
            if (theImage.CompareTag("BreadImage"))
            {
                print("Bread Enabled!");
                ObjectClicker.bread = true;
            }
            else if (theImage.CompareTag("KeyImage"))
            {
                ObjectClicker.key = true;
            }
            else if (theImage.CompareTag("MilkBowl"))
            {
                print("Got here");
                WizardObjectClicker.milk = true;
            }


            else if (theImage.CompareTag("redPotion"))
            {
                WizardObjectClicker.redPot = true;
            }
            else if (theImage.CompareTag("bluePotion"))
            {
                WizardObjectClicker.bluePot = true;
            }
            else if (theImage.CompareTag("greenPotion"))
            {
                WizardObjectClicker.greenPot = true;
            }


            else if (theImage.CompareTag("Key"))
            {
                WizardObjectClicker.key = true;
            }
            else if (theImage.CompareTag("Wand"))
            {
                WizardObjectClicker.wand = true;
            }
            else if (theImage.CompareTag("Robe"))
            {
                WizardObjectClicker.robe = true;
            }
            else if (theImage.CompareTag("Chalk"))
            {
                WizardObjectClicker.chalk = true;
            }
            else if (theImage.CompareTag("Scroll"))
            {
                WizardObjectClicker.scroll = true;
            }
        }

    }



}
