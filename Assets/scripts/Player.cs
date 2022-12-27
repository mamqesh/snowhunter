using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject snowBall;
    [SerializeField] private float speed = 500f;
    [SerializeField] private int health = 100;
    private float x = 180;
    private float y = 0;
    [SerializeField] public Text textHealth;
    void Start()
    {
        textHealth.text = health.ToString();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetInput();
        if (Input.GetMouseButtonDown(0))
        {
            var newSnowBall = Instantiate(snowBall, point.position, Quaternion.identity);
            var rb = newSnowBall.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(point.forward * speed, ForceMode.VelocityChange);
            }
        }

        x += Input.GetAxis("Mouse X");
        y += Input.GetAxis("Mouse Y") * -1;

        transform.localRotation = Quaternion.Euler(0, x, 0);
        gun.localRotation = Quaternion.Euler(y, 0, 0);
    }

    public CharacterController controller;
    public float speedPlayer = 60f;
    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speedPlayer * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speedPlayer * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speedPlayer * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speedPlayer * Time.deltaTime;
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        textHealth.text = health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}