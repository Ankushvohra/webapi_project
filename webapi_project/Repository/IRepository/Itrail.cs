using webapi_project.Models;

namespace webapi_project.Repository.IRepository
{
    public interface Itrail
    {
        ICollection<trail> Getrails();

        ICollection<trail> GettrailInationalpark(int nationalparkid);

        trail GetTrail(int trailid);

        bool trailExist(int trailid);

        bool trailExists(string trailName);

        bool Createtrail(trail trail);

        bool Updatetrail(trail trail);

        bool Deletetrail(trail trail);

        bool Save();
    }
}
