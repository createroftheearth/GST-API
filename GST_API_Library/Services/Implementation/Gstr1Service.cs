
using GST_API_DAL.Repository.Interfaces;

namespace GST_API_Library.Services.Implementation
{
    public class Gstr1Service : IGstr1Service
    {
        private readonly IGSTR1Repository _gSTR1Repository;

        public Gstr1Service(IGSTR1Repository gSTR1Repository)
        {
                _gSTR1Repository = gSTR1Repository;
        }

        public bool saveGSTR1() 
        {
            // Save logic
            return true;
        }
    }
}
