-> checkout

=== checkout ===
A cheeseburger and fries?
*   "Double cheeseburger[, actually."], actually. With sweet potato fries."
    Your total comes to $8.27. -> checkout.pay
    = pay
    *   "Credit" -> checkout.declined
    *   "Debit" -> checkout.declined
    *   [] "Oh... Should I put my food back?" -> payForThem
    =  declined
    I'm sorry that card was declined.
    -> checkout.pay
    
=== payForThem ===
* "I can pay for that."
->END
* Don't pay for their meal.
->END