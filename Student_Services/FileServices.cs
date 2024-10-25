using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;
using Student_BusinessObjects;

namespace Student_Services
{
    public class FileServices<T> : IFileServices<T>
    {
        public async Task<List<T>> ReadFileAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return new List<T>();

            var extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".json":
                    var json = await File.ReadAllTextAsync(filePath);
                    return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

                case ".xml":
                    if (typeof(T) == typeof(Course))
                    {
                        var courseSerializer = new XmlSerializer(typeof(CourseCollection));
                        using var courseStream = File.OpenRead(filePath);
                        var courseCollection = (CourseCollection)courseSerializer.Deserialize(courseStream);
                        return courseCollection?.Courses.Cast<T>().ToList() ?? new List<T>();
                    }
                    else if (typeof(T) == typeof(Student))
                    {
                        var studentSerializer = new XmlSerializer(typeof(StudentCollection));
                        using var studentStream = File.OpenRead(filePath);
                        var studentCollection = (StudentCollection)studentSerializer.Deserialize(studentStream);
                        return studentCollection?.Students.Cast<T>().ToList() ?? new List<T>();
                    }
                    else if (typeof(T) == typeof(Enrollment))
                    {
                        var enrollmentSerializer = new XmlSerializer(typeof(EnrollmentCollection));
                        using var enrollmentStream = File.OpenRead(filePath);
                        var enrollmentCollection = (EnrollmentCollection)enrollmentSerializer.Deserialize(enrollmentStream);
                        return enrollmentCollection?.Enrollments.Cast<T>().ToList() ?? new List<T>();
                    }
                    else
                    {
                        throw new NotSupportedException($"Type '{typeof(T).Name}' is not supported for XML deserialization.");
                    }

                default:
                    throw new NotSupportedException($"File extension '{extension}' is not supported.");
            }
        }

        public async Task WriteFileAsync(List<T> data, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            var extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".json":
                    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    await File.WriteAllTextAsync(filePath, json);
                    break;

                case ".xml":
                    if (typeof(T) == typeof(Course))
                    {
                        var courseCollection = new CourseCollection { Courses = data.Cast<Course>().ToList() };
                        var serializer = new XmlSerializer(typeof(CourseCollection));
                        using (var writer = new StreamWriter(filePath))
                        {
                            serializer.Serialize(writer, courseCollection);
                        }
                    }
                    else if (typeof(T) == typeof(Student))
                    {
                        var studentCollection = new StudentCollection { Students = data.Cast<Student>().ToList() };
                        var serializer = new XmlSerializer(typeof(StudentCollection));
                        using (var writer = new StreamWriter(filePath))
                        {
                            serializer.Serialize(writer, studentCollection);
                        }
                    }
                    else if (typeof(T) == typeof(Enrollment))
                    {
                        var enrollmentCollection = new EnrollmentCollection { Enrollments = data.Cast<Enrollment>().ToList() };
                        var serializer = new XmlSerializer(typeof(EnrollmentCollection));
                        using (var writer = new StreamWriter(filePath))
                        {
                            serializer.Serialize(writer, enrollmentCollection);
                        }
                    }
                    else
                    {
                        throw new NotSupportedException($"Type '{typeof(T).Name}' is not supported for XML serialization.");
                    }
                    break;

                default:
                    throw new NotSupportedException($"File extension '{extension}' is not supported.");
            }
        }

    }
}
