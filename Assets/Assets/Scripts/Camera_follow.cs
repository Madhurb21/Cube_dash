using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    private Transform camera_pos;
    private Camera main_camera;
    private float desired_size;
    [SerializeField] Transform player_pos;
    [SerializeField] float follow_speed = 5f;
    [SerializeField] Vector3 offset = new Vector3(0, 1.758f, -10f);
    [SerializeField] float default_size = 5f;
    [SerializeField] float high_jump_size = 6f;
    [SerializeField] float jump_time = 3f;
    [SerializeField] float size_speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        camera_pos = gameObject.GetComponent<Transform>();
        main_camera = gameObject.GetComponent<Camera>();
        desired_size = default_size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target_position = new Vector3(player_pos.position.x + offset.x, player_pos.position.y + offset.y, offset.z);
        Vector3 final_position = Vector3.Lerp(camera_pos.position, target_position, follow_speed);
        camera_pos.position = final_position;

        main_camera.orthographicSize = Mathf.Lerp(main_camera.orthographicSize, desired_size, size_speed);
    }

    public void high_jump_mode()
    {
        desired_size = high_jump_size;
    }
    public void default_jump_mode()
    {
        Invoke("default_mode", jump_time);
    }
    private void default_mode()
    {
       desired_size = default_size;
    }
}
