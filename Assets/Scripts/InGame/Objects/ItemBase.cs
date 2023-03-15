using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public float moveSpeed;
    bool alreadyGot = false;

    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y <= -7f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyGot)
        {
            TriggerEvent(collision);
            alreadyGot = true;
            Destroy(gameObject);
        }
    }

    protected abstract void TriggerEvent(Collider2D collision);
}
