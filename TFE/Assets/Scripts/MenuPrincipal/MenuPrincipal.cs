using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Panel;
    
    //bool visible = false;

    private bool FixeView;

    public void ShowPanel()
    {
        Panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }

}
