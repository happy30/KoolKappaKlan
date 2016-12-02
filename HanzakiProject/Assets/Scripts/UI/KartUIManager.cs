using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartUIManager : MonoBehaviour {

    public Sprite katanaIcon;
    public Sprite bombIcon;
    public Sprite hookIcon;
    public Sprite boxIcon;
    public Sprite shurikenIcon;

    public Sprite heldItem;
    public Sprite emptyItem;

    public Sprite player1Standing;
    public Sprite player2Standing;

    public Text player1Round;
    public Text player2Round;

    void DrawMinimap()
    {

    }

    void DrawRanks()
    {

    }

    void DrawSpeed()
    {

    }

    void DrawHeldItem(Image itemGot)
    {
        //heldItem = itemGot;
    }

    void HeldItemUsed()
    {
       // heldItem = emptyItem;
    }
}
