using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {

    Text sliderValue;
	void Start () {

        sliderValue = GetComponent<Text>();
	}
	
	public void sliderValueUpdate(float value)
    {
        sliderValue.text = Mathf.RoundToInt(value) + "";
    }
}
