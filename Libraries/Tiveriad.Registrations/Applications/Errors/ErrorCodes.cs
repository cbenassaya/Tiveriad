
using System;
namespace Tiveriad.Registrations.Applications.Errors;

public static class ErrorCodes
{
    public static string RegistrationGetByIdQueryHandler_Id_XNotNullRule = "RegistrationGetByIdQueryHandler_Id_XNotNullRule";
    public static string RegistrationModelGetByIdQueryHandler_Id_XNotNullRule = "RegistrationModelGetByIdQueryHandler_Id_XNotNullRule";
    public static string RegistrationSaveCommandHandler_Registration_XNotNullRule = "RegistrationSaveCommandHandler_Registration_XNotNullRule";
    public static string Registration_Description_XMaxLengthRule_Max_500 = "Registration_Description_XMaxLengthRule_Max_500";
    public static string Registration_Description_XNotEmptyRule = "Registration_Description_XNotEmptyRule";
    public static string Registration_OrganizationName_XMaxLengthRule_Max_50 = "Registration_OrganizationName_XMaxLengthRule_Max_50";
    public static string Registration_OrganizationName_XNotEmptyRule = "Registration_OrganizationName_XNotEmptyRule";
    public static string Registration_Firstname_XMaxLengthRule_Max_100 = "Registration_Firstname_XMaxLengthRule_Max_100";
    public static string Registration_Firstname_XNotEmptyRule = "Registration_Firstname_XNotEmptyRule";
    public static string Registration_Lastname_XMaxLengthRule_Max_100 = "Registration_Lastname_XMaxLengthRule_Max_100";
    public static string Registration_Lastname_XNotEmptyRule = "Registration_Lastname_XNotEmptyRule";
    public static string Registration_Username_XMaxLengthRule_Max_100 = "Registration_Username_XMaxLengthRule_Max_100";
    public static string Registration_Username_XNotEmptyRule = "Registration_Username_XNotEmptyRule";
    public static string Registration_Password_XMaxLengthRule_Max_12 = "Registration_Password_XMaxLengthRule_Max_12";
    public static string Registration_Password_XMinLengthRule_Min_12 = "Registration_Password_XMinLengthRule_Min_12";
    public static string Registration_Password_XNotEmptyRule = "Registration_Password_XNotEmptyRule";
    public static string Registration_Email_XMaxLengthRule_Max_100 = "Registration_Email_XMaxLengthRule_Max_100";
    public static string Registration_Email_XNotEmptyRule = "Registration_Email_XNotEmptyRule";
    public static string Registration_DefaultLocale_XMaxLengthRule_Max_12 = "Registration_DefaultLocale_XMaxLengthRule_Max_12";
    public static string Registration_DefaultLocale_XNotEmptyRule = "Registration_DefaultLocale_XNotEmptyRule";
    public static string Registration_OrganizationName_XUniqueRule = "Registration_OrganizationName_XUniqueRule";
    public static string RegistrationModelSaveCommandHandler_RegistrationModel_XNotNullRule = "RegistrationModelSaveCommandHandler_RegistrationModel_XNotNullRule";
    public static string RegistrationModel_Name_XMaxLengthRule_Max_50 = "RegistrationModel_Name_XMaxLengthRule_Max_50";
    public static string RegistrationModel_Name_XNotEmptyRule = "RegistrationModel_Name_XNotEmptyRule";
    public static string RegistrationModel_Description_XMaxLengthRule_Max_500 = "RegistrationModel_Description_XMaxLengthRule_Max_500";
    public static string RegistrationModel_Description_XNotEmptyRule = "RegistrationModel_Description_XNotEmptyRule";
    public static string RegistrationUpdateCommandHandler_Registration_XNotNullRule = "RegistrationUpdateCommandHandler_Registration_XNotNullRule";
    public static string Registration_Id_XNotNullRule = "Registration_Id_XNotNullRule";
    public static string RegistrationModelUpdateCommandHandler_RegistrationModel_XNotNullRule = "RegistrationModelUpdateCommandHandler_RegistrationModel_XNotNullRule";
    public static string RegistrationModel_Id_XNotNullRule = "RegistrationModel_Id_XNotNullRule";
    public static string RegistrationDeleteCommandHandler_Id_XNotNullRule = "RegistrationDeleteCommandHandler_Id_XNotNullRule";
    public static string RegistrationModelDeleteCommandHandler_Id_XNotNullRule = "RegistrationModelDeleteCommandHandler_Id_XNotNullRule";



}

