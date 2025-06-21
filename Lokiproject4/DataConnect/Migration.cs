using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
        public static void CreateTable()
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string CreateCourseQuery = @"
                    CREATE TABLE IF NOT EXISTS Courses (
                        CId INTEGER PRIMARY KEY AUTOINCREMENT,
                        CName TEXT NOT NULL
                    );";

                string CreateStuQuery = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        SId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SName TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        CId INTEGER,
                        FOREIGN KEY (CId) REFERENCES Courses(CId)
                    );";

                string CreateSubjectQuery = @"
                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubName TEXT NOT NULL,
                        CId INTEGER,
                        FOREIGN KEY (CId) REFERENCES Courses(CId)
                    );";
                string CreateExamTable = @"
                                        CREATE TABLE IF NOT EXISTS Exams (
                                            ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                                            ExamName TEXT NOT NULL,
                                            SId INTEGER NOT NULL,
                                            SubId INTEGER NOT NULL,
                                            FOREIGN KEY (SId) REFERENCES Students(SId),
                                            FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                        );";

                string CreateMarksTable = @"
                                    CREATE TABLE IF NOT EXISTS Marks (
                                        MarkId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        SId INTEGER NOT NULL,
                                        ExamId INTEGER NOT NULL,
                                        SubId INTEGER NOT NULL,

                                        Score INTEGER CHECK(Score >= 0 AND Score <= 100),
                                        FOREIGN KEY (SId) REFERENCES Students(SId),
                                        FOREIGN KEY (ExamId) REFERENCES Exams(ExamId),
                                        FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                    );";

                string createRoomTable = @"
                                            CREATE TABLE IF NOT EXISTS Rooms (
                                            RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                                            
                                            RoomType TEXT NOT NULL CHECK(RoomType IN ('Lab', 'Hall'))
                                             );";

                string createTimetableTable = @"
                                    CREATE TABLE IF NOT EXISTS Timetables (
                                        TimetableId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        SubId INTEGER NOT NULL,
                                        LecturerId INTEGER NOT NULL,
                                        TimeSlot TEXT NOT NULL,
                                        RoomId INTEGER NOT NULL,
                                        FOREIGN KEY (SubId) REFERENCES Subjects(SubId),
                                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId),
                                        FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
                                    );";

                string createLecturerTable = @"
                                    CREATE TABLE IF NOT EXISTS Lecturers (
                                        LecturerId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        LName TEXT NOT NULL,
                                        CId INTEGER NOT NULL,
                                        SubId INTEGER NOT NULL,
                                        FOREIGN KEY (CId) REFERENCES Courses(CId),
                                        FOREIGN KEY (SubId) REFERENCES Subjects(SubId)
                                    );";
                string createStaffTable = @"
                                    CREATE TABLE IF NOT EXISTS Staffs (
                                        StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        StaffName TEXT NOT NULL,
                                        RoleType TEXT NOT NULL
                                    );";

                string createUsers = @"
                        CREATE TABLE IF NOT EXISTS Users (
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

                SQLiteCommand usersCmd = new SQLiteCommand(createUsers, connect);
                usersCmd.ExecuteNonQuery();



                SQLiteCommand lecturerCmd = new SQLiteCommand(createLecturerTable, connect);
                lecturerCmd.ExecuteNonQuery();

                SQLiteCommand staffCmd = new SQLiteCommand(createStaffTable, connect);
                staffCmd.ExecuteNonQuery();

                

                MessageBox.Show("Users & related tables created");

                SQLiteCommand roomCmd = new SQLiteCommand(createRoomTable, connect);
                roomCmd.ExecuteNonQuery();

                SQLiteCommand timetableCmd = new SQLiteCommand(createTimetableTable, connect);
                timetableCmd.ExecuteNonQuery();

                SQLiteCommand cmdExam = new SQLiteCommand(CreateExamTable, connect);
                cmdExam.ExecuteNonQuery();

                SQLiteCommand cmdMark = new SQLiteCommand(CreateMarksTable,connect);
                cmdMark.ExecuteNonQuery();


                SQLiteCommand data2 = new SQLiteCommand(CreateCourseQuery, connect);
                data2.ExecuteNonQuery();
                {
                    MessageBox.Show("successfully table created");
                }

                SQLiteCommand data1 = new SQLiteCommand(CreateStuQuery, connect);
                data1.ExecuteNonQuery();

                SQLiteCommand data3 = new SQLiteCommand(CreateSubjectQuery, connect);
                data3.ExecuteNonQuery();

                MessageBox.Show("successfully table created");
            }
        }
    }
}
