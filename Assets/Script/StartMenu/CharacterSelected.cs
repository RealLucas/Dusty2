using UnityEngine;
using System.Collections;

public class CharacterSelected : MonoBehaviour {

	
	public void OnPress(bool isPress)
    {
        if (isPress)
        {
            //StartMenuControl.GetInstance().GetSelectedCharater(this.gameObject);
            StartMenuControl._instance.GetSelectedCharater(this.gameObject);
        }
    }
}
