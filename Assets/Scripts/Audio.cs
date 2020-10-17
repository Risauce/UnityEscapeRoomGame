using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip audioFile;
    public AudioSource meow;
    
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        //coroutine = WaitMeow(30);
        meow = GetComponent < AudioSource >();

    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(coroutine);
        //GetComponent<AudioSource>().volume = 1f;
        //audio.PlayDelayed(30.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cat") {
            meow.Play();

        }
    }

    /*private IEnumerator WaitMeow(float waitTime)
    {
       // GetComponent<AudioSource>().volume = 0f;
        //yield return new WaitForSeconds(waitTime);
        //GetComponent<AudioSource>().volume = 1f;

    }*/
}
