using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FoodBar : MonoBehaviour
{
    protected abstract void changeWeightStatus(Player player);

    // when a collider collider enters trigger and is a player, change weight status
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colObject = col.gameObject;
        Player player = colObject.GetComponent<Player>();

        if (player) {
            changeWeightStatus(player);
        }
    }
}
