using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class dictationRecognizer : MonoBehaviour
{
    public static DictationRecognizer recognizer;
    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        recognizer = new DictationRecognizer();
        recognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            message.text = text + "\n";
        };

        recognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
        };

        recognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        recognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void OnDestroy() 
    {
       recognizer.Dispose(); 
    }

    public static void Run()
    {
        if (keywordRecognizer.recognizer.IsRunning) {
            print("Stop KeywordRecognizer first please");
            return;
        }
        print("DictationRecognizer started ");
        recognizer.Start();
    }

    public static void Stop()
    {
        print("DictationRecognizer stoped");
        recognizer.Stop();
    }
}
