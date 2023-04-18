using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int bottles = 0;

    [SerializeField] private TMP_Text bottlesText;

    // Checks if the player has collided with a bottle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottle")) {

            bottles++;
            bottlesText.text = bottles + "/10";
            Destroy(collision.gameObject);
        }
    }
}
