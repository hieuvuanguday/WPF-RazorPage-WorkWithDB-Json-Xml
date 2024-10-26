using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Student_BusinessObjects;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public string? Grade { get; set; }

    public string Status { get; set; } = null!;

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}


[XmlRoot("Enrollments")]
public class EnrollmentCollection
{
    [XmlElement("Enrollment")]
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
