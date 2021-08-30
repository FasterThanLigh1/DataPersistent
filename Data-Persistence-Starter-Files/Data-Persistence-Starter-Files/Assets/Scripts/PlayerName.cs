using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
    void Start ()
    {
        var input = gameObject.GetComponent<TMP_InputField>();
        var se= new TMP_InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }

    private void SubmitName(string arg0)
    {
        ManagerScript.Instance.SetName(arg0);
        Debug.Log(arg0);
    }
}
