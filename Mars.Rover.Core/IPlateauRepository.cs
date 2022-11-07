using Mars.Rover.Core.Plateau;

namespace Mars.Rover.Core;

public interface IPlateauRepository
{
    int Save(PlateauInstance plateau);

    PlateauInstance? Get(int id);

    IEnumerable<PlateauInstance> GetAll();

    void Delete(int id);

    void Update(int id, PlateauInstance plateau);
}