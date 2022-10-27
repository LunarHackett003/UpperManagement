using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [System.Serializable]
    public class InputVariables
    {
        public float moveInput;
        public float jumpInput;
        public bool lightInput, heavyInput, rangedInput;
    }



    [SerializeField] InputVariables ivars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
