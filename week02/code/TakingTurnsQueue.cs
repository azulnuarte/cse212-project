public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// If the person has turns left, decrement and re-enqueue them.
    /// If they have infinite turns (0 or less), re-enqueue them without modifying Turns.
    /// If no turns left, they are not re-enqueued.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns → put back without modifying Turns
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Finite turns left → decrement and put back
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If Turns == 1 → do not re-enqueue (they are done)

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
