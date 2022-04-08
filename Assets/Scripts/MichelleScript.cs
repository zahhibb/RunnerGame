using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichelleScript : MonoBehaviour
{
    public class HealthDisplay : MonoBehaviour
    {
        public GameObject[] hearts; //[0] [1] [2]
        private int life; //3
        private bool dead;

        private void Start()
        {
            life = hearts.Length;
        }

        private void Update()
        {
            if (dead == true)
            {
                //not finished
                // SET DEATH
                Debug.Log("Kebab");
            }
        }

        public void TakeDamage(int d)
        {

            if (life >= 1)
            {
                life -= d; //1-1=0
                Destroy(hearts[life].gameObject); //[0]
                if (life < 1)
                {
                    dead = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                //help
                TakeDamage(1);
            }
        }
    }

    public class Obstacles : MonoBehaviour
    {
        public AudioClip audioClip;

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {

                AudioSource.PlayClipAtPoint(audioClip, transform.position);


                //---------------Sebbe Kod
                GameObject.Find(" insert name here ").GetComponent<HealthDisplay>().TakeDamage(1);
                

                //////--------
            }
        }

    }
}
