using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderText : MonoBehaviour
{
    [SerializeField] Slider slider;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        ChangeValue();
    }

    public void ChangeValue()
    {
        //  text.text = string.Format("{0:#.00}", slider.value);
        text.text = System.Math.Round(slider.value, 2).ToString();
    }

}
