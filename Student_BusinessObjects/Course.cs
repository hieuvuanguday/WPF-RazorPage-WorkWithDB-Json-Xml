using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Student_BusinessObjects;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int Credits { get; set; }
    [XmlIgnore]
    public DateOnly StartDate { get; set; }

    [XmlElement("StartDate")]
    public string StartDateXml
    {
        get => StartDate.ToString("yyyy-MM-dd");
        set => StartDate = DateOnly.Parse(value);
    }

    [XmlIgnore]
    public DateOnly EndDate { get; set; }

    [XmlElement("EndDate")]
    public string EndDateXml
    {
        get => EndDate.ToString("yyyy-MM-dd");
        set => EndDate = DateOnly.Parse(value);
    }

    [XmlIgnore]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

[XmlRoot("Courses")]
public class CourseCollection
{
    [XmlElement("Course")]
    public List<Course> Courses { get; set; } = new List<Course>();
}
