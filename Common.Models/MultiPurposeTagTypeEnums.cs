namespace Common.Models
{
    public enum ModuleEnum : byte
    {
        Common = 0,
        Authorization = 10,
        Main = 20
    }

    public enum GenderEnum : byte
    {
        Male = 0,
        Female = 1
    }

    public enum UserRoleEnum : byte
    {
        Anonymous = 0,
        ForeignCustomer = 10,
        LocalCustomer = 20,
        TransportManager = 100,
        BankNetwork = 150,
        MobileNetwork = 160,
        Administrator = 250
    }
}
