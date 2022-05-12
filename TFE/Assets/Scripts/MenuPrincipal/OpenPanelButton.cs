using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelButton : MonoBehaviour
{

    [SerializeField]
    private PanelType type;

    private MenuController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<MenuController>();
    }

    public void OnClick()
    {
        controller.Openpanel(type);
    }
}
