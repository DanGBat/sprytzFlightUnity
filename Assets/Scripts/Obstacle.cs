using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;
    public GameObject explosionSound;

    //setup for shake camera on collison
    private Shake shake;

    private void Start()
    {
        //setup for shake camera on collison
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            //shake camera on collison
            shake.CamShake();
            //play sound on collision
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            //play particle system explosion
            Instantiate(effect, transform.position, Quaternion.identity);
            //player takes damage!
            other.GetComponent<Player>().health -= damage;
            // Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }

} 
