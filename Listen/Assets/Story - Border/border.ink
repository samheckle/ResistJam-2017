VAR name1 = "Jenny"
VAR name2 = "Karen"
VAR name3 = "Lisa"
VAR counter = 0

-> questions

=== questions ===
"Passports, please."
*   Hand over the Passports. #italics
    "How long were you in Canada?"
    **  ["1 day."]"Just today."
        "Reason for travel?"
        *** "There was a concert[."] we wanted to see, so we made it into a day trip.<>
        *** "We justed wanted to get away[."] for a while, so we made it into a day trip.<>
        
    **  ["3 days."]"For three days."
        "Reason for travel?"
        *** "There was a concert[."] we wanted to see, so we made it into a long weekend."
        *** "We justed wanted to get away[."] for a while, so we made it into a long weekend."
-  Any alcohol in the vehicle?
*   "No, sir." -> knowEachOther
*   "Nope." -> knowEachOther

= knowEachOther
"How do you all know each other?"
*   ["We go to the same school."]"We all go to the same school." ->whosWho
*   "We grew up together[."], so we had a little reunion." ->whosWho

= whosWho
~ counter++

"Who's {{name1}|{name2}|{name3}}?"
*   "They're in the passenger seat." -> whosWho
*   "They're in the back seat." -> outOfCar
*   "That's me." -> whosWho

= outOfCar
~temp currentName = "Shouldn't be this name"
{ counter == 1:
    ~ currentName = name1
}
{ counter == 2:
    ~ currentName = name2
}
{ counter == 3:
    ~ currentName = name3
}

"{currentName}, could you please step out of the vehicle."
*   "What, why?["] What did she do wrong?"
*   "For what reason?["] I'm pretty sure you can't just do that!"
-   "Just step out of the car ma'am. I can't let you back into America."
*   "She's a med student!["] Just like that, you're going to cut off her education?
*   "She's lived in America for years!["] You can't just stop her from getting back to her HOME. Please!"
-   "Out of the vehicle, {currentName}
->DONE














