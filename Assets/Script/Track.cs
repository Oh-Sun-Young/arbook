using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class Track : MonoBehaviour
{
    bool check;
    float timer;
    public TextMeshProUGUI txtTimer;

    public GameObject popupInfo;
    public GameObject popupTimer;

    public ARTrackedImageManager imageManager;
    public List<GameObject> images = new List<GameObject>();
    private Dictionary<string, GameObject> imageCache = new Dictionary<string, GameObject>();

    public List<AudioClip> clips = new List<AudioClip>();
    private Dictionary<string, AudioClip> clipCache = new Dictionary<string, AudioClip>();

    void Start()
    {
        check = false;
        popupInfo.SetActive(true);
        popupTimer.SetActive(false);
        foreach (GameObject image in images) imageCache.Add(image.name, image);
        foreach (AudioClip clip in clips) clipCache.Add(clip.name, clip);
    }
    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnChanged;
    }
    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnChanged;
    }
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage image in eventArgs.added) {
            check = true;
            timer = 12;
            popupInfo.SetActive(false);
            UpdateSound(image);
        }
        foreach (ARTrackedImage image in eventArgs.updated)
        {
            if (!check)
            {
                UpdateImage(image);
            }
        }
    }
    void UpdateImage(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        GameObject gameObject = imageCache[name];
        gameObject.transform.position = image.transform.position;
        gameObject.transform.rotation = image.transform.rotation;
        gameObject.SetActive(true);
    }
    void UpdateSound(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        AudioClip clip = clipCache[name];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    void Update()
    {
        if (check)
        {
            timer -= Time.deltaTime;
            if (timer <= 1f)
            {
                popupTimer.SetActive(false);
                check = false;
            }
            else
            {
                popupTimer.SetActive(true);
                if (timer <= 11f) txtTimer.text = "" + (int)timer;
                else txtTimer.text = " ";
            }
        }
    }
}
