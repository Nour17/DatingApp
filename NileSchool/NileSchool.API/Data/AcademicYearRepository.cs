using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly DataContext _context;

        public AcademicYearRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AcademicYear> CreateAcadmicYear(AcademicYear academicYear)
        {
            await _context.AddAsync(academicYear);
            await _context.SaveChangesAsync();

            return academicYear;
        }

        public void AddBlocksNumber(int academicYearId, int blocksNumber)
        {
            AcademicYear academicYear = GetAcademicYear(academicYearId);
            
            academicYear.LastUpdated = DateTime.Now;
            academicYear.NumberOfBlocks = blocksNumber;
        }

        public void AddCoefficient(int academicYearId, int coefficient)
        {
            AcademicYear academicYear = GetAcademicYear(academicYearId);

            academicYear.LastUpdated = DateTime.Now;
            academicYear.Coefficient = coefficient;
        }

        public void EndAcademicYear(int academicYearId)
        {
            AcademicYear academicYear = GetAcademicYear(academicYearId);

            academicYear.LastUpdated = DateTime.Now;
            academicYear.isActive = false;
        }

        public async Task<AcademicYear> GetActiveYear()
        {
            var activeAcademicYear = await _context.AcademicYears.FirstOrDefaultAsync(x => x.isActive == true);
            return activeAcademicYear;
        }

        public async Task<bool> isYearActive(int id)
        {
            var academicYear = await _context.AcademicYears.FirstOrDefaultAsync(x => x.Id == id);

            if(academicYear.isActive == false)
                return false;

            return true;
        }

        public async Task<IEnumerable<AcademicYear>> GetAcademicYears()
        {
            var academicYears = await _context.AcademicYears.ToListAsync();

            return academicYears;
        }

        public AcademicYear GetAcademicYear(int id)
        {
            AcademicYear academicYear = _context.AcademicYears.FirstOrDefault(x => x.Id ==id);

            return academicYear;
        }
    }
}