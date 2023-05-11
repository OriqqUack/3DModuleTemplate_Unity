using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Button : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;

    int _score = 0;

    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"Á¡¼ö : {_score}";
    }
}
