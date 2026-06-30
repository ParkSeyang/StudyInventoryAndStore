using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    public void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           transform.position += new Vector3(-UserData.Instance.moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(UserData.Instance.moveSpeed * Time.deltaTime, 0, 0);
        }
        
    }
    
}
