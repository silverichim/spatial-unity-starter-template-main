using UnityEngine;
using UnityEngine.UI;
public class ZoomController : MonoBehaviour
{
    public Camera minimapCamera;
    public Slider zoomSlider;

    private void Start()
    {
        if (zoomSlider != null)
        {
            zoomSlider.onValueChanged.AddListener(OnZoomValueChanged);
            zoomSlider.value = minimapCamera.orthographicSize;
        }
    }
    private void OnZoomValueChanged(float value)
    {
        if (minimapCamera != null)
        {
            minimapCamera.orthographicSize = value;
        }
    }
}