using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class keywordRecognizer : MonoBehaviour
{
    public string[] keywords;
    public static KeywordRecognizer recognizer;
    public delegate void moveDelegate(movement move);
    public static event moveDelegate move;
    // Start is called before the first frame update
    void Start()
    {
        keywords = new string[]{"go", "down", "left", "right"};
        recognizer = new KeywordRecognizer(keywords);
        recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    // Update is called once per frame
    void Update()
    {}

    void OnDestroy() 
    {
       recognizer.Dispose(); 
    }

    public static void Run()
    {
        if (dictationRecognizer.recognizer.Status == SpeechSystemStatus.Running) {
            print("Stop DictationRecognizer first please");
            return;
        }
        print("Start keywordRecognizer");
        PhraseRecognitionSystem.Restart();
        recognizer.Start();
    }

    public static void Stop()
    {
        print("Stop keywordRecognizer");
        recognizer.Stop();
        PhraseRecognitionSystem.Shutdown();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == "go") {
            move(movement.Up);
        } else if (args.text == "down") {
            move(movement.Down);
        } else if (args.text == "left") {
            move(movement.Left);
        } else if (args.text == "right") {
            move(movement.Right);
        }
    }
}
