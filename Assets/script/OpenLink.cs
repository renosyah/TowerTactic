using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour {


    string fb = "https://www.facebook.com/renosyah975";
    string git = "https://github.com/renosyah";

    public void openFB()
    {
        Application.OpenURL(fb);
    }

    public void openGIT()
    {
        Application.OpenURL(git);
    }
}
