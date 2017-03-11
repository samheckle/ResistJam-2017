-> start_conversation

=== start_conversation ===
Hey did you see that Obama banned the pledge in school? #them
*   What, no[!] I definitely didn't! <>
    -> cantBeTrue
*   No I didn't[!], that's crazy! <>
    -> cantBeTrue
= cantBeTrue
There's no way that's true! #you
Well what did you expect was going to happen? I could've seen this coming.
* [It's not true.]No, it's definitely not true. -> lookedItUp
* [You're wrong.]No, you're wrong. -> lookedItUp

= lookedItUp
<> I looked it up. The article you shared isn't real. #you
So what? #them
-> soWhat

= soWhat
* So what?! #you
* You're kidding me. #you
- Yeah. So what? It doesn't matter. It's something that he would do. #them
* [No, it isn't.] No, it isn't. Because he hasn't done it. -> noWay
* [But he didn't do it.] But he ACTUALLY didn't do it. -> noWay

= noWay
<> There's just no way. #you
Yeah, but you can't know for sure that he won't. You don't know the president personally, and you have no idea what he's going to do. Did he call you up and get your approval for bin Laden? #them
* Of course not[!], and I can know for sure that he isn't going to ban the damn pledge. -> justWish #you
* That's besides the point. -> fakeNews #you

= fakeNews
* The point is that you shared [fake news.] an article that is a lie. -> factCheck #you
* The point is that you [believed that article.] blindly believed that article, and didn't think twice before sharing it. -> factCheck #you

= factCheck
Well you can't expect me to fact check every article I read. #them
* Yes I can. -> checkEveryArticle #you
* [I expected more of you.] -> wow #you

= wow
Wow. #them
* Sorry. -> youreAnAsshole #you
* I'm not sorry. -> fuckYou #you

= youreAnAsshole
You're being an asshole. #them
* I'm sorry! -> justWish #you
* Cool. -> END #you

= justWish
I lose respect every time you talk down to me. Do you think I'm going to just agree with you when all you do is act like I'm a worse human being than you? #them
* You're right. -> youreSorry
* I'm sorry, okay? -> youreSorry

= checkEveryArticle
You want me to look up EVERY article that I ever read? #them
* [There's a difference between reading and sharing.]
* [You should want to do that yourself.]
- What would be the point of reading an article if I'm supposed to distrust it the entire time, and then after reading it, I'm allowed to look it up and determine for myself whether that time was spent in vain? #them
* [You would be a more engaged reader.]
* [You wouldn't share something that's false.]
- If I can't trust what I read, then what's the point of reading it in the first place? #them
* [You shouldn't blindly trust anything.]
* [You should be critical of what you consume!]
- I have so much else to do and the last thing I want is to have to add "news researcher" to that list. I just want to be able to trust in what I read. #them
* Could you listen, please? #you
** I want that too. -> samePage
** You can't just trust in anything. -> tellMeWhatToDo #you

= tellMeWhatToDo
Would you STOP telling me what I can and can't do?
* I'm sorry. -> youreSorry
* Could you please just LISTEN. -> no

= samePage
<> We're on the same page here. #you
I doubt it. #them
* No, really[.]. I don't want that either, but I'm willing to spend the time researching if it means I don't spread lies. -> whateverYouSay
* That's fine[.] Just believe me when I say that I get where you're coming from. -> whateverYouSay #you

= whateverYouSay
Whatever you say. #them
-> END

= no
No. You're pissing me off. #them
* I'm glad. -> END #you
* Oh come on. -> seriously #you

= seriously
Seriously. Don't talk down to me. I'm not going to listen if you're just going to act better than me because I believed one article. #them
* It's your fault you didn't realize it was fake. -> fuckYou #you
* I'm sorry. -> youreSorry #you

= youreSorry
<> I don't want to argue. I just want to explain myself. #you
Ok. #them
* We all have a responsibility[.] to only talk about and share things that are both true and reasonable. It's like rumors. If you never say something that's false (or something that you're unsure about) you'll never spread a rumor. #you
* We can't get caught up in being angry[.], even though it's the easy thing to do. It's easy to be angry, but it's important to ignore that anger and understand what's making you angry. #you
- Ok. #them
-> END

= fuckYou
Fuck you. -> END #them

-> END





















