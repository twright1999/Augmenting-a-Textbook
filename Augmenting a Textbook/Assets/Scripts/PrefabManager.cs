using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arObjectsToPlace;

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

        // setup all game objects in dictionary
        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.SetActive(false);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {

        // Assign and Place Game Object
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);

        Debug.Log($"trackedImage.referenceImage.name: {trackedImage.referenceImage.name}");
    }

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);
            goARObject.transform.position = newPosition;
            foreach (GameObject go in arObjects.Values)
            {
                Debug.Log($"Go in arObjects.Values: {go.name}");
                if (go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }
    //private ARTrackedImageManager arTrackedImageManager;

    //[SerializeField]
    //private GameObject[] prefabs;

    //private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    //void Awake()
    //{
    //    arTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

    //    arObjects.Add("qrcode", prefabs[0]);

    //    arObjects.Add("qrcode2", prefabs[1]);

    //    //meshRoot.SetActive(false);
    //    //shaderRoot.SetActive(false);

    //}

    //void OnEnable()
    //{
    //    arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    //}

    //void OnDisable()
    //{
    //    arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    //}

    //private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs ev)
    //{
    //    foreach (ARTrackedImage image in ev.added)
    //    {
    //        Debug.Log("HI");
    //        AssignObject(image.referenceImage.name, image.transform.position);
    //    }

    //    foreach (ARTrackedImage image in ev.updated)
    //    {
    //        AssignObject(image.referenceImage.name, image.transform.position);
    //    }

    //    foreach (ARTrackedImage image in ev.removed)
    //    {
    //        Debug.Log("bye");
    //        arObjects[image.referenceImage.name].SetActive(false);
    //    }
    //}

    //private void AssignObject(string name, Vector3 newPos)
    //{
    //    GameObject newArObject = arObjects[name];
    //    newArObject.SetActive(true);
    //    newArObject.transform.position = newPos;
    //}
}
