using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    static class Database
    {

        public static List<Faculty> faculties = new List<Faculty>();
        public static List<Group> groups = new List<Group>();
        public static List<Person> persons = new List<Person>();
        public static List<RelativeOfStudent> relativeOfStudents = new List<RelativeOfStudent>();
        public static List<TypeOfRelative> typeOfRelatives = new List<TypeOfRelative>();
        public static List<Student> students = new List<Student>();
        public static List<Benefit> benefits = new List<Benefit>();

        public static DataTable MSysObjectsData = new DataTable();

        public static IdStruct idStruct;

        static OleDbConnection cn = new OleDbConnection(
        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=E:\Лабы\БД\Лаб3.accdb;" +
        @"Jet OLEDB:Create System Database=true;" +
        @"Jet OLEDB:System database=C:\Users\gusar\AppData\Roaming\Microsoft\Access\System.mdw"
        );
        /// <summary>
        /// Получить список факультета
        /// </summary>
        public static void GetFaculties()
        {
            faculties.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Факультет";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        faculties.Add(new Faculty(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3)));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получить список родственников
        /// </summary>
        public static void GetRelativeOfStudent()
        {
            relativeOfStudents.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM [Родственник студента]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        relativeOfStudents.Add(new RelativeOfStudent(rd.GetInt32(0), rd.GetInt32(1), rd.GetInt32(2), rd.GetInt32(3)));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получить список видов рродвенников
        /// </summary>
        public static void GetTypeOfRelative()
        {
            typeOfRelatives.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM [Вид родственников]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        typeOfRelatives.Add(new TypeOfRelative(rd.GetInt32(0), rd.GetString(1)));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получить список персон
        /// </summary>
        public static void GetPersons()
        {
            persons.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Персона";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        persons.Add(new Person(rd.GetInt32(0), !rd.IsDBNull(1) ? rd.GetString(1) : "",
                            rd.GetString(2), !rd.IsDBNull(3) ? rd.GetString(3) : "",
                            rd.GetValue(4).ToString().Substring(0, 10), rd.GetString(5), !rd.IsDBNull(6) ? rd.GetString(6) : ""));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получить список групп
        /// </summary>
        public static void GetGroups()
        {
            groups.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Группа";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        groups.Add(new Group(rd.GetString(0), rd.GetInt32(1), rd.GetInt32(2)));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получить список студентов
        /// </summary>
        public static void GetStudents()
        {
            students.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Студент";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        students.Add(new Student(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2)));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получить список льгот
        /// </summary>
        public static void GetBenefits()
        {
            benefits.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Льгота";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        benefits.Add(new Benefit(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetString(3), rd.GetValue(4).ToString().Substring(0, 10)));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Получение сткуртуры с max id для любой таблицы
        /// </summary>
        /// <param name="type">Тип таблицы</param>
        public static void GetIdStruct(string type)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader rd;
                cmd.Connection = cn;
                switch (type)
                {
                    case "all":
                    cmd.CommandText = @"SELECT Max(Персона.[Индентификатор персоны]), Max([Родственник студента].[Идентификатор родственника]), Max([Вид родственников].[Идентификатор вида]), Max(Студент.[Номер студенческого билета]), Max(Льгота.[Идентификатор льготы]), Max(Группа.[Номер группы]), Max(Факультет.[Идентификатор факультета])
                                        FROM Персона, [Родственник студента], [Вид родственников], Студент, Льгота, Группа, Факультет;
                                            ";
                    rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            idStruct = new IdStruct(rd.GetInt32(0), rd.GetInt32(1), rd.GetInt32(2), rd.GetInt32(3), rd.GetInt32(4), rd.GetString(5), rd.GetInt32(6));
                        }
                    }
                        break;

                    case "Person":
                        cmd.CommandText = @"SELECT Max(Персона.[Индентификатор персоны])
                                        FROM Персона;
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.PersonId = rd.GetInt32(0);
                            }
                        }
                        break;
                    case "Group":
                        cmd.CommandText = @"SELECT Max(Группа.[Номер группы])
                                        FROM Группа;
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.GroupNumber = rd.GetString(0);
                            }
                        }
                        break;
                    case "Student":
                        cmd.CommandText = @"SELECT Max(Студент.[Номер студенческого билета])
                                        FROM Студент;
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.StudentNum = rd.GetInt32(0);
                            }
                        }
                        break;
                    case "Relative of student":
                        cmd.CommandText = @"SELECT Max([Родственник студента].[Идентификатор родственника])
                                        FROM [Родственник студента];
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.RelativeOfStudentId = rd.GetInt32(0);
                            }
                        }
                        break;
                    case "Type of relative":
                        cmd.CommandText = @"SELECT  Max([Вид родственников].[Идентификатор вида])
                                        FROM [Вид родственников];
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.TypeOfRelativeId = rd.GetInt32(0);
                            }
                        }
                        break;
                    case "Benefit":
                        cmd.CommandText = @"SELECT Max(Льгота.[Идентификатор льготы])
                                        FROM Льгота;
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.BenefitId = rd.GetInt32(0);
                            }
                        }
                        break;
                    case "Faculty":
                        cmd.CommandText = @"SELECT Max(Факультет.[Идентификатор факультета])
                                        FROM Факультет;
                                            ";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                idStruct.FacultyId = rd.GetInt32(0);
                            }
                        }
                        break;
                }
            }
            
            finally
            {
                cn.Close();
            }
        }

        public static void GetAll()
        {
            GetBenefits();
            GetFaculties();
            GetGroups();
            GetPersons();
            GetRelativeOfStudent();
            GetStudents();
            GetTypeOfRelative();
        }
        /// <summary>
        /// Добавление факультета
        /// </summary>
        /// <param name="faculty"> Объект типа Faculty</param>
        public static void AddFacultyToDB(Faculty faculty)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Факультет VALUES (@ID, @Name, @Dean, @Deanery)";
                cmd.Parameters.AddWithValue("@ID", faculty.Id);
                cmd.Parameters.AddWithValue("@Name", faculty.NameOfFaculty);
                cmd.Parameters.AddWithValue("@Dean", faculty.Dean);
                cmd.Parameters.AddWithValue("@Deanery", faculty.Deanery);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Добавление персоны
        /// </summary>
        /// <param name="person">Объект типа Person</param>
        public static void AddPersonToDB(Person person)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Персона VALUES (@ID, @Surname, @Name, @Patronymic, @DateOfBirth, @Gender, @Address)";
                cmd.Parameters.AddWithValue("@ID", person.Id);
                cmd.Parameters.AddWithValue("@Surname", person.Surname);
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Patronymic", person.Patronymic);
                cmd.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", person.Gender);
                cmd.Parameters.AddWithValue("@Address", person.Address);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Добавление льготы
        /// </summary>
        /// <param name="benefit">Объект типа Benefit</param>
        public static void AddBenefitToDB(Benefit benefit)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Льгота VALUES (@Id, @NumberStudentCard, @Type, @Basis, @DateOfIssue)";
                cmd.Parameters.AddWithValue("@Id", benefit.Id);
                cmd.Parameters.AddWithValue("@NumberStudentCard", benefit.NumberOfStudentCard);
                cmd.Parameters.AddWithValue("@Type", benefit.TypeOfBenefit);
                cmd.Parameters.AddWithValue("@Basis", benefit.Basis);
                cmd.Parameters.AddWithValue("@DateOfIssue", benefit.DateOfIssue);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Добавление группы
        /// </summary>
        /// <param name="group"> Объект типа Group</param>
        public static void AddGroupToDB(Group group)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Группа VALUES (@GroupNumber, @FacultyId, @StudentsNumber)";
                cmd.Parameters.AddWithValue("@GroupNumber", group.NumberOfGroup);
                cmd.Parameters.AddWithValue("@FacultyId", group.IdFaculty);
                cmd.Parameters.AddWithValue("@StudentsNumber", group.NumberOfStudents);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="student"> Обьект типа Student </param>
        public static void AddStudentToDB(Student student)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Студент VALUES (@NumberStudentCard, @PersonId, @GroupNumber)";
                cmd.Parameters.AddWithValue("@NumberStudentCard", student.NumberOfStudentCard);
                cmd.Parameters.AddWithValue("@PersonId", student.IdPerson);
                cmd.Parameters.AddWithValue("@GroupNumber", student.NumberOfGroup);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Добавление Родственника студента
        /// </summary>
        /// <param name="relativeOfStudent"> Объект типа relativeOfStudent </param>
        public static void AddRelativeOfStudentToDB(RelativeOfStudent relativeOfStudent)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO [Родственник студента] VALUES (@Id, @PersonId, @NumberStudentCard, @TypeId)";
                cmd.Parameters.AddWithValue("@Id", relativeOfStudent.Id);
                cmd.Parameters.AddWithValue("@PersonId", relativeOfStudent.IdPerson);
                cmd.Parameters.AddWithValue("@NumberStudentCard", relativeOfStudent.NumberOfStudentCard);
                cmd.Parameters.AddWithValue("@TypeId", relativeOfStudent.IdRelativeType);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Добавление Вида родственника
        /// </summary>
        /// <param name="typeOfRelative"> Объект типа typeOfRelative </param>
        public static void AddTypeOfRelativeToDB(TypeOfRelative typeOfRelative)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO [Вид родственников] VALUES (@Id, @Name)";
                cmd.Parameters.AddWithValue("@Id", typeOfRelative.Id);
                cmd.Parameters.AddWithValue("@Name", typeOfRelative.NameOfType);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Удаление из любой таблицы по ID кроме Группы
        /// </summary>
        /// <param name="ID"> ID который надо удалить </param>
        /// <param name="type"> type - строка для выбора таблицы</param>
        public static void DeleteFromTableByID(int ID, string type)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;

                switch (type)
                {
                    case "Студент":
                        cmd.CommandText = "DELETE FROM Студент WHERE [Номер студенческого билета] = @id";
                        break;
                    case "Персона":
                        cmd.CommandText = "DELETE FROM Персона WHERE [Индентификатор персоны] =  @id";
                        break;
                    case "Факультет":
                        cmd.CommandText = "DELETE FROM Факультет WHERE [Идентификатор факультета] =  @id";
                        break;
                    case "Родственник студента":
                        cmd.CommandText = "DELETE FROM [Родственник студента] WHERE Идентификатор родственника] = @id";
                        break;
                    case "Вид родственников":
                        cmd.CommandText = "DELETE FROM [Вид родственников] WHERE [Идентификатор вида] =  @id";
                        break;
                    case "Льгота":
                        cmd.CommandText = "DELETE FROM Льгота WHERE [Идентификатор льготы] =  @id";
                        break;
                }
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Удаление из таблицы Группы по Номеру группы 
        /// </summary>
        /// <param name="groupNum"> Номер группы который хотим удалить</param>
        public static void DeleteFromTableByID(string groupNum)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Группа WHERE [Номер группы] =  @id";
                cmd.Parameters.AddWithValue("@id", groupNum);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Обновление факультета
        /// </summary>
        /// <param name="faculty"> Объект типа Faculty </param>
        public static void UpdateFacultyInDB(Faculty faculty)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE Факультет SET 
                                       [Название факультета] = @Name, 
                                       [Декан] = @Dean, 
                                       [Деканат] = @Deanery
                                       WHERE [Идентификатор факультета] = @ID";
               
                cmd.Parameters.AddWithValue("@Name", faculty.NameOfFaculty);
                cmd.Parameters.AddWithValue("@Dean", faculty.Dean);
                cmd.Parameters.AddWithValue("@Deanery", faculty.Deanery);
                cmd.Parameters.AddWithValue("@ID", faculty.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Обновление персоны
        /// </summary>
        /// <param name="person"> Объект типа Person</param>
        public static void UpdatePersonInDB(Person person)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE Персона SET 
                                     [Фамилия] = @Surname, 
                                     [Имя] = @Name, 
                                     [Отчество] = @Patronymic,
                                     [Дата рождения] = @DateOfBirth, 
                                     [Пол] = @Gender,
                                     [Адрес] = @Address
                WHERE [Индентификатор персоны] = @ID";

                cmd.Parameters.AddWithValue("@Surname", person.Surname);
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Patronymic", person.Patronymic);
                cmd.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", person.Gender);
                cmd.Parameters.AddWithValue("@Address", person.Address);
                cmd.Parameters.AddWithValue("@ID", person.Id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Обновление льготы
        /// </summary>
        /// <param name="benefit"> Объект типа Benefit </param>
        public static void UpdateBenefitInDB(Benefit benefit)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE Льгота SET    [Номер студенческого билета] = @NumberStudentCard,
                                       [Вид льготы] = @Type, 
                                       [Основание] = @Basis, 
                                       [Дата выдачи] = @DateOfIssue
                WHERE [Идентификатор льготы] = @Id";
                cmd.Parameters.AddWithValue("@NumberStudentCard", benefit.NumberOfStudentCard);
                cmd.Parameters.AddWithValue("@Type", benefit.TypeOfBenefit);
                cmd.Parameters.AddWithValue("@Basis", benefit.Basis);
                cmd.Parameters.AddWithValue("@DateOfIssue", benefit.DateOfIssue);
                cmd.Parameters.AddWithValue("@Id", benefit.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                String ex = e.Message;
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Обновление группы
        /// </summary>
        /// <param name="group"> Объект типа Group</param>
        public static void UpdateGroupInDB(Group group)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE Группа SET    
                                       [Идентификатор факультета] = @FacultyId, 
                                       [Количество студентов] = @StudentsNumber
                WHERE [Номер группы] = @GroupNumber";
               
                cmd.Parameters.AddWithValue("@FacultyId", group.IdFaculty);
                cmd.Parameters.AddWithValue("@StudentsNumber", group.NumberOfStudents);
                cmd.Parameters.AddWithValue("@GroupNumber", group.NumberOfGroup);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        ///  Обновление студента  
        /// </summary>
        /// <param name="student"> Объект типа Student </param>
        public static void UpdateStudentInDB(Student student)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE Студент SET   
                                       [Идентификатор персоны] = @PersonId, 
                                       [Номер группы] = @GroupNumber
                WHERE [Номер студенческого билета] = @NumberStudentCard";
                
                cmd.Parameters.AddWithValue("@PersonId", student.IdPerson);
                cmd.Parameters.AddWithValue("@GroupNumber", student.NumberOfGroup);
                cmd.Parameters.AddWithValue("@NumberStudentCard", student.NumberOfStudentCard);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Обновление родственника студента
        /// </summary>
        /// <param name="relativeOfStudent"> Объект типа RelativeOfStudent </param>
        public static void UpdateRelativeOfStudentInDB(RelativeOfStudent relativeOfStudent)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE [Родственник студента]
                                   SET 
                                       [Идентификатор персоны] = @PersonId, 
                                       [Номер студенческого билета] = @NumberStudentCard, 
                                       [Идентификатор вида] = @TypeId
                WHERE [Идентификатор родственника] = @Id";
                
                cmd.Parameters.AddWithValue("@PersonId", relativeOfStudent.IdPerson);
                cmd.Parameters.AddWithValue("@NumberStudentCard", relativeOfStudent.NumberOfStudentCard);
                cmd.Parameters.AddWithValue("@TypeId", relativeOfStudent.IdRelativeType);
                cmd.Parameters.AddWithValue("@Id", relativeOfStudent.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Обновление вида родственника
        /// </summary>
        /// <param name="typeOfRelative"> Объект типа TypeOfRelative </param>
        public static void UpdateTypeOfRelativeInDB(TypeOfRelative typeOfRelative)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                @"UPDATE [Вид родственников] 
                                 SET   
                                       [Название вида] = @Name
                WHERE [Идентификатор вида] = @Id";
                
                cmd.Parameters.AddWithValue("@Name", typeOfRelative.NameOfType);
                cmd.Parameters.AddWithValue("@Id", typeOfRelative.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос на получение MSysObjects
        /// </summary>
        /// <returns></returns>
        public static DataTable MSysObjectsRequest()
        {

            MSysObjectsData.Clear();
            MSysObjectsData = new DataTable();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM MSysObjects";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    for (int i = 0; i < rd.FieldCount; i++)
                    {
                        MSysObjectsData.Columns.Add(new DataColumn(rd.GetName(i)));
                    }
                    while (rd.Read())
                    {
                        string[] temp = new string[rd.FieldCount];
                        for (int i = 0; i < rd.FieldCount; i++)
                        {
                            temp[i] = rd.GetValue(i).ToString();
                        }
                        MSysObjectsData.LoadDataRow(temp, false);
                    }
                }
                return MSysObjectsData;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос 1
        /// </summary>
        public static void Request1()
        {
            groups.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select * FROM [Все группы с количеством студентов больше 20]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        groups.Add(new Group(rd.GetString(0), rd.GetInt32(1), rd.GetInt32(2)));
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                cn.Close();
            }

        }
        /// <summary>
        /// Запрос 2
        /// </summary>
        public static void Request2()
        {
            students.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select * FROM [Все студенты из М-11]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        students.Add(new Student(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2)));
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                cn.Close();
            }

        }
        /// <summary>
        /// Запрос 3
        /// </summary>
        public static void Request3()
        {
            groups.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select * FROM [Все группы по количеству студентов по убыванию]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        groups.Add(new Group(rd.GetString(0), rd.GetInt32(1), rd.GetInt32(2)));
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                cn.Close();
            }

        }
        /// <summary>
        /// Запрос 4
        /// </summary>
        public static void Request4(string numGroup)
        {
            students.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("Введите номер группы", numGroup);
                cmd.CommandText = "SELECT * FROM [Все студенты конкретной группы2]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        students.Add(new Student(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2)));
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос 5
        /// </summary>
        public static void Request5(string facName)
        {
            groups.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("Введите название факультета", facName);
                cmd.CommandText = "SELECT * FROM [Все группы на факультете]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        groups.Add(new Group(rd.GetString(0), rd.GetInt32(1), rd.GetInt32(2)));
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос 6
        /// </summary>
        public static void Request6(string facName)
        {
            persons.Clear();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("Введите Имя", facName);
                cmd.CommandText = "SELECT * FROM [Все персоны по имени]";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        persons.Add(new Person(rd.GetInt32(0), !rd.IsDBNull(1) ? rd.GetString(1) : "",
                            rd.GetString(2), !rd.IsDBNull(3) ? rd.GetString(3) : "",
                            rd.GetValue(4).ToString().Substring(0, 10), rd.GetString(5), !rd.IsDBNull(6) ? rd.GetString(6) : ""));
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос 7
        /// </summary>
        public static void Request7()
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "EXEC [Добавление персоны]";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос 8
        /// </summary>
        public static void Request8()
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "EXEC [Удалить студентов группы М-12]";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Запрос 9
        /// </summary>
        public static void Request9()
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "EXEC [Понизить вместимость групп]";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
