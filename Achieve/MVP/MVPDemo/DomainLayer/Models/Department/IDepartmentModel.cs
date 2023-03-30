namespace DomainLayer.Models.Department
{
    internal interface IDepartmentModel
    {
        string CityLocation   { get; set; }
        int    DepartmentID   { get; set; }
        string DepartmentName { get; set; }
        string Email          { get; set; }
        string PhoneNumber    { get; set; }
        string StateLocation  { get; set; }
        string URL            { get; set; }
    }
}