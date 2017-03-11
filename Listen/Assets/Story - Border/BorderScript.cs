using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class BorderScript : MonoBehaviour {
	// SerializeField: use private variable in the inspector
	[SerializeField]
	private TextAsset inkStory; // asset for ink file
	private Story story; // variable to import ink file

	[SerializeField]
	private Canvas canvas; // canvas for text/images
	private GameObject buttonPlace; // placement for button
	private GameObject dialogePlace;
	private GameObject storyPlace;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab;
	[SerializeField]
	private Button buttonPrefab;

	void Awake(){
		buttonPlace = GameObject.Find("Buttons");
		dialogePlace = GameObject.Find("Dialogue");
		storyPlace = GameObject.Find("Story");
		StartStory();
	}

	// Use this for initialization
	void StartStory () {
		story = new Story(inkStory.text);
		
		RefreshView();
	}
	
	void RefreshView(){
		RemoveChildren();

		while(story.canContinue){
			string text = story.Continue().Trim();
			CreateContentView(text);
		}

		if(story.currentChoices.Count>0){
			for(int i =0;i<story.currentChoices.Count;i++){
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		else {
			Button choice = CreateChoiceView("End of story.");
			choice.onClick.AddListener(delegate{
				SceneManager.LoadScene ("4 - Message", LoadSceneMode.Single);
			});
		}
	}
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	void CreateContentView (string text) {
		Text storyText = Instantiate (textPrefab) as Text;
		storyText.text = text;
		if(storyText.text.StartsWith("\"")){
			storyText.transform.SetParent (dialogePlace.transform, false);
		} else{
			storyText.transform.SetParent (storyPlace.transform, false);
		}
	}

	Button CreateChoiceView (string text) {
		Button choice = Instantiate (buttonPrefab) as Button;
		
		choice.transform.SetParent (buttonPlace.transform, false);

		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		return choice;
	}

	void RemoveChildren () {
		// remove children of dialogePlace
		int canvasChild = dialogePlace.transform.childCount;
		for (int i = canvasChild - 1; i >= 0; --i) {
			GameObject.Destroy (dialogePlace.transform.GetChild (i).gameObject);
		}
		
		// remove children of storyPlace
		int storyChild = storyPlace.transform.childCount;
		for (int i = storyChild - 1; i >= 0; --i) {
			GameObject.Destroy (storyPlace.transform.GetChild (i).gameObject);
		}

		// remove children of buttonPlace
		int buttonChild = buttonPlace.transform.childCount;
		for (int i = buttonChild - 1; i >= 0; --i) {
			GameObject.Destroy (buttonPlace.transform.GetChild (i).gameObject);
		}
	}
}
