EXTERNAL EndChat()
EXTERNAL Date()

===guy1===
Hey there, how's it going? # left
Just like any other day. # right 

* So you like writing right? # right
	Yeah. Writing has been my favourite activity since I was a small child. # left
	Awesome, I wished I had meaningful hobbies when I was little. # right
* What books did you read? # right
	I’m glad you asked! I read all kinds of books but my favorites are, The Stranger, Moby Dick, Wuthering Heights, Don Quixote, The Odyssey and Metamorphosis. # left
	That’s a lot of books! They aren’t short books either. # right
- How about you, what do you like? # left

* Well I like reading books too.  # right
    -> guy1knot1
* Nothing in particular. I just float around doing random stuff I felt like that day. #right
    -> guy1knot2

==guy1knot1==
Wow! It’s hard to see a kindred spirit where everyone just stares into the endless void that is phones. #left 
I have a library membership card that could be spared. If you’re free, would you want to go there with me? #left
* Sure. sounds fun. #right
	~ Date()
	-> END
* No thanks book nerd.
    Oh. Then have a good rest of your day. #left
    ~ EndChat()
	-> END

==guy1knot2==
I’m sure you can find your dream hobby someday. #left
If you’re free, would you like to go out for a walk in the park later? #left
* Sure. I would love to. #right
    ~ Date()
	-> END
* No thanks. # right
    It was nice meeting you but I think we would never get along well. #right
    Oh. Have a good rest of your day. #left
        -> END

===guy2===
Hi!!! # left
I'm so glad we matched! # left
I love your taste in fashion # left
* Aww, thank you! # right
* [I don't get that often.]
    Thank you! I don't get that often. # right
- I'm just pointing out what I see :) # left
* What do you do for a living? # right
    ->guy2_1
* What do you do for fun? # right
    -> guy2_2

==guy2_1==
I'm an independent singer-songwriter! # left
It's really tough fighting the labels for a spot in the market, but I've managed to make it work so far # left
Would you like to come to karaoke with me? # left
Don't worry if you're not good at singing, we can just have fun screaming classics pop songs! # left
* Sure. I would love to. # right
    Amazing! I'll book the room!
    ~ Date()
	-> END
* No thanks. # right
    Ah... #left
    ~ EndChat()
    -> END

==guy2_2==
I volunteer at the Pelican Island animal shelter # left
We mostly receive cats, so I have a lot of experience caring for them # left
Since I have nothing to do today... # left
Want to come to the animal shelter with me? # left
I'll introduce you to all the animals!!!! You're gonna love it # left
* Sure. I would love to. # right
    Amazing! I'll let the staff know we're coming!
    ~ Date()
	-> END
* No thanks. # right
    Not even for cute puppies and kittens? #left
    ~ EndChat()
    -> END


===guy3===
Hey there! Your profile looks great. #left
* So you’re a student currently?.#right
    -> guy3_1
* Yours sucks.
    It is impossible to have bad taste, but many people have none at all. Even in an infinite universe, your unique brand of absurdness stands out. Goodbye. # left
	~ EndChat()
	-> END
	
==guy3_1==
Right now I’m majoring in philosophy, just 2 more years until I can finally be free... #left
* That’s awesome. You seem outdoorsy too. #right
    -> guy3_2
* So you’re a hippie with the whole outdoors thing. #right
    To call you a disappointment would imply I expected something from you. I think we would never get along. # left
    ~ EndChat()
    -> END

==guy3_2==
Yeah. My favourite activity is going barbecuing and watching the sunset on Obamah Beach. #left
You like nature too, right? We can hang out there and know each other a bit better! #left
* Sure! That sounds great. #right 
    The time you enjoy wasting is not wasted time, you won’t be disappointed! #left                         
    ~ Date()
    -> END
* No thanks, I don't like sand. # right
    It's coarse and rough and irritating and it gets everywhere  #right
    Blessed is he who expects nothing, for he shall never be disappointed. #left
    ~ EndChat()
    -> END


===guy4===
Hi # left
*Hey there # right
* So, how’s it going? # right
    Not much # left
-*You like sports right?  # right
    Yea, it's the only thing that keeps me going in life, a purpose.#left
    I can show you my swimming skills, only if you have the time I mean # left
    -> guy4_1
*So… tell me about yourself!  # right
    Well.. I like doing sports, especially swimming. That's why I became a lifeguard.  #left 
    In life, I just roll with the waves. # left
    I can show you my swimming skills, only if you have the time I mean# left
    -> guy4_1

==guy4_1==
*Sure, I’d love to. #right
    Wow, really? Let’s meet at the swimming pool then!  # left
    ~ Date()
    -> END
*No thanks wallflower.  # right
    Oh, ok then.  # left
    ~ EndChat()
    -> END


===guy5===
Glad to see we matched # left
Your profile really caught my eye # left
So, what’s a girl like you doing on this hellhole of an app? # left
* [Looking for love] I’m looking for the love of my life. # right
	-> Guy5_1
* [For something casual] I just want something casual, nothing serious. # right
	Oh… # left
	I don’t think we’re a good match for each other. # left
	~ EndChat()
	-> END

==Guy5_1==
Me too # left
I used to go to bars a lot to find someone, but the girls there just didn’t do it for me. # left
I guess we had different goals # left
Finding love in this day and age is really hard. # right
* So, what do you do for a living? # right
	I work as a hairstylist at one of the best salons in town # left
	But I used to want to be a professional wrestler, so I started boxing # left
	I still do it on the weekends. # left
	Have you ever boxed before? # left
	-> guy5_2
	

==guy5_2==
* [Yes] Yes, I have. # right
		Amazing!!! # left
		Let’s test our skills this afternoon, shall we? We can grab coffee afterwards, too # left
		-> guy5_date
	* [No] No, I haven’t. # right
		That’s fine, I’ll teach you
		It’s good for your health, and we can grab coffee afterwards!!
		-> guy5_date

==guy5_date==
* Sure! # right
			~ Date()
			-> END
* No thanks. # right
			Oh…okay then # left
			~ EndChat()
			-> END


===guy6===
Wow # left
I didn’t expect to match with you # left
You’re way out of my league, if I’m being honest # left
* Aww, thank you! # right
	Just my honest opinion :) # left
