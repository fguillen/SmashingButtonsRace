# Smashing Buttons Race

Small tests project to experiment with smashing buttons adding velocity to a character

## The concept

I tried several ways of implementing a Player velocity based on the velocity the User is
smashing a key.

I was not able to do it using Input system and basic mathematics. I also can not use the
Rigidbody2D physics to the Player it self, or at least they were not working to me the way I needed:

- No inertia
- No infinite acceleration
- More difficulty to increase velocity as faster you go

I came with the idea of using a secondary object that implements some Rigidbody2D physics
based on its own context and using some parts of its actual attributes to change the velocity
of the Player
