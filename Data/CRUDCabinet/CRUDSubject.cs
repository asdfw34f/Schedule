using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDSubject
    {
        public ObservableCollection<Subject> ReadSubject()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Subject> subjects = new([.. context.Subjects]);
            return subjects;
        }

        public bool CreateSubject(string subjectname, int semesternumber, int lecturehours, int practichours,
            int labhours, int attestationhours, int consultationhours, int totalhours)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Subject newSubject = new()
                    {
                        SubjectName = subjectname,
                        SemesterNumber = semesternumber,
                        LectureHours = lecturehours,
                        PracticHours = practichours,
                        LabHours = labhours,
                        AttestationHourse = attestationhours,
                        ConsultationHours = consultationhours,
                        TotalHours = totalhours
                    };
                    _ = context.Subjects.Add(newSubject);
                    _ = context.SaveChanges();
                    created = true;
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message);
                    created = false;
                }
                return created;
            }
        }

        public bool UpdateSubject(Subject newSubject)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Subject? oldSubject = context.Subjects.FirstOrDefault(id => id.Idsubject == newSubject.Idsubject);
                    if (oldSubject != null)
                    {
                        oldSubject.SubjectName = newSubject.SubjectName;
                        oldSubject.SemesterNumber = newSubject.SemesterNumber;
                        oldSubject.LectureHours = newSubject.LectureHours;
                        oldSubject.PracticHours = newSubject.PracticHours;
                        oldSubject.LabHours = newSubject.LabHours;
                        oldSubject.AttestationHourse = newSubject.AttestationHourse;
                        oldSubject.ConsultationHours = newSubject.ConsultationHours;
                        oldSubject.TotalHours = newSubject.TotalHours;
                        _ = context.SaveChanges();
                        updated = true;
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message);
                    updated = false;
                }
            }
            return updated;
        }

        public bool DeleteSubject(Subject deleteSubject)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Subjects.Remove(deleteSubject);
                    _ = context.SaveChanges();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message);
                    deleted = false;
                }
            }
            return deleted;
        }
    }
}