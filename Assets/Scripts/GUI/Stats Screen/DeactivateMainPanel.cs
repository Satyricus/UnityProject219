using UnityEngine;
using System.Collections;

public class DeactivateMainPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;

    public void DeactivatePanel()
    {
        mainPanel.SetActive(false);
    }
}
