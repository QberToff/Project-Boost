using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;

    private void Awake()
    {
        winText.enabled = false;
        loseText.enabled = false;
    }

    public void WinText()
    {
        winText.enabled = true;
    }

    public void LoseText()
    {
        loseText.enabled = true;
    }
}
