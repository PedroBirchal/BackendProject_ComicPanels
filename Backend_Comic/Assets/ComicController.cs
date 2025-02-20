using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ComicController : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private Image image;
    const string path = "https://raw.githubusercontent.com/PedroBirchal/BackendProject_Resources/refs/heads/main/";
    string[] filesToRequest = {"Text.txt", "Claudio.jpg"};

    private void Start(){
        label = GetComponentInChildren<TMP_Text>();
        image = GetComponentInChildren<Image>();
        StartCoroutine(LoadFiles());
    }

    IEnumerator LoadFiles(){
        foreach(var file in filesToRequest){
            Debug.Log($"Generating request for {file}...");
            string filePath = path + file;
            UnityWebRequest fileRequest = UnityWebRequest.Get(filePath);
            yield return fileRequest.SendWebRequest();
            
        }
        /*
        Debug.Log("Generating request for text asset.");
        UnityWebRequest request = UnityWebRequest.Get();
        yield return request.SendWebRequest();
        Debug.Log("Request sent.");

        if(request.result == UnityWebRequest.Result.Success){
            Debug.Log("Text Request was successfull");
            label.text = request.downloadHandler.text;
        }
        */
    }
}