* [You’re too kind] You're too kind, you’re quite the catch yourself! # right
	Oh, that’s so sweet of you # left
- So... # right
* What do you do in your free time? # right
	-> guy6_1
* What are you looking for on Fumble? # right
	-> guy6_2

==guy6_1==
I work as a game developer, so I play a lot of video games # left
	My favorite games are strategy games, but I don’t think there’s a genre I haven’t tried! # left
	Do you game a lot? # left
	* Yes, all the time! # right
		-> guy6_1_1
	* I’m more of a casual # right
		-> guy6_1_2
-> END

==guy6_1_1==
You really are a special girl # left
		This might be a lot to ask, but would you go out with me? # left
		I know a quiet place with a great view of the ocean where we can chat uninterrupted # left
		* Sure! # right
			Sweet! I’ll buy you a drink on the way # left
			~ Date()
			-> END
		* No thanks. # right
			I must’ve assumed too much. # left
			~ EndChat()
			-> END
-> END

==guy6_1_2==
That’s okay, my friends are the same way # left
		This might be a lot to ask, but would you go out with me? # left
		I know a great cafe where we can get to know each other better # left
		* Sure! # right
			Sweet! It’ll be my treat! # left
			~ Date()
			-> END
		* No thanks. # right
			I must’ve assumed too much. # left
			~ EndChat()
			-> END

==guy6_2==
I want a serious relationship # left
	I haven’t really had a lot of relationship experience because I’m really bad at talking to people in person # left
	But I’ve always dreamed of finding someone I could spend the rest of my life with # left
	Kinda weird but… # left
	Do you think soulmates exist? # left
	* Yes! # right
		Me too! # left
		Maybe we’re meant to be together # left
		Say, do you like video games? # left
		-> guy6_2_1
	* No # right
		I guess you have your reasons…
		That’s so depressing tho
		~ EndChat()
		-> END

