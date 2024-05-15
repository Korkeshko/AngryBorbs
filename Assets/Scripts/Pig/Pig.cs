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
        }
    }

    private void OnDestroy()
    {
        GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");
        if (pigs.Length == 0)
        {
            Debug.LogWarning("You won! Good job!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Headshot!");
        }
    }
}


// public class GameManager : MonoBehaviour
// {
//     private void Start()
//     {
//         Debug.LogWarning("OnHitResult += HitResult");
//         Pig.OnHitResult += HitResult;
//     }

//     private void OnDestroy()
//     {
//         Pig.OnHitResult -= HitResult;
//     }

//     private void HitResult(string tag)
//     {
//         Debug.LogWarning("HitResult");
//         if (tag == "Borb")
//         {
//             Debug.LogWarning("tabag == 'Borb'");
//             GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");
//             if (pigs.Length == 1)
//             {
//                 Debug.LogWarning("You won! Good job!");
//                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//             }
//             else
//             {
//                 Debug.Log("Headshot!");
//             }
//         }           
//         else if (tag == "Block")
//         {
//             // TODO переделать
//             // перенести вызов соприкосновения с pig на borb
//             // и уже из borb вызвать OnHitResult
//         }
//     }
// }


      