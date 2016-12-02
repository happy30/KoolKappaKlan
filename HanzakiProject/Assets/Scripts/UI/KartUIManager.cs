using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartUIManager : MonoBehaviour {

    public KartGameManager stats;

    public Sprite katanaIcon;
    public Sprite bombIcon;
    public Sprite hookIcon;
    public Sprite boxIcon;
    public Sprite shurikenIcon;

    public Sprite heldItem;
    public Sprite emptyItem;

    public Text player1Standing;
    public Text player2Standing;

    List<int> playerStandings = new List<int>();

    public Text player1Round;
    public Text player2Round;

    public Text rank1;
    public Text rank2;


    void DrawMinimap()
    {

    }

    public void SortRanks()
    {
        if (stats.player1Checkpoints > stats.player2Checkpoints){
            player1Standing = rank1;
            player2Standing = rank2;
        }
        else{
            player1Standing = rank2;
            player2Standing = rank1;
        }
      //  DrawRanks();
    }

    public void DrawRanks()
    {
    }

    void DrawSpeed()
    {

    }

    void DrawHeldItem(Sprite itemGot)
    {
        heldItem = itemGot;
    }

    void HeldItemUsed()
    {
        heldItem = emptyItem;
    }
}
