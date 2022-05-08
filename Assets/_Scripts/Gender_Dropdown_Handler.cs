using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender_Dropdown_Handler : MonoBehaviour
{

    public TMPro.TMP_Dropdown VO_Gender;

    private void start()
    {
        VO_Gender.onValueChanged.AddListener(delegate
        {
            GenderChanged(VO_Gender);
        });
    }
    public void GenderChanged(TMPro.TMP_Dropdown NewGender)
    {
        Debug.Log("NewGender.value");
        Debug.Log(NewGender.value);
    }
}
