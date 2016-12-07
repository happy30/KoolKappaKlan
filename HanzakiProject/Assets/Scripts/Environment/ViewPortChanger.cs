using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortChanger : MonoBehaviour
{

    public enum Type
    {
        ToTD,
        ToSS
    };

    public Type type;

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(type == Type.ToSS)
            {
                col.GetComponent<PlayerController>().levelType = PlayerController.LevelType.SS;
            }
            else
            {
                col.GetComponent<PlayerController>().levelType = PlayerController.LevelType.TD;
            }
            col.GetComponent<PlayerController>().ChangeControlsDependingOnLevelType();
            Camera.main.GetComponent<CameraController>().SetUp();
        }
    }
}
