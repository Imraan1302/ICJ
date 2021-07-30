using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectScipt : MonoBehaviour
{
    public int _key;
    public bool gotKey;
    public Text keyText;
    public MoveCont moveCont;

    // Update is called once per frame
    void Update()
    {
        //Key things... Can add stuff or remove stuff for game objects or whatever
        _key = moveCont.key;
        keyText.text = _key.ToString();





        // Check to see they have the Key
        if (_key <= 0)
        {
            _key = 0;
            gotKey = false;
        }
        if (_key >= 1)
        {
            _key = 1;
            gotKey = true;
        }
    }
}
