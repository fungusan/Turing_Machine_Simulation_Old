# Turing Machine Logic

## Overview
This is a super rough implementation on the logic of Turing machine. Features like
multiple tapes, heads,  rich conditional controls, and signals are not designed nor implemented.

It is upon demanded from groupmates, I have a need to give an overview of integrating possibility,
design document, and seeking for feedbacks.

As the logic is still undergoing the design phrase, without confirming the requirements of frontend side,
This logic will be implemented first in C#. After a full demonstrations, the logic will be transplanted to TypeScript.
The input I planned for demonstration, will be simply a text file, and a `InputManager.cs` will take over this.

You can simulate my predefined simulations on one tape, one head, and a super simple algorithm. Please note, it does not currently support features
beyond that, so don't try to define your own simulation at this moment. 

I'm also sorry to say, I don't have any inline comments for now, but I promise it will be the actual demonstration.

## Structure
The directory you need to focus on is `/TuringMachineLib`.

### `Program.cs`
This is the main class of the system, where you initialize simulator and input test cases
for machine simulator. It itself doesn't contain anything about the system, but merely an entry point of the
system.

### `/Head`
This is the directory for interface of Head (namely, the abstract outline of what Heads should do and store). There are now
three files implementing this interface, each having their own features. For example, `ReadWriteHead.cs` will support
both tryWrite() and read operations.

Heads will store reference to the cell of the tape, the tape it is pointing to, and handle the tryWrite() and read operations, where simulators can call.

### `/Tape`
This is the directory for interface of Tape.

Tapes will implement a data structure for different variants of tapes (e.g. infinite tape and circular tape).
It will also schedule the write operations, storing in a queue, and commit the operations at the end of one tick (i.e. time sync unit).
The reason of doing is that we need to check any invalid operations before actually update the tape contents.

Tapes are generally implemented by doubly-linked lists.

### Simulations

`TuringMachine.cs` encapsulates all data we need for a Turing machine, without having any actual simulation methods.

`TuringMachineFactory.cs` handles the initialization of the Turing machine and return an TuringMachine object,

`SimulationManager.cs` will first call `TuringMachineFactory.cs` to create a new TuringMachine object. Then it will start simulating the machine
by synchronising the operations with real time 1 second. In each process, it first schedules the potentially harmful operations, and then perform the actual
updating after no violations are found.
