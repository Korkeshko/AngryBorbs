using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borb : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;
    }

    public void Launch(Vector3 Direction)
    {
        rigidbody2D.isKinematic = false;
        rigidbody2D.AddForce(Direction, ForceMode2D.Impulse);
    }
}
