using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Lokiproject4.DataConnect
{
    public static class Migration
    {
        public static async Task CreateTableAsync()
        {
            using (var connect = Connection.GetConnection())
            {
                await connect.OpenAsync();

                string CreateCourseQuery = @"CREATE TABLE IF NOT EXISTS Courses (
                                        CId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        CName TEXT NOT NULL
                                     );";

                string CreateStuQuery = @"CREATE TABLE IF NOT EXISTS Students (
                                     SId INTEGER PRIMARY KEY AUTOINCREMENT,
                                     SName TEXT NOT NULL,
                                     Address TEXT NOT NULL,
                                     CId INTEGER,
                                     FOREIGN KEY (CId) REFERENCES Courses(CId)
                                 );";

                string CreateSubjectQuery = @"CREATE TABLE IF NOT EXISTS Subjects (
                                         SubId INTEGER PRIMARY KEY AUTOINCREMENT,
                                         SubName TEXT NOT NULL,
                                         CId INTEGER,
                                         FOREIGN KEY (CId) REFERENCES Courses(CId)
                                     );";

                string CreateExamTable = @"CREATE TABLE IF NOT EXISTS Exams (
                                     ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                                     ExamName TEXT NOT NULL,
                                     SId INTEGER NOT NULL,
                                     SubId INTEGER NOT NULL,
                                     FOREIGN KEY (SId) REFERENCES Students(SId),
                                     FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                 );";

                string CreateMarksTable = @"CREATE TABLE IF NOT EXISTS Marks (
                                     MarkId INTEGER PRIMARY KEY AUTOINCREMENT,
                                     SId INTEGER NOT NULL,
                                     ExamId INTEGER NOT NULL,
                                     SubId INTEGER NOT NULL,
                                     Score INTEGER CHECK(Score >= 0 AND Score <= 100),
                                     FOREIGN KEY (SId) REFERENCES Students(SId),
                                     FOREIGN KEY (ExamId) REFERENCES Exams(ExamId),
                                     FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                 );";

                string createRoomTable = @"CREATE TABLE  IF NOT EXISTS Rooms (
                                     RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                                     RoomType TEXT NOT NULL CHECK(RoomType IN ('Lab', 'Hall'))
                                   );";

                string createTimetableTable = @"CREATE TABLE IF NOT EXISTS Timetables (
                                         TimetableId INTEGER PRIMARY KEY AUTOINCREMENT,
                                         SubId INTEGER NOT NULL,
                                         LecturerId INTEGER NOT NULL,
                                         TimeSlot TEXT NOT NULL,
                                         RoomId INTEGER NOT NULL,
                                         DateTimeSlot TEXT NOT NULL,
                                         FOREIGN KEY (SubId) REFERENCES Subjects(SubId),
                                         FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId),
                                         FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
                                       );";

                string createLecturerTable = @"CREATE TABLE IF NOT EXISTS Lecturers (
                                         LecturerId INTEGER PRIMARY KEY AUTOINCREMENT,
                                         LName TEXT NOT NULL,
                                         CId INTEGER NOT NULL,
                                         SubId INTEGER NOT NULL,
                                         FOREIGN KEY (CId) REFERENCES Courses(CId),
                                         FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                     );";

                string createStaffTable = @"CREATE TABLE IF NOT EXISTS Staffs (
                                     StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                                     StaffName TEXT NOT NULL,
                                     RoleType TEXT NOT NULL
                                   );";

                string createUsers = @"CREATE TABLE IF NOT EXISTS Users (
                                 UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                                 Username TEXT NOT NULL,
                                 Password TEXT NOT NULL,
                                 Role TEXT NOT NULL,
                                 SId INTEGER,
                                 LecturerId INTEGER,
                                 StaffId INTEGER,
                                 FOREIGN KEY(SId) REFERENCES Students(SId),
                                 FOREIGN KEY(LecturerId) REFERENCES Lecturers(LecturerId),
                                 FOREIGN KEY(StaffId) REFERENCES Staffs(StaffId)
                               );";
                string createAttendanceTable = @"CREATE TABLE IF NOT EXISTS Attendance (
                                AttendanceId INTEGER PRIMARY KEY AUTOINCREMENT,
                                SId INTEGER NOT NULL,
                                SubId INTEGER NOT NULL,
                                Date TEXT NOT NULL,
                                Status TEXT NOT NULL CHECK(Status IN ('Present', 'Absent', 'Late', 'Excused')),
                                UNIQUE(SId, SubId, Date),
                                FOREIGN KEY (SId) REFERENCES Students(SId),
                                FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                            );";
                string createStudentSubjectsTable = @"
                                                CREATE TABLE IF NOT EXISTS StudentSubjects (
                                                    SId INTEGER NOT NULL,
                                                    SubId INTEGER NOT NULL,
                                                    PRIMARY KEY (SId, SubId),
                                                    FOREIGN KEY (SId) REFERENCES Students(SId),
                                                    FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                                );";

                string createLecturerSubjectsTable = @"
                                                    CREATE TABLE IF NOT EXISTS LecturerSubjects (
                                                        LecturerId INTEGER NOT NULL,
                                                        SubId INTEGER NOT NULL,
                                                        PRIMARY KEY (LecturerId, SubId),
                                                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId),
                                                        FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                                    );";

             

                await new SQLiteCommand(createStudentSubjectsTable, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(createLecturerSubjectsTable, connect).ExecuteNonQueryAsync();


                await new SQLiteCommand(createAttendanceTable, connect).ExecuteNonQueryAsync();

                await new SQLiteCommand(createUsers, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(createLecturerTable, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(createStaffTable, connect).ExecuteNonQueryAsync();

                MessageBox.Show("Users & related tables created");

                await new SQLiteCommand(createRoomTable, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(createTimetableTable, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(CreateExamTable, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(CreateMarksTable, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(CreateCourseQuery, connect).ExecuteNonQueryAsync();

                MessageBox.Show("successfully table created");

                await new SQLiteCommand(CreateStuQuery, connect).ExecuteNonQueryAsync();
                await new SQLiteCommand(CreateSubjectQuery, connect).ExecuteNonQueryAsync();

                MessageBox.Show("successfully table created");
            }
        }

    }
}