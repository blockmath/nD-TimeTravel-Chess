using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

public class RadioListController : MonoBehaviour
{
    [SerializeField] GameObject contentField;


    public List<Button> buttons;

    public int selectedIndex;

    [SerializeField] UnityEvent<int> SelectionUpdated;

    // Start is called before the first frame update
    void Start()
    {
        Assert.AreEqual(contentField.transform.parent.parent, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
