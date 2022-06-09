using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField]
    private GameObject _winScreen;

    private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                _winScreen.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
        }
}

