using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSlowdown : MonoBehaviour {

    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(slowDown());
        Destroy(gameObject, 1.4f);
    }

    IEnumerator slowDown() {
        rb.velocity = new Vector2(0.0f, 24f);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(0.0f, 20f);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(0.0f, 16f);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(0.0f, 10f);
    }
}
