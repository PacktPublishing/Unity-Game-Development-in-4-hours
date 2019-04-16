using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public Text testText;
    public Button testButton;

    private void OnEnable()
    {
        testText.text = "ChangeText is registered";
        testButton.onClick.AddListener(ChangeText);
    }

    private void OnDisable()
    {
        testText.text = "ChangeText is unregistered";
        testButton.onClick.RemoveListener(ChangeText);
    }

    public void ChangeText()
    {
        testText.text = "Button is clicked!!!";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            testText.text = "Space key is pressed";
        }
    }
}
