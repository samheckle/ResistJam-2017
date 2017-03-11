using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class MessageScript : MonoBehaviour {
	// SerializeField: use private variable in the inspector
	[SerializeField]
	private TextAsset inkStory; // asset for ink file
	private Story story; // variable to import ink file

	[SerializeField]
	private Canvas canvas; // canvas for text/images
	private GameObject buttonPlace; // placement for button
	private GameObject yourPlace;
	private GameObject theirPlace;

	// UI Prefabs
	[SerializeField]
	private Text yourPrefab;
	[SerializeField]
	private Text theirPrefab;
	[SerializeField]
	private Button buttonPrefab;

	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;

	void Awake(){
		buttonPlace = GameObject.Find("Buttons");
		yourPlace = GameObject.Find("You");
		theirPlace = GameObject.Find("Them");
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
			Button choice = CreateChoiceView("End of story");
			choice.onClick.AddListener(delegate{
				Remove();
				// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				SceneManager.LoadScene ("5 - InLine", LoadSceneMode.Additive);
			});
			
		}
	}
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	void CreateContentView (string text) {
		for(int i=0;i<story.currentTags.Count;i++){
			if(story.currentTags[i] == "you"){
				Text storyText = Instantiate (yourPrefab) as Text;
				Text hold = Instantiate (theirPrefab) as Text;
				hold.transform.SetParent(theirPlace.transform,false);
				storyText.text = text;
				storyText.transform.SetParent (yourPlace.transform, false);
			} else{
				Text storyText = Instantiate (theirPrefab) as Text;
				Text hold = Instantiate (yourPrefab) as Text;
				storyText.text = text;
				storyText.transform.SetParent (theirPlace.transform, false);
				hold.transform.SetParent(yourPlace.transform,false);
			}
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
		// remove children of youPlace
		int canvasChild = yourPlace.transform.childCount;
		for (int i = 0; i < canvasChild - 2; i++) {
				GameObject.Destroy (yourPlace.transform.GetChild (i).gameObject);
		}
		
		// remove children of storyPlace
		int theirChild = theirPlace.transform.childCount;
		for (int i = 0; i < canvasChild - 2; i++) {
				GameObject.Destroy (theirPlace.transform.GetChild (i).gameObject);
		}

		// remove children of buttonPlace
		RemoveButton();
	}

	void RemoveButton(){
		int buttonChild = buttonPlace.transform.childCount;
		for (int i = buttonChild - 1; i >= 0; --i) {
			GameObject.Destroy (buttonPlace.transform.GetChild (i).gameObject);
		}
	}

	void Remove(){
		int canvasChild = yourPlace.transform.childCount;
		for (int i = canvasChild - 1; i >= 0; --i) {
			GameObject.Destroy (yourPlace.transform.GetChild (i).gameObject);
		}
		int storyChild = theirPlace.transform.childCount;
		for (int i = storyChild - 1; i >= 0; --i) {
			GameObject.Destroy (theirPlace.transform.GetChild (i).gameObject);
		}
	}
}