==guy6_2_1==
* Of course I do! # right
			Perfect. # left
			Would you go out with me? # left
			I know a quiet place with a great view of the ocean where we can chat uninterrupted # left
			I have a feeling we’ll really get along # left
			-> guy6_2_2
		* Not really # right
			Oh… # left
			I guess I assumed too much # left
			I’m sorry, but I don’t think you’re the right person for me 
            Video games are a huge part of my life, and I want my soulmate to enjoy them too
			~ EndChat()
			-> END

==guy6_2_2==
* Sure! # right
				Sweet! I’ll buy you a drink on the way # left
				~ Date()
				-> END
			* No thanks. # right
				I must’ve assumed too much. # left
				~ EndChat()
				-> END

===guy7===
Hey sexy ;) # left
Whatchu wearing rn? # left
* Clothes # right
	Me too # left
	You should know I’m one of the best streamers out there # left
	Let me give you an aura boost by bringing you to the gaming cave # left
	All the cool people are there, including me # left
	-> guy7_1
* Ew that’s creepy # right
	Creepy??????!!!!!!!111!!! # left
    You just have bad taste # left
    Never text me again you lowlife # left
    ~ EndChat()
    -> END

==guy7_1==
* Sure! # right
	I’ll see you at the gaming cafe then my pwincess # left
	~ Date()
	-> END
* No thanks… # right
	Well if you don’t want me, I’ll take my alpha energy somewhere else # left
    Tasteless bottom feeder. # left
	~ EndChat()
	-> END

===guy8===
You’re really pretty # left
* Thank you! # right
* You look great too! # right
- Did you get plastic surgery? # left
* Did you? # right
	Not yet, but I should # left
	I’m still a normie, but I want to become a real chad # left
* That’s so offensive. # right
	How? I mean it’s only natural # left
- People judge others based on looks # left
You can even get out of jail if you look good # left
That’s why I want to get plastic surgery to get hunter eyes and be more attractive to females # left
So… # left
Want to grab a drink? # left
* Sure! # right
	Oh nice! See you at the bar then # left
	~ Date()
	-> END
* No thanks… # right
	Average stacy.
	This app is just high school all over again
	~ EndChat()
	-> END

===guy9===
* Are you actually 20? # right
	-> guy9_1
* What do you work as? # right
	-> guy9_2

==guy9_1==
Well…as they say, age is just a number # left
	Don’t women nowadays like older guys who can take care of them? # left
	* Not as old as you. # right
		NOT AS OLD AS ME?????? # left
		I’LL HAVE YOU KNOW I’M ONLY A LITTLE MORE THAN 50 # left
		GET BLOCKED YOU UGLY HAG # left
		~ EndChat()
		-> END
	* … # right
		~ EndChat()
		-> END

==guy9_2==
I don’t really talk about that. # left
	* Are you rich? # right
		Getting right to the point, huh? # left
		Damn gold diggers. # left
		~ EndChat()
		-> END
	* How did you afford your Porsche? # right
		The standard way. I took out a loan. # left
		With all my loans from my previous cars, I don’t have a lot of money left to spend. # left
		But I’m willing to use it on you. # left
		What do you say to going on a little date with me to the mall? # left
		-> guy9_2_1

==guy9_2_1==
* Sure! # right
			Wear something pretty tonight for Daddy # left
			~ Date()
			-> END
        * No thanks… # right
			Damn it # left
			Do you women care about money that much??? # left
			~ EndChat()
			-> END

===guy10===
Hello. # left
So, tell me, why would a girl like you match with a guy like me? # left
* What’s wrong with you? # right
	A lot, really. # left
	If I started talking about that now, you would be stuck here for a long time. #left
