using Microsoft.EntityFrameworkCore;
using webapi_project.Data;
using webapi_project.Models;
using webapi_project.Repository.IRepository;

namespace webapi_project.Repository
{
    public class trailrepo : Itrail
    {
        private readonly Applicationdbcontext _context;

        public trailrepo(Applicationdbcontext context)
        {
            _context = context;
        }

        public bool Createtrail(trail trail)
        {
            _context.trails.Add(trail);
            return Save();
        }

        public bool Deletetrail(trail trail)
        {
            _context.trails.Remove(trail);
            return Save();
        }

        public ICollection<trail> Getrails()
        {
            return _context.trails.ToList();
        }

        public trail GetTrail(int trailid)
        {
            return _context.trails.Find(trailid);
        }

        public ICollection<trail> GettrailInationalpark(int nationalparkid)
        {
            var traillist = _context.trails.Include(t=>t.NationalPark).Where(t=>t.NationalParkId == nationalparkid).ToList();
            return traillist;
        }

        public bool Save()
        {
            return _context.SaveChanges()==1?true:false;
        }

        public bool trailExist(int trailid)
        {
            return _context.trails.Any(t=>t.Id == trailid); 
        }

        public bool trailExists(string trailName)
        {
            return _context.trails.Any(t  => t.Name == trailName);
        }

        public bool Updatetrail(trail trail)
        {
            _context.trails.Update(trail);
            return Save();
        }
    }
}
