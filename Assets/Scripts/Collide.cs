using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    bool dead=false;
    private void Update()
    {

        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Player>().enabled=false;
            Die();
        }
    }
    void Die()
    {
        
        Invoke(nameof(ReloadLevel),1.3f);
        dead = true;
        deathSound.Play();
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
}
