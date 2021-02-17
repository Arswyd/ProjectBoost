using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;

    // CACHE

    Rigidbody rigidBody;
    AudioSource audioSource;

    // STATE

    enum State { Alive, Dying, Transcending}
    State state = State.Alive;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (state == State.Alive)
        {
            ProcessThrust();
            ProcessRotation();
        }
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // can thrust while rotating
        {
            ApplyThrust();
        }
        else
        {
            StopThrust();
        }
    }

    private void ProcessRotation()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rcsThrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rcsThrust);
        }

        rigidBody.freezeRotation = false; // resumes phisics rotation
    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    private void StopThrust()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
