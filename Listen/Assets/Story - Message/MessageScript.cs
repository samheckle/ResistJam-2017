using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class MessageScript : MonoBehaviour {
	// SerializeField: use private variable in the inspector
	[SerializeField]
	private TextAsset inkStory; // asset for ink file
	private Story story; // variable to import ink file

	[SerializeField]
	private Canvas canvas; // canvas for text/images
	private GameObject buttonPlace; // placement for button
	private GameObject youPlace;
	private GameObject themPlace;

	private GameObject newYou;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab;
	[SerializeField]
	private Button buttonPrefab;

	void Awake(){
		buttonPlace = GameObject.Find("Buttons");
		youPlace = GameObject.Find("You");
		themPlace = GameObject.Find("Them");
		StartStory();
	}

	// Use this for initialization
	void StartStory () {
		story = new Story(inkStory.text);
		
		RefreshView();
	}
	
	void RefreshView(){
		MoveChildren();

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
			RemoveChildren();
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
				StartStory();
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
		for(int i=0;i<story.currentTags.Count;i++){
			if(story.currentTags[i] == "you"){
				storyText.transform.SetParent (youPlace.transform, false);
			} else{
				storyText.transform.SetParent (themPlace.transform, false);
			}
		}
			//Debug.Log(story.currentTags[i]);
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
		int canvasChild = youPlace.transform.childCount;
		//Vector3 move = (0,1,0);
		for (int i = canvasChild - 1; i >= 0; --i) {
			GameObject.Destroy (youPlace.transform.GetChild (i).gameObject);
		}
		
		// remove children of storyPlace
		int storyChild = themPlace.transform.childCount;
		for (int i = storyChild - 1; i >= 0; --i) {
			newYou = themPlace.transform.GetChild (i).gameObject;
			newYou.transform.position += new Vector3(0,45,0);
			if(newYou.transform.position.y < -15){
				GameObject.Destroy (themPlace.transform.GetChild (i).gameObject);
			}
		}

		// remove children of buttonPlace
		int buttonChild = buttonPlace.transform.childCount;
		for (int i = buttonChild - 1; i >= 0; --i) {
			GameObject.Destroy (buttonPlace.transform.GetChild (i).gameObject);
		}
	}
}
