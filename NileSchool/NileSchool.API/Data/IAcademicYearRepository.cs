using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public interface IAcademicYearRepository
    {
        Task<AcademicYear> CreateAcadmicYear(AcademicYear academicYear);

        Task<AcademicYear> GetActiveYear(); 

        AcademicYear GetAcademicYear(int id); 

        Task<IEnumerable<AcademicYear>> GetAcademicYears();

        void AddBlocksNumber(int academicYearId, int blocksNumber); 
 
        void AddCoefficient(int academicYearId, int blocksNumber); 

        void EndAcademicYear(int academicYearId);

        Task<bool> isYearActive(int id);
    }
}