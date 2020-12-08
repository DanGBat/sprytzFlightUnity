using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    
    public float Xincrement;
    public float transitionSpeed;
    public float maxLeft;
    public float maxRight;

    public int health = 3;

    public GameObject effect;
    
    public Text healthDisplay;

    public GameObject gameOver;

    public GameObject whooshSound;
    public GameObject deathSound;

    private void Update()
        {
            healthDisplay.text = health.ToString();

            if (health <= 0) {
                //play death song
                Instantiate(deathSound, transform.position, Quaternion.identity);
                //show game over overlay scene
                gameOver.SetActive(true);
                //destroy player sprite
                Destroy(gameObject);
            }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > maxLeft) {
            //play sound on movement
            Instantiate(whooshSound, transform.position, Quaternion.identity);
            //particle effect on movement
            Instantiate(effect, transform.position, Quaternion.identity);
            //move player left
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
            transform.position = targetPos;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxRight) {
            //play sound on movement
            Instantiate(whooshSound, transform.position, Quaternion.identity);
            //particle effect on movement
            Instantiate(effect, transform.position, Quaternion.identity);
            //move player right
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
            transform.position = targetPos;
        }
    }
}
