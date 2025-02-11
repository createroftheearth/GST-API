using GST_API_DAL.Repository.Interfaces;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_DAL.Models;

namespace GST_API_Library.Services.Implementation
{
    public class Gstr1Service : IGstr1Service
    {
        private readonly IGSTR1Repository _gSTR1Repository;

        public Gstr1Service(IGSTR1Repository gSTR1Repository)
        {
            _gSTR1Repository = gSTR1Repository;
        }

        public async Task<(bool IsSuccess, string Message)> SaveGSTR1Async(Gstr1Dto gstr1SaveDto)
        {
            // Check if an entry with the same GSTINNo and FinancialPeriod exists
            var existingEntry = await _gSTR1Repository.FindAsync(
                x => x.GSTINNo == gstr1SaveDto.GSTINNo &&
                     x.FinancialPeriod.Year == gstr1SaveDto.FinancialPeriod.Year && x.FinancialPeriod.Month == gstr1SaveDto.FinancialPeriod.Month);

            if (existingEntry != null)
            {
                return (false, "An entry with the same GSTIN and Financial Period already exists.");
            }

            // Map Gstr1Dto to Gstr1 entity
            var newGstr1 = new Gstr1
            {
                GSTINNo = gstr1SaveDto.GSTINNo,
                FinancialPeriod = gstr1SaveDto.FinancialPeriod,
                Gstr1SaveRequest = gstr1SaveDto.RequestBody,
                SaveGstr1Status = 1 // Set initial status
            };

            // Add the new entry to the database
            await _gSTR1Repository.AddAsyn(newGstr1);
            return (true, "GSTR1 entry saved successfully.");
        }

    }
}
