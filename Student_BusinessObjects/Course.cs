using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Student_BusinessObjects;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int Credits { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [XmlIgnore]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

[XmlRoot("Courses")]
public class CourseCollection
{
    [XmlElement("Course")]
    public List<Course> Courses { get; set; } = new List<Course>();
}
