using CustomDAO.DAOBaseObjects;
using CustomDAO.DAOImplementation;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;

namespace FileExtensions
{
    /// <summary>
    /// Class for generating XLS files
    /// </summary>
    public class GenerateXLS
    {
        /// <summary>
        /// Method for generating session result of one's group
        /// </summary>
        /// <param name="university">DBContext</param>
        /// <param name="sessionID">Session ID</param>
        /// <param name="filepath">Were to save</param>
        /// <param name="sort">Sort pattern</param>
        public void WriteSessionResultForAGroup(UniversityContext university, int sessionID, string filepath, string sort = "OrderBy")
        {
            InformationBuilding building = new InformationBuilding();
            Dictionary<string, float> group_ordered = building.GetSessionForAGroupInformation(university, sessionID, filepath, sort);

            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = workBook.ActiveSheet;
            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Group";
            workSheet.Cells[1, "C"] = "Average Mark";

            int i = 2;
            foreach (var group in group_ordered)
            {
                workSheet.Cells[i, "A"].Value = sessionID;
                workSheet.Cells[i, "B"].Value = group.Key;
                workSheet.Cells[i, "C"].Value = group.Value;
                i++;
            } 

            workBook.Close(true, filepath);
            excelApp.Quit();
        }

        /// <summary>
        /// Method for generating session result for all groups
        /// </summary>
        /// <param name="university">DBContext</param>
        /// <param name="filepath">Where to save</param>
        /// <param name="TypeOfOrder">Sortring type</param>
        public void WriteSessionsResults(UniversityContext university, string filepath, string TypeOfOrder = "OrderBy")
        {
            InformationBuilding building = new InformationBuilding();

            Dictionary<Session, Dictionary<string, List<float>>> results_ordered = building.GetSessionInformation(university, filepath, TypeOfOrder);

            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = workBook.ActiveSheet;
            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Group";
            workSheet.Cells[1, "C"] = "Max Mark";
            workSheet.Cells[1, "D"] = "Average mark";
            workSheet.Cells[1, "E"] = "Min Mark";
            int i = 2;
            foreach (var session_elem in results_ordered)
            {
                workSheet.Cells[i, "A"] = $"{session_elem.Key.StartDate.Date} - {session_elem.Key.EndDate.Date}";
                foreach (var group in session_elem.Value)
                {
                    workSheet.Cells[i, "B"] = group.Key;
                    workSheet.Cells[i, "C"] = group.Value[0];
                    workSheet.Cells[i, "D"] = group.Value[1];
                    workSheet.Cells[i, "E"] = group.Value[2];
                    i++;
                }
            }
            workBook.Close(true, filepath);
            excelApp.Quit();
        }

        /// <summary>
        /// Method for generating all D-students names from all of the groups
        /// </summary>
        /// <param name="university">DBContext</param>
        /// <param name="filepath">Where to save</param>
        /// <param name="TypeOfOrder">Sorting type</param>
        public void WriteAllDStudents(UniversityContext university, string filepath, string TypeOfOrder = "OrderBy")
        {
            InformationBuilding building = new InformationBuilding();
            Dictionary<string, List<string>> ordered_group = building.GetAllDStudents(university, filepath, TypeOfOrder);

            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = workBook.ActiveSheet;
            workSheet.Cells[1, "A"] = "Group";
            workSheet.Cells[1, "B"] = "Allocated students";
            int i = 2;
            foreach (var group in ordered_group)
            {
                workSheet.Cells[i, "A"] = $"{group.Key}";
                foreach (var student in group.Value)
                {
                    workSheet.Cells[i, "B"] = student;
                    i++;
                }
            }
            workBook.Close(true, filepath);
            excelApp.Quit();
        }
    }
}
