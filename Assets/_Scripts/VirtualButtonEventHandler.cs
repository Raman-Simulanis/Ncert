using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

    // Private fields to store the models
    private GameObject model_1;
    private GameObject model_2;
	private GameObject btn_1;
	private GameObject btn_2;
	public GameObject fbx;
	public GameObject sound_3;
	public GameObject sound_4;
	public GameObject canvas_inner;
	public GameObject arrow;

	int x = 0;
    /// Called when the scene is loaded

    void Start() {

        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i) {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }

        // Find the models based on the names in the Hierarchy
		model_1 = transform.Find("model1").gameObject;
		model_2 = transform.Find("model2").gameObject;

		btn_1 = transform.Find("hs1").gameObject;
		btn_2 = transform.Find("hs2").gameObject;
        // We don't want to show Jin during the startup
		model_1.SetActive(false);
		model_2.SetActive(false);
		btn_1.SetActive(true);
		btn_2.SetActive(true);
    }
 
    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		//Debug.Log(vb.VirtualButtonName);
		Debug.Log("Button pressed!");
		switch(vb.VirtualButtonName) {
		case "btnLeft":
			btn_1.SetActive(false);
			btn_2.SetActive(true);
			model_1.SetActive(false);
			model_2.SetActive(true);
                    break;
		case "btnRight":
			btn_1.SetActive(true);
			btn_2.SetActive(false);
			model_1.SetActive(true);
			model_2.SetActive(false);
           break;
         //   default:
         //       throw new UnityException("Button not supported: " + vb.VirtualButtonName);
         //           break;
        }
		if(x==0)
		{
			x = 1;
			fbx.gameObject.GetComponent<Animation> ().Play ("last");
			fbx.gameObject.GetComponent<AudioSource> ().Stop ();
			sound_3.gameObject.GetComponent<AudioSource> ().Stop ();
			sound_4.gameObject.GetComponent<AudioSource> ().Play ();
			canvas_inner.gameObject.SetActive (false);
			arrow.gameObject.SetActive(false);
		}
    }


    /// Called when the virtual button has just been released:
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { 
		Debug.Log("Button released!");
	}
}