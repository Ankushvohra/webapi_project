using webapi_project.Data;
using webapi_project.Models;
using webapi_project.Repository.IRepository;

namespace webapi_project.Repository
{
    public class NationalParkRepository : InationalParkRepository
    {
        private readonly Applicationdbcontext  _context;

        public NationalParkRepository(Applicationdbcontext context)
        {
            _context = context;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int NationalParkId)
        {
            return _context.NationalParks.Find(NationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks.ToList();
        }

        public bool NationalParkExists(string NationalParkName)
        {
            return _context.NationalParks.Any(np => np.Name == NationalParkName);
        }

        public bool NationalParkExist(int NationalParkId)
        {
            return _context.NationalParks.Any(np=>np.Id==NationalParkId);
        }

        public bool Save()
        {
            return _context.SaveChanges() ==1 ? true:false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
