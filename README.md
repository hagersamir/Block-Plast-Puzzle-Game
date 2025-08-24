# 🧩 Block Plast Puzzle Game – Mobile (Android)

**Casual block puzzle game** inspired by the popular *Block Plast Puzzle*, designed for mobile devices.  
Built using **Unity** and **C#**, this project provides a relaxing yet challenging experience where players drag and drop puzzle pieces onto a grid to clear lines and score points.  

---

## 📚 Table of Contents

- [🎯 Features](#-features)
- [📽️ Demo](#-demo)
- [🧠 Technologies Used](#-technologies-used)
- [📱 How to Play](#-how-to-play)
- [👥 Authors](#-authors)
- [🎯 Game Goal](#-game-goal)

---

## 🎯 Features

### 🎮 Core Gameplay
- **8x10 Grid System** – clean design with visible borders for clarity.  
- **7 Unique Puzzle Piece Types:**  
  - 🟦 **L-Shape**  
  - 🟩 **Vertical Line** 
  - 🟥 **Square** 
  - 🟨 **Z-Shape**  
  - 🟧 **Reverse Z-Shape**  
  - 🟪 **Reverse L-Shape**  
  - 🟫 **Horizontal Line**   

### 🖐️ Drag & Drop Mechanics
- Pieces spawn outside the grid.  
- Smooth **drag-and-drop interaction** with snap-to-grid placement.  
- **Grey highlight** for valid placement.  
- **Red highlight** for invalid placement.  
- Auto-return if placement is invalid.  
- Prevents overlapping with existing blocks.  

### 💥 Scoring System & Effects
- ✅ Points are awarded for **every cell placed on the grid**.  
- ✅ Additional bonus points for **clearing full horizontal or vertical lines**.  
- **Boom particle effect** when a line is cleared.  
- Remaining blocks shift down after clearing.  
- Score updates dynamically.  

### 📱 Mobile-Optimized UI
- **Portrait mode layout** for Android.  
- Score counter and progress display.  

#### 📝 List Menu (behind the score)
- 🔄 **Replay** – restart the game from the beginning.  
- ▶️ **Continue** – resume the current game.  
- 🏠 **Home** – return to the main menu.  

#### 🏠 Main Menu
- ▶️ Start Game  
- ❌ Exit Game  

#### 💀 Game Over Screen
- Displays the **overall score achieved** by the player.  
- 🔄 **Replay** button – start a new game immediately.  
- 🏠 **Home** button – return to the main menu.  

---

## 📽️ Demo
https://github.com/user-attachments/assets/d4e81964-1ed5-4840-8882-6adff19d0290

---

## 🧠 Technologies Used

| Domain              | Tech Stack        |
|---------------------|------------------|
| Game Development    | Unity, C#        |
| UI & UX             | Unity UI Toolkit |
| Platform            | Android (Portrait Mode) |
| Visual Effects      | Unity Particle System |
| Version Control     | Git & GitHub LFS |

---

## 📱 How to Play

1. Drag puzzle pieces from the **spawn area** into the grid.  
2. **Grey highlight** = valid placement, **Red highlight** = invalid.  
3. Every **cell placed** gives you points.  
4. Completing a **full horizontal or vertical line** clears it, plays a **boom particle effect**, and gives **bonus points**.  
5. Use the **List Menu** to Replay, Continue, or return Home.  
6. From **Home Menu**, you can Start a new game or Exit.  
7. If no valid moves remain → **Game Over screen** appears:  
   - Shows your **overall score**  
   - Lets you **Replay** or go **Home**  
8. Aim for the **highest score possible**!  

---

## 👥 Authors

- **Hager Samir**

---

## 🎯 Game Goal

The goal of this project is to create a **fun, mobile-friendly puzzle game** that challenges players’ spatial thinking while rewarding them for both **strategic placement** and **line clearing**, enhanced with **menus, score tracking, and visual effects** for a complete gameplay experience.  

---
