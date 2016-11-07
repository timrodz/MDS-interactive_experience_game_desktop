using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueText : MonoBehaviour {

	/// <summary>
	/// The text field
	/// </summary>
	public Text textField;

	public Text[] texts;

	private int index = 0;

	// Use this for initialization
	void Start() {
		
		textField.text = texts[0].text;

	}

	public void LoadNextText() {

		if (index + 1 >= texts.Length)
			return;

		index++;

		textField.text = texts[index].text;
		EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);

	}

	public void LoadPreviousText() {

		if (index - 1 < 0)
			return;

		index--;

		textField.text = texts[index].text;
		EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);

	}

}