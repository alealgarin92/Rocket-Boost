using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] AudioClip MainEngine;
    [SerializeField] ParticleSystem mainBParticles;
    [SerializeField] ParticleSystem leftBParticles;
    [SerializeField] ParticleSystem rightBParticles;

    AudioSource audioSource;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (thrust.IsPressed() == true)
        {
            StartProcessThrusth();
        }
        else
        {
            StopProcessThrusth();
        }
    }

    private void StartProcessThrusth()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(MainEngine);
        }
        if (!mainBParticles.isPlaying)
        {
            mainBParticles.Play();
        }
    }

    private void StopProcessThrusth()
    {
        mainBParticles.Stop();
        audioSource.Stop();
    }

    private void ProcessRotation()
    {
        float rotatioInput = rotation.ReadValue<float>();

        if (rotatioInput < 0)
        {
            StartRightProcessRotation();
        }
        else if (rotatioInput > 0)
        {
            StartLeftProcessRotation();  
        }
        else
        {
            StopProcessRotation();
        }
    }

    private void StartRightProcessRotation()
    {
        ApplyRotation(rotationStrength);
        if (!leftBParticles.isPlaying)
        {
            rightBParticles.Stop();
            leftBParticles.Play();
        }
    }

    private void StartLeftProcessRotation()
    {
        ApplyRotation(-rotationStrength);
        if (!rightBParticles.isPlaying)
        {
            leftBParticles.Stop();
            rightBParticles.Play();
        }
    }

    private void StopProcessRotation()
    {
        rightBParticles.Stop();
        leftBParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }


}
