using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pig : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private CameraShakes cameraShakes;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Borb") 
        {
            cameraShakes.Shake();
            Destroy(rb.gameObject);

            GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");
            if (pigs.Length == 1)
            {
                print($"You won! Good job!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                print($"Headshot!");
            }       
        }
    }
}