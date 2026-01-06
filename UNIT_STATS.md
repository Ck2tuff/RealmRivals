# ⚔️ Realm Rivals: Core Unit Balance Document

This document tracks the base statistics for all initial units. These values are used by the `UnitController.cs` script.

## Core Balance Parameters

| Attribute | Range | Notes |
| :--- | :--- | :--- |
| **Elixir Cost** | 1 - 10 | Determines card frequency and strategy. |
| **DPS** | 10 - 200 | Damage output per second. |
| **HP** | 100 - 3000 | Health points. |
| **Speed** | Slow, Medium, Fast | NavMesh Agent speed setting. |

## Starting Roster

| Unit | Class | Cost | HP | DPS | Speed | Target | Attack Type | Special Ability |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| **Knight** | Melee Tank | 3 | 1200 | 100 | Medium | Ground | Single Target | None (Pure Durability) |
| **Archer** | Ranged DPS | 3 | 400 | 150 | Fast | Air & Ground | Single Target | High rate of fire |
| **Crimson Dragon** | Flying Tank | 4 | 1500 | 80 | Slow | Air & Ground | Area Splash (AoE) | Deals splash damage in small radius |
| **Healer** | Support | 4 | 750 | 0 | Medium | Ground | Support | Heals nearby allies for 50 HP/sec |

## Tower Stats

| Tower | Type | Initial HP | Damage | Notes |
| :--- | :--- | :--- | :--- | :--- |
| **Princess Tower** | Structure | 2500 | 150 | Targets air and ground; medium range. |
| **King Tower** | Structure | 4500 | 250 | Activated only after a Princess Tower falls. |
