using webapi_project.Models;

namespace webapi_project.Repository.IRepository
{
    public interface InationalParkRepository
    {
        ICollection<NationalPark>GetNationalParks();

        NationalPark GetNationalPark(int NationalParkId);

        bool NationalParkExist(int NationalParkId);

        bool NationalParkExists(string NationalParkName);

        bool CreateNationalPark(NationalPark nationalPark);

        bool  UpdateNationalPark(NationalPark nationalPark);

        bool DeleteNationalPark(NationalPark nationalPark);

        bool Save();
    }
}
