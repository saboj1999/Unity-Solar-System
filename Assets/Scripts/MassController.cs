using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassController : MonoBehaviour
{
    public GameObject body;
    public Slider massSlider;

    // Start is called before the first frame update
    void Start()
    {
        massSlider.value = body.GetComponent<BodyProperties>().mass;
        massSlider.minValue = body.GetComponent<BodyProperties>().mass / 5.0f;
        massSlider.maxValue = body.GetComponent<BodyProperties>().mass * 5.0f;
        massSlider.onValueChanged.AddListener(delegate {ValueChangeCheck();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueChangeCheck()
	{
		body.GetComponent<BodyProperties>().mass = massSlider.value;
	}
}
