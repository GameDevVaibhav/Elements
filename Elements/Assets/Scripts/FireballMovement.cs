using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Some vfx needs movement towards the player. This Script finds the target and moves the vfx.
public class FireballMovement : MonoBehaviour
{
    public float rotationSpeed = 30.0f; 
    public float movementSpeed = 1.0f;

    GameObject audioSource;
    public AudioClip DestroyAudioClip;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Destruction_Audio");
    }

    void Update()
    {
        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);

        
        if (transform.eulerAngles.z >= 130f)
        {
            
            rotationSpeed = 250.0f;
        }
        if (transform.eulerAngles.z >= 230f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Opponent"))
        {
            
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        AudioSource audioComp = audioSource.GetComponent<AudioSource>();
        audioComp.PlayOneShot(DestroyAudioClip);
    }
}
