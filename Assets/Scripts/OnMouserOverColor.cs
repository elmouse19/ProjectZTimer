using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseOverColor : MonoBehaviour
{
	//When the mouse hovers over the GameObject, it turns to this color (red)
	Color m_MouseOverColor = new Color(0, 200, 255, 1);

	//This stores the GameObject’s original color
	Color m_OriginalColor;

	//Get the GameObject’s mesh renderer to access the GameObject’s material and color
	Image m_Image;

	void Start()
	{
		//Fetch the mesh renderer component from the GameObject
		m_Image = GetComponent<Image>();
		//Fetch the original color of the GameObject
		m_OriginalColor = m_Image.color;
	}

	void OnMouseOver(PointerEventData eventData)
	{
		// Change the color of the GameObject to red when the mouse is over GameObject
		m_Image.color = m_MouseOverColor;
	}

	void OnMouseExit(PointerEventData eventData)
	{
		// Reset the color of the GameObject back to normal
		m_Image.color = m_OriginalColor;
	}
}