using Disaheim;

public class Course : Merchandise
{
    public static double CourseHourValue { get; set; } = 875;
    public string CourseName { get; set; }
    public int DurationInMinutes { get; set; }

    public Course(string courseName) : base(courseName)
    {
        CourseName = courseName;
    }

    public Course(string courseName, int hours) : base(courseName)
    {
        CourseName = courseName;
        DurationInMinutes = hours;
    }

    public Course(string courseName, int hours, double value, string itemId) : base(itemId)
    {
        CourseName = courseName;
        DurationInMinutes = hours;
    }

    public double GetValue()
    {
        double value = 0.0;
        for (int i = 0; i < DurationInMinutes; i += 60)
            value += CourseHourValue;
        return value;
    }

    public override string ToString()
    {
        return $"Name: {CourseName}, Duration: {DurationInMinutes}, Value: {GetValue()}";
    }
}
