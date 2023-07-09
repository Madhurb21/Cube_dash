using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_death : MonoBehaviour
{
    private Transform player_pos;
    private Rigidbody2D rb;
    private bool not_collided = true;
    [SerializeField] Vector3 last_checkpoint;
    [SerializeField] Vector3 checkpoint_offset = new Vector3(0, 0.1f, 0);
    [SerializeField] GameObject checkpoint_p;
    [SerializeField] AudioSource checkpoint_sound;
    // Start is called before the first frame update
    void Start()
    {
        Globals.lives = 3;
        player_pos = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.lives == 0)
        {
            Globals.lives = 3;
            FindObjectOfType<Player_movement>().decrease_speed();
            FindObjectOfType<GameManager>().restart_level();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if((other.gameObject.tag == "thorn" || other.gameObject.tag == "deathbed") && not_collided)
        {
            not_collided = false;
            player_pos.position = last_checkpoint;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            FindObjectOfType<Player_movement>().decrease_speed();
            Globals.lives--;
            Globals.deaths++;

            Invoke("not_collided_reset", 0.1f);
        }

        if(other.gameObject.tag == "checkpoint")
        {
            last_checkpoint = other.transform.position + checkpoint_offset;
            Instantiate<GameObject>(checkpoint_p, other.transform);
            checkpoint_sound.Play();
        }
    }

    private void not_collided_reset()
    {
        not_collided = true;
    }
}
