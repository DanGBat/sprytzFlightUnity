using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    public int score;
    public Text scoreDisplay;
    public Text scoreGameOver;

    private void Update()
    {
        scoreDisplay.text = score.ToString();
        scoreGameOver.text = score.ToString();

        GameObject sprytPlayer = GameObject.Find("sprytPlayer");
        Player player = sprytPlayer.GetComponent<Player>();

        if (player.health <= 0) {
                //destroy score detector
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle")) {
            score++;
            Debug.Log(score);
        }
    }
}
