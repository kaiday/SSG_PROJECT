using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathtext : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
