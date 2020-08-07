# Brackeys Jam 2020.2

## Intro
This is an entry for the fourth Brackeys Game Jam with theme "Rewind"​​.

You are a hero with rewind power (consuming power packs).
Let the monster sing when you are ready.
It won't sing again unless you rewind.
Answer the sequence of melody to win.

*Controls: Mouse click (ESC to quit)*

## Additional Notes

This game is an ear training practice to improve your musical ability (identify pitches/intervals/melody).
The melody is generated by 7 notes in random order.
Trying to make it less boring and more educational.

Currently there is no WebGL version, because the feature (OnAudioFilterRead) is not supported in WebGL.
The issues in the Windows Build is trying to be addressed as well.

## Devlogs
* v1.0.0:
    * Basic oscillator generating melody of 7 notes in random order
    * Scene:
        * Simple menu and levels
        * A text-based scene representing hero and monster
    * UI:
        * Direct display of instructions
        * Input field with hint and confirm button
        * Assistance button: clear, fill hints, sing answer
        * Simple piano with 7 notes (C4 to B4) with toggle input
        * Hero: rewind, power pack
        * Monster: sing, progress bar
        * End game panel to display win/lose information
    * Graphics: menu, button, font
    * Gameplay: three levels given different length hints
* v0.0.0: created a new Unity 2D project

## TODO
* Doing
* TODO
    * Windows build
* Further
    * WebGL build
    * level map menu
    * Graphics: monster, hero, visualisation
    * other sounds, envelope
    * health/retry/flee

## Assets Credits
* ["Simple Free Pixel art styled UI pack"](https://assetstore.unity.com/packages/2d/gui/icons/simple-free-pixel-art-styled-ui-pack-165012)
 by Jakub Varga (Unity Asset Store)
* ["Hana Pixel Font"](https://assetstore.unity.com/packages/2d/fonts/hana-pixel-font-29725)
 by Mystery Corgi (Unity Asset Store)
