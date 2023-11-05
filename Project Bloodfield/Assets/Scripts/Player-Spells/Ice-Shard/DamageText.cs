using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public TextMesh textMesh;
    public float destoryTime = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomizeTextLocation = new Vector3(0.5f, 0, 0);
    public float elapsedTime = 0.0f;

    public void ShowDamage(float damage, Vector3 position)
    {
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomizeTextLocation.x, randomizeTextLocation.x),
        Random.Range(-randomizeTextLocation.y, randomizeTextLocation.y), Random.Range(-randomizeTextLocation.z, randomizeTextLocation.z));
        textMesh.text = damage.ToString();
        gameObject.SetActive(true);

    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > destoryTime)
        {
            gameObject.SetActive(false);
        }
    }
}
