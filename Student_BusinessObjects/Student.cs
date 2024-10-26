using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Student_BusinessObjects;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string Status { get; set; } = null!;

    [XmlIgnore]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

[XmlRoot("Students")]
public class StudentCollection
{
    [XmlElement("Student")]
    public List<Student> Students { get; set; } = new List<Student>();
}
