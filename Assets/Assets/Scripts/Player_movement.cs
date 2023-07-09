using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    // private float xinput;
    private float jump;
    private float speed;
    private bool jump_pressed = false;
    private bool is_grounded = true;
    private bool facing_right = true;
    [SerializeField] Transform ground_check;
    [SerializeField] float check_radius = 0.1f;
    [SerializeField] LayerMask ground_mask;
    [SerializeField] float default_speed = 7f;
    [SerializeField] float fast_speed = 12f;
    [SerializeField] float default_jump = 11f;
    [SerializeField] float high_jump = 22f;
    [SerializeField] float high_jump_time = 0.1f;
    [SerializeField] float down_gravity = 18f;
    [SerializeField] float time_gravity = 15f;
    [SerializeField] AudioSource jump_sound;
    [SerializeField] AudioSource wee_sound;
    [SerializeField] AudioSource fast_sound;
    [SerializeField] AudioSource win_sound;
    [SerializeField] AudioSource player_win_sound;
    [SerializeField] GameObject win_p;
    private Rigidbody2D rb;
    private Transform player_pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player_pos = gameObject.GetComponent<Transform>();
        jump = default_jump;
        speed = default_speed;
    }

    // Update is called once per frame
    void Update()
    {
        // xinput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && is_grounded)
            jump_pressed = true;
        check_ground();
        facing();
    }
    void FixedUpdate() 
    {
        add_velocity();
        change_gravity();
        if(jump_pressed && is_grounded)
        {
            add_jump();
            jump_sound.Play();
            jump_pressed = false;
            is_grounded = false;
        } 
    }
    private void OnTriggerEnter2D(Collider2D other)  // Collision with powerups section
    {
        if(other.gameObject.tag == "jump_pad")
        {
            // jump = high_jump; // For controlled jump on pad

            Invoke("highJump", high_jump_time);
        }

        if(other.gameObject.tag == "speedboost")
        {
            increase_speed();
            fast_sound.Play();
        }

        if(other.gameObject.tag == "speedslow")
        {
            decrease_speed();
        }

        if(other.gameObject.tag == "finish")
        {
            FindObjectOfType<GameManager>().level_complete();
            Instantiate<GameObject>(win_p, other.transform);
            player_win_sound.Play();
            win_sound.Play();

            if(SceneManager.GetActiveScene().name == "Level_1")
            {
                Globals.levels_complete[1] = 1;
                PlayerPrefs.SetInt("Level_1", 1);

            }
            else if(SceneManager.GetActiveScene().name == "Level_2")
            {
                Globals.levels_complete[2] = 1;
                PlayerPrefs.SetInt("Level_2", 1);
            }
            else if(SceneManager.GetActiveScene().name == "Level_3")
            {
                Globals.levels_complete[3] = 1;
                PlayerPrefs.SetInt("Level_3", 1);
            }
        }

        if(other.gameObject.tag == "level_3_sensor")
        {
            FindObjectOfType<Camera_follow>().high_jump_mode();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "jump_pad")
        {
            jump = default_jump;
            FindObjectOfType<Camera_follow>().default_jump_mode();
        }

        if(other.gameObject.tag == "level_3_sensor")
        {
            FindObjectOfType<Camera_follow>().default_jump_mode();
        }
    }
    
    private void add_velocity()
    {
        // rb.velocity = new Vector2(xinput * speed, rb.velocity.y);

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void highJump()
    {
        rb.velocity = (new Vector2(rb.velocity.x, high_jump)); // For automatic jump

        // rb.AddForce(new Vector2(0, high_jump * 25f), ForceMode2D.Force);
        FindObjectOfType<Camera_follow>().high_jump_mode();
        wee_sound.Play();
    }
    private void add_jump()
    {
       rb.velocity = (new Vector2(rb.velocity.x, jump));

       // rb.AddForce(new Vector2(0, jump * 50), ForceMode2D.Force);
    }
    private void check_ground()
    {
        is_grounded = Physics2D.OverlapCircle(ground_check.position, check_radius, ground_mask);
    }
    private void change_gravity()
    {
        if(rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(0f, -down_gravity), ForceMode2D.Force);
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, -time_gravity), ForceMode2D.Force);
        }
    }
    private void facing()
    {
        if(rb.velocity.x > 0 && facing_right == false)
        {
            player_pos.localScale = new Vector3(1f, 1f, 1f);
            facing_right = true;
        }
        else if(rb.velocity.x < 0 && facing_right == true)
        {
            player_pos.localScale = new Vector3(-1f, 1f, 1f);
            facing_right = false;
        }
    }
    public void increase_speed()
    {
        speed = fast_speed;
    }
    public void decrease_speed()
    {
        speed = default_speed;
    }
}
