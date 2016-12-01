using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartUIManager : MonoBehaviour {

    public Image katanaIcon;
    public Image bombIcon;
    public Image hookIcon;
    public Image boxIcon;
    public Image shurikenIcon;

    public Image heldItem;
    public Image emptyItem;

    public Text player1Place;
    public Text player2Place;

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
        heldItem = itemGot;
    }

    void HeldItemUsed()
    {
        heldItem = emptyItem;
    }
}
