using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] public GameObject uiObject;
    [SerializeField] public GameObject exitMapButton;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void OnMouseDown()
    {
        uiObject.SetActive(true);
        exitMapButton.SetActive(true);
    }
}
