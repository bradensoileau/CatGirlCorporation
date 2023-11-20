using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public float destoryTime = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomizeTextLocation = new Vector3(0.5f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destoryTime);

        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomizeTextLocation.x, randomizeTextLocation.x),
        Random.Range(-randomizeTextLocation.y, randomizeTextLocation.y), Random.Range(-randomizeTextLocation.z, randomizeTextLocation.z));

    }
}
