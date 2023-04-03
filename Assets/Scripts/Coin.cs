using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        GameObject.FindGameObjectWithTag("UI").GetComponent<IngameUi>().UpdateText();
        Destroy(gameObject);
    }
}
