using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class dictationRecognizerButton : MonoBehaviour
{
    public Button button_;
    // Start is called before the first frame update
    void Start()
    {
        button_ = GetComponent<Button>();
        button_.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        if (dictationRecognizer.recognizer.Status == SpeechSystemStatus.Running)
        {
            dictationRecognizer.Stop();
        } else {
            dictationRecognizer.Run();
        }
    }
}
