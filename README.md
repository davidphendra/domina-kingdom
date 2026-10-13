# 🐉 Domina Kingdom — Elazul Battalion Builder

> A .NET console application that distributes a roster of warriors across **dragons** (battalions). Each dragon has a fixed number of **seats**. The builder loads every warrior while keeping each dragon as balanced as possible.

---

## 🚀 New here? Start in 60 seconds

1. **Install** the [.NET SDK 10.0](https://dotnet.microsoft.com/download) or later.
2. **Clone** the repository and open the folder.
3. **Run** the app:

   ```bash
   dotnet run --project TestA/TestA.csproj
   ```

4. **Enter** four numbers when prompted — Swordmen, Archers, Mages, Healers.
5. **Read** the result: one line per dragon showing its seated warriors.

That is the entire workflow. Everything below explains *why* the result looks the way it does.

---

## 🗺️ What this project does

You provide a count of each warrior class. The application seats those warriors onto dragons of five seats each.

- 🎯 **Goal** — seat every warrior, exactly once.
- ⚖️ **Balance** — give each dragon at least one of every class whenever the roster allows it.
- 🔢 **Priority** — when a fifth seat remains, fill it by a fixed class priority.

---

## 📖 Domain glossary

Read this once and the code will make sense.

| Icon | Term | Meaning |
|:---:|---|---|
| ⚔️ | **Warrior class** | One of four types: `Swordmen`, `Archer`, `Mage`, `Healer` (the `WarriorClass` enum) |
| 📋 | **Roster** | The requested counts per class (`UserInput`) |
| 🐉 | **Dragon** | A battalion with an `Id`, its `Passengers`, and per-class totals (`Dragon`) |
| 💺 | **Seat** | A single slot on a dragon. Capacity is **5 seats** (`DragonSeatIdealSetup.TotalSeat`) |
| 🧩 | **Ideal setup** | The layout each dragon aims for: **1 of every class** (`DragonSeatIdealSetup`) |
| 🏗️ | **Batch builder** | The service that turns a roster into dragons (`ElazulBatallionService`) |

**Priority order** (`DragonSeatIdealSetup.Priorities`):

```
⚔️ Swordmen  →  🏹 Archer  →  🔮 Mage  →  ✨ Healer
```

---

## 🧠 How the algorithm works

`ElazulBatallionService.Build(roster)` creates dragons one at a time. For each dragon it seats warriors in **three passes**:

1. 🧩 **Ideal setup pass** — add one warrior of each class that still has unseated members. This builds the balanced "one of each" core (up to 4 seats).
2. 🎯 **Priority pass** — if a seat remains, walk the priority order and add the first class that still has unseated members. This fills the 5th seat.
3. ♻️ **Remaining pass** — keep filling leftover seats by priority while unseated warriors remain. This handles oversized classes, such as a roster that is mostly Healers.

A new dragon is created for as long as any warrior remains unseated. The current dragon is added to the result *before* passes 2 and 3, so extra seats attach to the same dragon instance.

**Guarantees** (each is asserted by the test suite):

- ✅ Every warrior is seated exactly once — per-class totals across dragons equal the input.
- ✅ No dragon exceeds 5 seats.
- ✅ Dragons are filled in order; earlier dragons are the most balanced, and each 5th seat follows priority.

---

## 🖥️ Sample run

Input of **10 Swordmen, 6 Archers, 3 Mages, 5 Healers**:

```
Input Total Swordmen: 10
Input Total Archer: 6
Input Total Mage: 3
Input Total Healer: 5
Dragon 1: 2 swordsmen, 1 archers, 1 mages, 1 healers
Dragon 2: 2 swordsmen, 1 archers, 1 mages, 1 healers
Dragon 3: 2 swordsmen, 1 archers, 1 mages, 1 healers
Dragon 4: 2 swordsmen, 2 archers, 0 mages, 1 healers
Dragon 5: 2 swordsmen, 1 archers, 0 mages, 1 healers
```

**Sanity check** — 10 Swordmen, 6 Archers, 3 Mages, and 5 Healers add up to 24 warriors, all seated across 5 dragons.

---

## 📂 Project structure

```
domina-kingdom/
├── TestA.sln                          🧭 Solution file (start here)
├── TestA/                             🖥️ Console app (namespace TestA.Elazul.*)
│   ├── Program.cs                     Prompt loop + entry point
│   ├── Domains/
│   │   ├── WarriorClass.cs            Enum of warrior classes
│   │   ├── UserInput.cs               Requested counts
│   │   ├── Dragon.cs                  Battalion + per-class totals
│   │   └── DragonSeatIdealSetup.cs    Seat capacity & priority order
│   ├── Extensions/
│   │   └── WarriorCollectionExtensions.cs   TotalWarrior(...) helper
│   └── Services/
│       ├── IElazulBatallionService.cs
│       └── ElazulBatallionService.cs   The seating algorithm  ⭐ main logic
└── TestA_UnitTest/                    🧪 NUnit test project
    ├── ElazulBuilderService_UnitTest.cs
    └── TestA_UnitTest.csproj
```

⭐ **Reading order for new contributors:** `DragonSeatIdealSetup` → `WarriorClass` → `Dragon` → `ElazulBatallionService` → `Program.cs`.

---

## ✅ Prerequisites

- 🟣 [.NET SDK 10.0](https://dotnet.microsoft.com/download) or later (targets `net10.0`)
- 🧪 Test stack: NUnit 4, `Microsoft.NET.Test.Sdk`, `coverlet.collector`

---

## 🛠️ Build, run, and test

```bash
# 🔨 Build the solution
dotnet build TestA.sln

# ▶️ Run the console app
dotnet run --project TestA/TestA.csproj

# 🧪 Run the test suite
dotnet test TestA.sln
```

> 💡 The app prompts for four numbers. Non-numeric input is treated as `0` for that class.

---

## 🧪 Test suite

`TestA_UnitTest/ElazulBuilderService_UnitTest.cs` contains 6 scenarios. In the table, input is given as `s / a / m / h` (one count per class), and `D1`, `D2`, … show each dragon's seating.

| Test | Input (s / a / m / h) | Dragons |
|---|---|---|
| `Given_1s_1a_1m_1h_ReturnTrue` | 1 / 1 / 1 / 1 | 1 dragon → D1: 1/1/1/1 |
| `Given_1s_1a_1m_5h_ReturnTrue` | 1 / 1 / 1 / 5 | 2 dragons → D1: 1/1/1/2, D2: 0/0/0/3 |
| `Given_1s_1a_5m_1h_ReturnTrue` | 1 / 1 / 5 / 1 | 2 dragons → D1: 1/1/2/1, D2: 0/0/3/0 |
| `Given_1s_5a_1m_1h_ReturnTrue` | 1 / 5 / 1 / 1 | 2 dragons → D1: 1/2/1/1, D2: 0/3/0/0 |
| `Given_1s_3a_3m_1h_ReturnTrue` | 1 / 3 / 3 / 1 | 2 dragons → D1: 1/2/1/1, D2: 0/1/2/0 |
| `Given_10s_6a_3m_5h_ReturnTrue` | 10 / 6 / 3 / 5 | 5 dragons (see sample run) |

**Status:** ✅ 6 passed · 0 failed

---

## ⚠️ Known issues

These do not affect current behavior, but fix them before relying on the affected code.

- 🐞 **Copy-paste bugs in `UserInput`**
  - `HasUnseatedMage` and `HasUnseatedHealer` both test `TotalArcher > 0`.
  - `HasUnseatedWarrior` combines `HasUnseatedArcher` twice and omits `HasUnseatedSwordmen`.
  - These properties are currently **unused** by the service, so the seating result is unaffected.
- 🧹 **Redundant null checks** — `Dragon.Passengers` is initialized and never null, so the `?.` / `?? 0` guards in `Dragon` and `WarriorCollectionExtensions` are unnecessary.
- 🏷️ **Naming drift** — the test class is `ElazulBuilderService_UnitTests` (file `ElazulBuilderService_UnitTest.cs`), while the service is `ElazulBatallionService`. Note "Batallion" is spelled with one `t` in code.
- 🔁 **Reversed assert arguments** — several tests pass the constant as the *actual* value (`Assert.That(2, Is.EqualTo(actual...))`), triggering NUnit2007. They pass, but the arguments are swapped.
- 🐢 **Performance** — the builder recomputes `SelectMany(...).Count()` repeatedly inside its loop. Fine for small rosters; a per-class seating tally would scale better.

---

## 📄 License

No license file is present in this repository.
