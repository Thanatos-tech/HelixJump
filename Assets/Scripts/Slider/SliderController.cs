using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sliderText;

    public void ChangeSliderValue(float value)
    {
        float localValue = 100.0f * value;
        _sliderText.text = localValue.ToString("0");
    }
}
