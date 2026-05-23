---

What Changed and Why

The original midterm GDD described Sky Runner as an endless runner game with obstacles, bonuses, score progression, and future features like ads and customization.

In the final version, the main idea stayed the same, but the scope was reduced. The game became a simple 3-lane mobile runner. The player stays in a fixed position while the road and obstacles move toward the player. This still creates an endless runner feeling, but it is easier to build and more stable for the final project.

A score-based win condition was also added. The original idea was more endless, but the final project required a full start → play → win/lose → restart loop. Because of this, the player wins when the score reaches 150.

---

Mechanics Implemented

- Main menu with Play button
- Scene transition from Main Menu to Game
- Pause panel
- Restart button
- Main Menu button
- Three-lane movement
- Jump mechanic
- Jumping animation
- Running animation
- One obstacle type
- Random obstacle spawning
- Moving obstacles
- Moving road
- Score system
- Time system
- Score-based win condition at 150 score
- Collision-based lose condition
- Win panel
- Lose panel
- Mobile UI buttons
- Canvas Scaler with 1080x1920 reference resolution
- DOTween lane movement animation
- DOTween jump punch scale effect
- DOTween win/lose panel Sequence
- DOTween OnComplete usage

---

Mechanics Cut and Why

- Score multiplier bonus: Cut because the normal score system was enough for the final loop.
- Temporary invincibility: Cut because it needed extra timing, UI feedback, and balancing.
- Slow motion bonus: Cut because it would make obstacle speed and movement more complex.
- Coin collection: Cut because the game already has a score system.
- High score tracking: Cut because it was not required for the basic final loop.
- Leaderboard: Cut because it was a future feature and not needed for the final build.
- Ads: Cut because monetization was not needed for the playable project.
- Character customization: Cut because it needed extra UI, assets, and saving.
- Multiple obstacle types: Cut to keep the game simple and stable.
- Difficulty progression: Cut because the final version focuses on a short, stable gameplay loop.

---

New Mechanics Added

- Score-based win condition: The player wins when the score reaches 150.
- Time text: Shows how long the player has survived.
- Pause panel: Added for the final project requirement.
- Settings panel: Added for the menu structure requirement.
- Mobile UI buttons: Added so the game can be played on a phone.
- DOTween animations: Added to meet the animation requirement and improve game feel.
- Safe Area support: Added to make the UI work better on mobile screens.
- Jumping animation: Added to give better visual feedback during jumps.

---

DOTween Usage

The final project uses at least 3 DOTween animations:

1. Player lane movement uses `DOMoveX` with `Ease.OutQuad`.  
   This makes lane switching quick but smooth.

2. Player jump uses `DOPunchScale`.  
   This creates a small juice effect when the player jumps.

3. Win and lose panels use a DOTween `Sequence`.  
   The sequence has 3 steps:
   - Panel fades in
   - Title scales up
   - Restart button scales up

`OnComplete` is used after the player hit animation. When the hit animation finishes, the lose panel opens.

---

AI Usage During Development

AI was used step by step during development:

1. AI suggested keeping the player fixed and moving the road and obstacles.
2. AI helped with Unity scripts for lane movement, jump, obstacle spawning, score, time, win, and lose systems.
3. AI helped me plan DOTween animations, including Sequence and OnComplete.
