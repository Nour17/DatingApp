using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NileSchool.API.Models;

namespace NileSchool.API.Data.Interfaces
{
    public interface IAcademicYearRepository
    {
        Task<AcademicYear> CreateAcadmicYear(AcademicYear academicYear);

        Task<AcademicYear> GetActiveYear(); 

        AcademicYear GetAcademicYear(int id); 

        Task<IEnumerable<AcademicYear>> GetAcademicYears();

        AcademicYear AddBlocksNumber(AcademicYear academicYear, int blocksNumber); 
 
        AcademicYear AddCoefficient(AcademicYear academicYear, int coefficient); 

        AcademicYear EndAcademicYear(AcademicYear academicYear);

        Task<bool> isYearActive(int id);
    }
}