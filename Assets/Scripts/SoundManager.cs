using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject pirogPickUp;
    public GameObject pirogVagnSound;
    public GameObject crashSound;
    public GameObject winSound;
    public GameObject loseSound;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    public void SetPlayer(GameObject incomingObj)
    {
        player = incomingObj;
    }

    public void PirogPickSound()
    {
        GameObject sound = Instantiate(pirogPickUp, player.transform.position, Quaternion.identity);
        StartCoroutine(DestroySound(sound));
    }

    public void PirogVagnSound()
    {
        GameObject sound = Instantiate(pirogVagnSound, player.transform.position, Quaternion.identity);
        StartCoroutine(DestroySound(sound));
    }

    public void CrashSound()
    {
        GameObject sound = Instantiate(crashSound, player.transform.position, Quaternion.identity);
        StartCoroutine(DestroySound(sound));
    }

    public void PlayWinSound()
    {
        GameObject sound = Instantiate(winSound, player.transform.position, Quaternion.identity);
        StartCoroutine(DestroySound(sound));
    }

    public void PlayLoseSound()
    {
        GameObject sound = Instantiate(loseSound, player.transform.position, Quaternion.identity);
        StartCoroutine(DestroySound(sound));
    }

    IEnumerator DestroySound(GameObject soundObj)
    {
        yield return new WaitForSeconds(1);
        Destroy(soundObj);
    }
}
