using ECS.TuringMachineLib;
using ECS.TuringMachineLib.Tape;
using ECS.TuringMachineLib.Head;

class Program
{
    static void Main(string[] args)
    {
        // Create and start the simulation
        // Manually input so just for debugging and demo
        int numOfStates = 2; // State 0 (start) and state 1 (accepted)
        int[] finalStates = [1]; // State 1 is the accepting state
        int numOfTapes = 1; // Single tape
        int numOfHeads = 1; // Single head
        int[] tapeMode = [0]; // Assume mode 0 for simplicity (normal tape behavior)
        int[] headMode = [0]; // Assume mode 0 for simplicity (normal head behavior)

        // Transitions
        // Accepted if the input string contains 'a'
        // The machine replaces 'b' with 'c', and vise versa
        Transition[] transitions =
        {
            // State 0 transitions
            new Transition(0, 1, new char[] { 'a' }, new char[] { 'a' },
                new bool[] { true }), // Read 'a', stay in state 1 (accepted)
            
            new Transition(0, 0, new char[] { 'b' }, new char[] { 'c' },
                new bool[] { true }), // Read 'b', stay in state 0
            
            new Transition(1, 1, new char[] { 'b' }, new char[] { 'c' },
                new bool[] { true }),
            
            new Transition(0, 0, new char[] { 'c' }, new char[] { 'b' },
                new bool[] { true }), // Read 'c', stay in state 0
            
            new Transition(1, 1, new char[] { 'c' }, new char[] { 'b' },
                new bool[] { true }),
            
            new Transition(0, 0, new char[] { '_' }, new char[] { '_' },
                new bool[] { true }), // Read blank symbol '_', stay in state 0
        };
        
        SimulationManager.Initialize(numOfStates, finalStates, numOfHeads, numOfTapes, tapeMode, headMode, transitions);
        
        SimulationManager.StartSimulation("abbbc");

        // Let the simulation run for a while
        Console.ReadLine();
        SimulationManager.StopSimulation();
    }
}