* Why did you match with me? # right
	You have that spark in your eye that’s hard to find nowadays. # left
	I suppose I didn’t think you’d like me. # left
- But it doesn’t matter, does it? # left
You’re a ray of sunshine. You deserve someone who will take care of you. # left
I’m not here for that. # left
* … # right
	~ EndChat()
	-> END
* Wait… # right
	-> guy10_1

==guy10_1==
What do you want? # left
	* To know more about you. # right
		If you insist. # left
		You wouldn’t be able to tell just by looking at me, but I really like music. # left
		I compose and produce my own music in my free time. # left
		I actually managed to gain a few subscribers on MeTube, but it’s not nearly enough to earn a living. # left
		Not with how I live, anyway. # left
		Rehab has never worked for me. I don’t care about myself enough to change. # left
		-> guy10_2
	* Nothing… # right
		~ EndChat()
		-> END

==guy10_2==
* Let me be your reason.
			Why?
			If you want to…meet me at the park? 
			Let’s take a stroll along the promenade.
			~ Date()
			-> END
		* I see.
			Guess this is where we part. #left
			~ EndChat()
			-> END

===guy11===
Hey! # left
* Hello sir ;) # right
	Haha, no need for formalities # left
	Unless you like the dynamic…I don’t judge ;) # left
* Hi! # right
- I’m glad I matched with you # left
My life right now is stale and boring # left
I want someone new to show me the world from a different perspective # left
As for you… # left
I know the early 20s can be confusing. # left
I’ll be your anchor in this turbulent time # left
Whether you need financial support, advice, or just a shoulder to cry on # left
I’ll be there for you # left
* That sounds good! # right
	Let’s go for a “typical first date” then # left
	The movies!!! # left
	I’ll see you at the cinema # left
	~ Date()
	-> END
* What’s really in it for you? # right
	Of course you would ask that… # left
	My wife and I have been arguing lately # left
	Your wife???? # right
	I’m married, but I’ve been looking to divorce her ever since we had our third kid # left
	She’s just been getting more and more erratic # left
	She’s spent a lot of our money too # left
	Before the divorce, I need someone to support me # left
	I know this situation isn’t what you were imagining, but would you stay by my side regardless? # left
	-> guy11_1

==guy11_1==
* Of course. # right
		Thank you so much. # left
		Let’s talk about something happier - our first date! # left
		How about you meet me behind the town hall, and I’ll bring you wherever you want? # left
		~ Date()
		-> END
	* You cheater! # right
		That… # left
		I suppose you’re not wrong # left
		~ EndChat()
		-> END

===guy12===
What’s up? # left
My eyes went wide when I saw your profile # left
I’ve never seen a girl as special as you before # left
* Thank you! # right
* I thought you met a lot of people # right
	But none like you # left
- I saw on your profile that you live on Pelican Island? # left
I have a friend who lives there too # left
She loves to bowl, so we could all get together for that # left
* That sounds fun # right
	Heyyy, I love bringing people together! # left
	But for now, it can just be you and me, princess # left
	-> guy12_2
* You’re bringing another girl? # right
	What, is there a problem with that? # left
	She’s just a friend now # left
	Come on, I’m sorry # left
	You’re the most special girl I’ve ever met, not her # left
	… # right
	Fine, princess, I’ll put our family’s private jet to good use and fly over to see you one-on-one # left
	Is that good enough for you? # left
	-> guy12_1

==guy12_1==
* Yes! # right
    -> guy12_2
* No. # right
	Some women are just never satisfied. # left
	~ EndChat()
	-> END

==guy12_2==
I’ll meet you at the town square this afternoon, if that’s okay with you? # left
* Sure! # right
	See you there! # left
    ~ Date()
	-> END
* Ehh…no thanks # right
	As if girls like you aren’t a dime a dozen. # left
	~ EndChat()
	-> END

===guy13===
Hey # left
Where do you live? # left
* [(Tell him your address)] My address is 123 Red Pool Road. # right
	Thank you.
	~ Date()
	-> END
