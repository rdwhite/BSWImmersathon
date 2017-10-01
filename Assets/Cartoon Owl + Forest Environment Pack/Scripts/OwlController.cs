using UnityEngine;
using System.Collections;

public class OwlController : MonoBehaviour {

    public void Fly()
    {
        GetComponent<Animator>().SetBool("isFly", true);
    }

    public void Landing()
    {
        GetComponent<Animator>().SetBool("isFly", false);
    }
}
