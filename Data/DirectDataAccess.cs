using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Data
{
    public class DirectDataAccess
    {
        public static void Test(DataTable tbl)
        {
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand("Select * from Breeds where BreedId = @test"))
                {
                    DataHelper.AddInParameter(cmd, "test", DbType.Int64, 1);
                    DataHelper.FillTable(tbl,cmd);
                }
            }
        }

        public static void GetOwnersByJMBG(DataTable tbl, string jmbgParam)
        {
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand("SELECT * from Owners WHERE jmbg=@jmbg"))
                {
                    DataHelper.AddInParameter(cmd, "jmbg", DbType.String, jmbgParam);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetOwnersByFirstName(DataTable tbl, string fname)
        {
            fname += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand("SELECT * from Owners WHERE Owners.FirstName LIKE @name"))
                {
                    DataHelper.AddInParameter(cmd, "name", DbType.String, fname);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetOwnerAndAnimals_ByVaccination(DataTable tbl, string vacParam)
        {
            vacParam += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.RegistrationNumberOfProperty, Animals.RegistrationNumber, 
                                                             Owners.Address, Vaccinations.Date, Vaccinations.VaccinationFor FROM Animals
                                                             INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                             INNER JOIN Vaccinations ON Animals.AnimalId = Vaccinations.AnimalId
                                                             WHERE Vaccinations.VaccinationFor LIKE @vacParam"))
                {
                    DataHelper.AddInParameter(cmd, "@vacParam", DbType.String, vacParam);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetOwnerAndAnimals_ByVaccination(DataTable tbl, string vacParam, string animParam)
        {
            vacParam += "%";
            animParam = animParam.Trim();
            animParam += "%";

            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.RegistrationNumberOfProperty, Owners.Address, 
                                                             Animals.RegistrationNumber, Vaccinations.Date, Vaccinations.VaccinationFor FROM Animals
                                                             INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                             INNER JOIN Vaccinations ON Animals.AnimalId = Vaccinations.AnimalId
                                                             INNER JOIN Breeds ON Animals.BreedId = Animals.BreedId
                                                             WHERE Vaccinations.VaccinationFor LIKE @vacParam
                                                             AND Breeds.Name LIKE @animParam"))
                {
                    DataHelper.AddInParameter(cmd, "@vacParam", DbType.String, vacParam);
                    DataHelper.AddInParameter(cmd, "@animParam", DbType.String, animParam);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetTreatmansByTerapy(DataTable tbl, string text)
        {
            text += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT * from ClinicTreatments WHERE ClinicTreatments.Therapy LIKE @text"))
                {
                    DataHelper.AddInParameter(cmd, "@text", DbType.String, text);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetTreatmansByDiagnosis(DataTable tbl, string text)
        {
            text += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT * from ClinicTreatments WHERE ClinicTreatments.Diagnosis LIKE @text"))
                {
                    DataHelper.AddInParameter(cmd, "@text", DbType.String, text);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetAnimalsByName(DataTable tbl, string aName)
        {
            aName += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT * from Animals WHERE Animals.Name LIKE @aName"))
                {
                    DataHelper.AddInParameter(cmd, "@aName", DbType.String, aName);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetAnimalsByRegNumber(DataTable tbl, string regNumber)
        {
            regNumber += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT * from Animals WHERE Animals.RegistrationNumber LIKE @regNumber"))
                {
                    DataHelper.AddInParameter(cmd, "@regNumber", DbType.String, regNumber);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetOwnersByCreationDate(DataTable tbl, string date)
        {
            date += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT * from Owners WHERE Owners.DateOfEntry LIKE @date"))
                {
                    DataHelper.AddInParameter(cmd, "@date", DbType.String, date);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetAnimalsBySex(DataTable tbl, string gender)
        {
            gender += "%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT * from Animals WHERE Animals.Gender LIKE @gender"))
                {
                    DataHelper.AddInParameter(cmd, "@gender", DbType.String, gender);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetVaccinations(DataTable tbl)
        {
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.Address, Owners.RegistrationNumberOfProperty,
                                                             Animals.Name, Animals.EntryDate, Animals.Gender, Animals.RegistrationNumber, 
                                                             Vaccinations.Date, Vaccinations.VaccinationFor FROM Animals
                                                             INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                             INNER JOIN Vaccinations ON Animals.AnimalId = Vaccinations.AnimalId"))
                {
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetDiagnostics(DataTable tbl)
        {
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.Address, Owners.RegistrationNumberOfProperty,
                                                             Animals.Name, Animals.EntryDate, Animals.Gender, Animals.RegistrationNumber, 
                                                             Diagnostics.SamplingDate, Diagnostics.ExaminationIllness, Diagnostics.ExaminationDate, Diagnostics.BlodExamination, Diagnostics.MilkExamination,
                                                             Diagnostics.OtherExamination, Diagnostics.ExaminationResult FROM Animals
                                                             INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                             INNER JOIN Diagnostics ON Animals.AnimalId = Diagnostics.AnimalId  "))
                {
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetTuberkulinizaciju(DataTable tbl)
        {
            string text = "%tuber%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.RegistrationNumberOfProperty,
                                                               Animals.RegistrationNumber, Owners.Address, Diagnostics.SamplingDate, Diagnostics.ExaminationDate,
                                                               Diagnostics.ExaminationResult FROM Animals
                                                               INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                               INNER JOIN Diagnostics ON Animals.AnimalId = Diagnostics.AnimalId
                                                               WHERE Diagnostics.ExaminationIllness LIKE @text"))
                {
                    DataHelper.AddInParameter(cmd, "@text", DbType.String, text);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetBrucelozu(DataTable tbl)
        {
            string text = "%bruce%";
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Address, Animals.RegistrationNumber, Diagnostics.ExaminationDate,
                                                               Diagnostics.BlodExamination, Diagnostics.MilkExamination, Diagnostics.OtherExamination, Diagnostics.ExaminationResult 
                                                               FROM Animals
                                                               INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                               INNER JOIN Diagnostics ON Animals.AnimalId = Diagnostics.AnimalId
                                                               WHERE Diagnostics.ExaminationIllness LIKE @text"))
                {
                    DataHelper.AddInParameter(cmd, "@text", DbType.String, text);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetVakcinacija(DataTable tbl)
        {
            string text1 = "%antra%";
            string text2 = "%beder%";
            
            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.Address, Animals.RegistrationNumber, Vaccinations.Date, Vaccinations.Place
                                                               FROM Animals
                                                               INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                               INNER JOIN Diagnostics ON Animals.AnimalId = Diagnostics.AnimalId
                                                               INNER JOIN Vaccinations ON Animals.AnimalId = Vaccinations.AnimalId
                                                               WHERE Vaccinations.VaccinationFor LIKE @text1
                                                               OR Vaccinations.VaccinationFor LIKE @text2"))
                {
                    DataHelper.AddInParameter(cmd, "@text1", DbType.String, text1);
                    DataHelper.AddInParameter(cmd, "@text2", DbType.String, text2);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }

        public static void GetMilkCard(DataTable tbl)
        {
            string text1 = "%tuber%";
            //string text2 = "%beder%";

            using (DbConnection cn = DataHelper.GetConnection())
            {
                using (DbCommand cmd = DataHelper.GetCommand(@"SELECT Owners.FirstName, Owners.LastName, Owners.Jmbg, Owners.Address, Animals.RegistrationNumber, 
                                                               Diagnostics.ExaminationDate, Diagnostics.ExaminationIllness, Diagnostics.ExaminationResult
                                                               FROM Animals
                                                               INNER JOIN Owners ON Animals.OwnerId = Owners.OwnerId
                                                               INNER JOIN Diagnostics ON Animals.AnimalId = Diagnostics.AnimalId
                                                               WHERE Diagnostics.MilkExamination = 1 AND Diagnostics.ExaminationIllness LIKE @text1"))
                {
                    DataHelper.AddInParameter(cmd, "@text1", DbType.String, text1);
                    //DataHelper.AddInParameter(cmd, "@text2", DbType.String, text2);
                    DataHelper.FillTable(tbl, cmd);
                }
            }
        }
    }

}
