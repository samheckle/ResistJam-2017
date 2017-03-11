VAR name1 = "Jenny"
VAR name2 = "Karen"
VAR name3 = "Lisa"
VAR counter = 0
VAR currentName = "Shouldn't be this name"

-> questions

=== questions ===
"Passports" #them
* [Hand over the passports.]
- "How long were you in Canada?" #them
*  ["1 day."]"Just today" -> oneDay
*  ["3 days."]"For three days" -> threeDays

= oneDay
<>. #you
"Reason for travel?" #them
* "There was a concert[."] we wanted to see, so we made it into a day trip -> alcohol
* "We justed wanted to get away[."] for a while, so we made it into a day trip -> alcohol

= threeDays
<>." #you
"Reason for travel?" #them
* "There was a concert[."] we wanted to see, so we made it into a long weekend." -> alcohol #you
* "We justed wanted to get away[."] for a while, so we made it into a long weekend." -> alcohol #you

= alcohol
<>." #you
"Any alcohol in the vehicle?" #them
*   "No, sir." -> knowEachOther #you
*   "Nope." -> knowEachOther #you

= knowEachOther
"How do you all know each other?" #them
*   ["We go to the same school."]"We all go to the same school ->whosWho
*   "We grew up together[."], so we had a little reunion ->whosWho

= whosWho
<>." #you
~ counter++

"Who's {{name1}|{name2}|{name3}}?" #them
*   "They're in the passenger seat -> whosWho
*   "They're in the back seat." -> outOfCar #you
*   "That's me -> whosWho

= outOfCar
{ counter == 1:
    ~ currentName = name1
}
{ counter == 2:
    ~ currentName = name2
}
{ counter == 3:
    ~ currentName = name3
}

"{currentName}, could you please step out of the vehicle." #them
*   "What, why?["] What did she do wrong?->stepOut
*   "For what reason?["] I'm pretty sure you can't just do that!->stepOut

= stepOut
<>" #you
"Just step out of the car ma'am. I can't let you back into America." #them

*   "She's a med student!["] Just like that, you're going to cut off her education? -> out
*   "She's lived in America for years!["] You can't just stop her from getting back to her HOME. Please! -> out

= out
<>" #you
"Out of the vehicle, {currentName} #them
-> END


















