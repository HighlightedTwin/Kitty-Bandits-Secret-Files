using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public Animator animator; // Assign this in the Inspector

    public float normalWalkSpeed = 1f;
    public float fastWalkSpeed = 2f; // Adjust as needed

    public UnityEngine.UI.Image StaminaBar;
    public float Stamina, MaxStamina;
    public float SprintCost, Regen;
    public bool sprinting = false;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("left shift")){
            sprinting = true;
            animator.SetFloat("IsSprinting", fastWalkSpeed);
        } else if (Input.GetKeyUp("left shift") || Stamina == 0){
            sprinting = false;
            animator.SetFloat("IsSprinting", normalWalkSpeed);
        }

        if (sprinting){
            Stamina -= SprintCost * Time.deltaTime;
            if(Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }
        if (!sprinting)
        {
            Stamina += Regen * Time.deltaTime;
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
            animator.SetFloat("IsSprinting", normalWalkSpeed);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        
        
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    
}