* Why? # right
    Hello? # right
    ~ EndChat()
    -> END

===guy14===
You matched with me? # left
I knew it. I knew you’d come back to me. # left
There is no other guy for you. # left
You belong to me, just as I belong to you. # left
Right? # left
* Yes. # right
	Good girl. # left
    I’ll see you behind the town hall tonight. # left
    ~ Date()
    -> END
*Screw off! # right
	Your defiance doesn't change a thing, love. # left
	We’ll be together in the end, whether you like it or not. # left
	~ EndChat()
	-> END

===guy15===
What’s up? # left
Good to see we matched # left
* What do you do in your free time? # right
- I run a photography account on Onstagram. # left 
I take a few selfies, but it’s mostly food and scenery. # left
* What’s your Onstagram handle? # right
	It’s @ryan_photog # left
* How many followers do you have? # right
	Not a lot, haha # left
	About 100, most of them my friends # left
- I don’t know if you’ve ever done modelling, but… # left 
Could you be my model for a day? # left
I won’t do anything with the photos, I swear, and you’ll get to see them afterwards # left
* Sure! # right
    Amazing! I’ll see you at the park tonight! # left
    ~ Date()
    -> END
* No thanks. # right
	Never mind, I guess. # left
	~ EndChat()
	-> END

===guy16===
Heyyyyy # left
What’s the difference between me and a cup of coffee? # left
* What? # right
* A lot, I’m sure. # right
- I stay hot for a long, long time. # left
* That was really good! # right
	Really? # left
	Definitely one of the more original starting lines I’ve heard on here. # right
* That was so bad… # right
	Hahaha, I see I didn’t scare you away though # left
-* What do you do in your free time? # right
	I don’t really have any free time, since I’m a full-time nurse # left
	You wouldn’t believe how long some of my shifts are # left
* What do you do for a living? # right
	I work as a full-time nurse at the hospital on Pelican Island. # left
	It’s really tiring work, but it’s worth it when I see the smiles on my patients’ faces # left
- Since you’re still here after that terrible pickup line, would you like to go out with me? # left
Let’s go explore the abandoned village near the east of the island! I happen to have free time today # left
* Sure! # right
    I knew you’d say yes! I’ll see you near the entrance of the village, then. # left
    ~ Date()
    -> END
* No thanks. # right
	Oh…I didn’t see that coming. # left
	~ EndChat()
	-> END

===guy17===
Hi, I’m happy we matched # left
So, what do you work as? # left
* I’m unemployed # right
* I’m a clown for the circus # right
- What region do you live in? # left
Pelican Island # right
Which street exactly? # left
* [Tell him your address] 123 Red Pool Street # right
	Come outside. # left
	~ Date()
	-> END
* Why do you need to know? # right
	~ EndChat()
	-> END

===guy18===
Hey, we matched! # left
* Are those gains real? # right
	Of course they’re real! Why are you asking??? # left
	I have 100k followers! Do you think I bought them or something? # left
	~ EndChat()
	-> END
* What do you do in your free time? # right
	I don’t really like going outside, if I’m being honest # left
	I prefer more indoorsy activities # left
	-> guy18_1

== guy18_1 == 
* Like what? # right
		I really like knitting little sweaters for my cat…but don’t tell anyone. # left
		-> guy18_2
	* Do you like sports? # right
		Not really, I get tired really easily.
		-> guy18_2

== guy18_2==
- Would you like to go to a coffee shop with me? I know a nice, quiet place we can sit and chat # left
    * Sure! # right
        Great! I’ll see you there. # left
        ~ Date()
        -> END
    * No thanks. # right
	    Is it because I’m too manly? # left
	~ EndChat()
	-> END

===stalker===
Stop trying to block me. # left
Are you seriously on Fumble? # left
You're mine. Got it? MINE. # left
No...it doesn't matter. # left
We'll be together forever. I'll make sure of it. # left
~ EndChat()
-> END