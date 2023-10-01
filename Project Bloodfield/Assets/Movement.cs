using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xInput, yInput, 0).normalized;
        movement = movement * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
