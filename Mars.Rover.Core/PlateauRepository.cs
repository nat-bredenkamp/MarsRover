using Mars.Rover.Core.Plateau;

namespace Mars.Rover.Core;

public class PlateauRepository : IPlateauRepository
{
    private static readonly Dictionary<int, PlateauInstance> Plateaus = new ();
    private int _id = 1;    
    
    public int Save(PlateauInstance plateau)
    {
        plateau.Id = _id;
        Plateaus.Add(_id, plateau);
        return _id++;
    }

    public PlateauInstance? Get(int id)
    {
        return Plateaus.TryGetValue(id, out var plateauInstance) ? plateauInstance : null;
    }

    public IEnumerable<PlateauInstance> GetAll()
    {
        return Plateaus.Values;
    }

    public void Delete(int id)
    {
        Plateaus.Remove(id);
    }

    public void Update(int id, PlateauInstance plateau)
    {
        if (Plateaus.ContainsKey(id))
        {
            Plateaus[id] = plateau;
        }
    }
}