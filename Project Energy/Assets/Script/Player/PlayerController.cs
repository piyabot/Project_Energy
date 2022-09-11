using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IEffectable
{
    public CharacterController controller;

    public float maxHP = 100;
    public float currentHP;
    public HealthBar healthBar;
    public GameObject nearDeath;
    public GameObject Lose;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isSprinting = false;
    public float sprintingSpeed;

    private StatusData _data;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Normal Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded) //Jumping
        {
            velocity.y = Mathf.Sqrt(jumpHeight + -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)) //Sprinting
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isSprinting == true)
        {
            controller.Move(move * sprintingSpeed * Time.deltaTime);
            CameraShaker.Instance.ShakeOnce(0.4f, 0.4f, -0.3f, 0.3f);
        }
      
        if (_data != null) TriggerEffect(); 

        if (currentHP <= 0)
        {
            currentHP = 0;
            Lose.SetActive(true);
            { Time.timeScale = 0; }
        }
        if (currentHP <= 50)
        {
            nearDeath.SetActive(true);
        }
        else
        {
            nearDeath.SetActive(false);
        }
        if (currentHP >= 100)
        {
            currentHP = 100;
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ApplyEffect(StatusData _data)
    {
        RemoveEffect();
        this._data = _data;
    }
    public void ApplyWeakEffect(StatusData _weakdata)
    {
        RemoveEffect();
        this._data = _weakdata;
    }

    public void RemoveEffect()
    {
        _data = null;
        currentEffectTime = 0f;
        lastTickTime = 0f;
    }

    private float currentEffectTime = 0f;
    private float lastTickTime = 0f;
    public void TriggerEffect()
    {
        currentEffectTime += Time.deltaTime;

        if (_data.DOTAmount != 0 && currentEffectTime > lastTickTime + _data.TickSpeed)
        {
            lastTickTime = currentEffectTime;
            currentHP -= _data.DOTAmount;
            healthBar.SetHealth(currentHP);
        }
        if (currentEffectTime >= _data.LifeTime) RemoveEffect();
    }
}
