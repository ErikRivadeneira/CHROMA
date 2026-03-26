# Chroma

Chroma is a small puzzle prototype built around a state-based interaction system combining color and size. The focus of the project is readability: Ensuring players can quickly understand how the system behaves and why.

The design explores how multiple simple states can be combined to create layered interactions within a constrained scope.

## Overview

The player interacts with the world through two main states: color and size.

Color determines which elements can be activated, while size affects spatial access and certain interactions. Most challenges come from aligning both states correctly.

The system is deterministic, meaning the same situation will always produce the same result. This helps players learn the rules quickly and build confidence in the system.

## Core Design Goals

- Build a clear, state-driven interaction system  
- Prioritize readability and consistency  
- Combine simple mechanics to create layered interactions  
- Keep behavior deterministic and predictable  
- Work within a small, constrained scope  

## Systems Overview

The project is structured around a set of simple, modular systems:

- **Player State System**  
  Manages both color and size states and handles transitions.

- **Interaction System**  
  Validates interactions based on player state. Most gameplay rules are defined here.

- **Feedback System**  
  Communicates interactions through visual responses such as color transitions, scaling, and environmental signals.

- **Environment Elements**  
  Elements either modify player state (e.g., color containers) or validate it (e.g., buttons, gates), using shared interaction rules.

## Core Systems

### Color System

Color is the primary interaction layer.

- Containers change the player’s color  
- Buttons and gates require matching color  
- Most interactions are gated through color alignment  

This establishes a consistent rule: matching color enables interaction.

### Size System

Size acts as a supporting system that introduces spatial and contextual constraints.

- Narrow passages require the player to shrink  
- Large buttons require the player to grow  
- Size is used alongside color in later levels  

There are no size-only puzzles; instead, size is combined with color to add complexity without introducing new mechanics.

### Combined Interaction

In later levels, both systems are used together.

Players must align color and size simultaneously to progress, increasing complexity through combination rather than additional systems.

## Visual & Feedback Design

Visual feedback is used to communicate both state and interaction outcomes.

- **Color Interpolation**  
  Used for state changes to make transitions easier to follow over time.

- **Scale Feedback**  
  Button interactions use quick size changes to confirm input.

- **Objective Signaling**  
  A pulsing light provides guidance toward goals without UI.

- **Wall Shader**  
  Subtle deformation distinguishes walls from the background while preserving clear boundaries and avoiding misleading affordances.

Each feedback type has a specific role to avoid overlapping signals.

## Iteration & Trade-offs

The color system originally used RGB, but this created readability issues against a dark background. Switching to RGY improved contrast and reduced ambiguity.

Visual polish was added carefully to improve clarity without introducing confusion. Motion and transitions were constrained to avoid implying mechanics that do not exist.

## Implementation Notes

- Player state (color and size) is centralized and drives all interactions  
- Interactions are abstracted through a shared interface, allowing different elements to respond consistently  
- Interaction logic is separated from visual feedback to maintain clarity and predictability  
- Feedback systems are tied to specific interaction types to avoid overlap  
- Visual effects are constrained to prevent false affordances (e.g., no timing-based implication)  

## Constraints

The project was developed within a limited timeframe and a deliberately small scope.

This resulted in:
- a focused set of mechanics  
- reuse of systems across multiple interactions  
- emphasis on clarity over content volume  

## Key Takeaways

- Combining simple systems can create layered interactions  
- Readability is critical for player understanding  
- Deterministic systems improve learnability and trust  
- Constraints help focus design decisions rather than limit them  
