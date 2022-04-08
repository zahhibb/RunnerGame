using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleScript : MonoBehaviour
{
    private GameObject gameManagerObject;
    private SoundManager soundManager;
    private UIManager uiManager;

    void Awake()
    {
        gameManagerObject = GameObject.Find("GameManager");
        soundManager = gameManagerObject.GetComponent<SoundManager>();
        uiManager = gameManagerObject.GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var childTransformAnimator = other.transform.GetChild(0).GetComponent<Animator>();
            childTransformAnimator.enabled = true;
            childTransformAnimator.SetBool("StartSpinning", true);
            StartCoroutine(StopSpinning(childTransformAnimator));
            soundManager.RandomSpinningSound();
            gameManagerObject.GetComponent<GameManager>().TakeDamage();
            uiManager.UpdateLifes();
            other.transform.GetComponent<PlayerController>().ModifyPlayerState(false, true);
        }
    }

    private IEnumerator StopSpinning(Animator animator)
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("StartSpinning", false);
        animator.enabled = false;
    }
}
