using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBarWeak : FoodBar
{
    public int weightStatusToSet = 0;

    /*
        Change the player's weight status to weightStatusToSet.
        If the Player's weightStatus is already weightStatusToSet, skip
    */
    protected override void changeWeightStatus(Player player) {
        if (player.weightStatus != weightStatusToSet) {
            player.weightStatus = weightStatusToSet;
            //TODO animation stuff
        }
    }
}
