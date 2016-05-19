using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
   
    private Image content;
    private float fillAmount;

    public float MaxValue { get; set; }
    public float CurValue { set
        {
            fillAmount = CalcAmount(value, 0, MaxValue, 0, 1);
        }
    }
	
	void Start () {
        Component[] components = GetComponentsInChildren<Image>();
        foreach (Component c in components)
        {
            if (c.name == "Content")
            {
                content = c as Image;
                
            }
        }
    }
	
	
	void Update () {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float CalcAmount(float value,float inMin,float inMax,float outMin,float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    public void Init()
    {
        CurValue = MaxValue;
    }
}
