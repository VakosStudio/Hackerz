using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    private Transform trans;
    public float speed = 5f;
    public Light sun;
    public float maxIntensity = 2f;
    public float minIntensity = 0f;
    public float maxAbient = 0.7f;
    public float minAbient = 0;

    public Color DayColor = new Color(80, 80, 80, 80);
    public Color NightColor = new Color(0, 0, 0, 250);

    private Transform stars;

    void Start()
    {
        trans = GetComponent<Transform>();
        stars = trans.Find("Stars");
    }

    
    void Update()
    {
        trans.Rotate(0, 0, speed * Time.deltaTime);
        LightSetting();
    }

    private void LightSetting()
    {

        if(trans.rotation.eulerAngles.z > 0 && trans.rotation.eulerAngles.z < 180)
        {
            sun.intensity = maxIntensity;
            RenderSettings.ambientIntensity = maxAbient;
            RenderSettings.ambientLight = DayColor;
            stars.gameObject.SetActive(false);
        }
        else
        {
            sun.intensity = minIntensity;
            RenderSettings.ambientIntensity = minAbient;
            RenderSettings.ambientLight = NightColor;
            stars.gameObject.SetActive(true);
        }
    }
}
