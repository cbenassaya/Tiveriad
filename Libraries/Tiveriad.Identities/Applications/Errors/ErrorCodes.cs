namespace Tiveriad.Identities.Applications.Errors;

public static class ErrorCodes
{
    public static string OrganizationGetByIdQueryHandler_Id_XNotNullRule =
        "OrganizationGetByIdQueryHandler_Id_XNotNullRule";

    public static string UserGetByIdQueryHandler_Id_XNotNullRule = "UserGetByIdQueryHandler_Id_XNotNullRule";

    public static string MembershipGetByIdQueryHandler_Id_XNotNullRule =
        "MembershipGetByIdQueryHandler_Id_XNotNullRule";

    public static string LanguageGetByIdQueryHandler_Id_XNotNullRule = "LanguageGetByIdQueryHandler_Id_XNotNullRule";
    public static string LocaleGetByIdQueryHandler_Id_XNotNullRule = "LocaleGetByIdQueryHandler_Id_XNotNullRule";
    public static string TimeAreaGetByIdQueryHandler_Id_XNotNullRule = "TimeAreaGetByIdQueryHandler_Id_XNotNullRule";
    public static string RealmGetByIdQueryHandler_Id_XNotNullRule = "RealmGetByIdQueryHandler_Id_XNotNullRule";
    public static string RoleGetByIdQueryHandler_Id_XNotNullRule = "RoleGetByIdQueryHandler_Id_XNotNullRule";
    public static string PolicyGetByIdQueryHandler_Id_XNotNullRule = "PolicyGetByIdQueryHandler_Id_XNotNullRule";

    public static string OrganizationSaveCommandHandler_Organization_XNotNullRule =
        "OrganizationSaveCommandHandler_Organization_XNotNullRule";

    public static string Organization_Name_XMaxLengthRule_Max_50 = "Organization_Name_XMaxLengthRule_Max_50";
    public static string Organization_Name_XNotEmptyRule = "Organization_Name_XNotEmptyRule";
    public static string Organization_Logo_XMaxLengthRule_Max_50 = "Organization_Logo_XMaxLengthRule_Max_50";
    public static string Organization_Domain_XMaxLengthRule_Max_100 = "Organization_Domain_XMaxLengthRule_Max_100";
    public static string Organization_Domain_XNotEmptyRule = "Organization_Domain_XNotEmptyRule";

    public static string Organization_Description_XMaxLengthRule_Max_100 =
        "Organization_Description_XMaxLengthRule_Max_100";

    public static string Organization_Description_XNotEmptyRule = "Organization_Description_XNotEmptyRule";
    public static string Organization_Name_XUniqueRule = "Organization_Name_XUniqueRule";
    public static string Organization_Domain_XUniqueRule = "Organization_Domain_XUniqueRule";
    public static string Organization_XBusinessKeyRule = "Organization_XBusinessKeyRule";
    public static string UserSaveCommandHandler_User_XNotNullRule = "UserSaveCommandHandler_User_XNotNullRule";
    public static string User_Firstname_XMaxLengthRule_Max_100 = "User_Firstname_XMaxLengthRule_Max_100";
    public static string User_Firstname_XNotEmptyRule = "User_Firstname_XNotEmptyRule";
    public static string User_Lastname_XMaxLengthRule_Max_100 = "User_Lastname_XMaxLengthRule_Max_100";
    public static string User_Lastname_XNotEmptyRule = "User_Lastname_XNotEmptyRule";
    public static string User_Username_XMaxLengthRule_Max_100 = "User_Username_XMaxLengthRule_Max_100";
    public static string User_Username_XNotEmptyRule = "User_Username_XNotEmptyRule";
    public static string User_Password_XMaxLengthRule_Max_12 = "User_Password_XMaxLengthRule_Max_12";
    public static string User_Password_XNotEmptyRule = "User_Password_XNotEmptyRule";
    public static string User_Email_XMaxLengthRule_Max_100 = "User_Email_XMaxLengthRule_Max_100";
    public static string User_Email_XNotEmptyRule = "User_Email_XNotEmptyRule";
    public static string User_Avatar_XMaxLengthRule_Max_24 = "User_Avatar_XMaxLengthRule_Max_24";
    public static string User_Username_XUniqueRule = "User_Username_XUniqueRule";
    public static string User_Email_XUniqueRule = "User_Email_XUniqueRule";
    public static string User_XBusinessKeyRule = "User_XBusinessKeyRule";

    public static string MembershipSaveCommandHandler_Membership_XNotNullRule =
        "MembershipSaveCommandHandler_Membership_XNotNullRule";

    public static string LanguageSaveCommandHandler_Language_XNotNullRule =
        "LanguageSaveCommandHandler_Language_XNotNullRule";

    public static string Language_Name_XMaxLengthRule_Max_50 = "Language_Name_XMaxLengthRule_Max_50";
    public static string Language_Name_XNotEmptyRule = "Language_Name_XNotEmptyRule";
    public static string Language_Code_XMaxLengthRule_Max_24 = "Language_Code_XMaxLengthRule_Max_24";
    public static string Language_Code_XNotEmptyRule = "Language_Code_XNotEmptyRule";
    public static string Language_Name_XUniqueRule = "Language_Name_XUniqueRule";
    public static string Language_Code_XUniqueRule = "Language_Code_XUniqueRule";
    public static string LocaleSaveCommandHandler_Locale_XNotNullRule = "LocaleSaveCommandHandler_Locale_XNotNullRule";
    public static string Locale_Name_XMaxLengthRule_Max_50 = "Locale_Name_XMaxLengthRule_Max_50";
    public static string Locale_Name_XNotEmptyRule = "Locale_Name_XNotEmptyRule";
    public static string Locale_Code_XMaxLengthRule_Max_24 = "Locale_Code_XMaxLengthRule_Max_24";
    public static string Locale_Code_XNotEmptyRule = "Locale_Code_XNotEmptyRule";
    public static string Locale_Name_XUniqueRule = "Locale_Name_XUniqueRule";
    public static string Locale_Code_XUniqueRule = "Locale_Code_XUniqueRule";

    public static string TimeAreaSaveCommandHandler_TimeArea_XNotNullRule =
        "TimeAreaSaveCommandHandler_TimeArea_XNotNullRule";

    public static string TimeArea_Name_XMaxLengthRule_Max_50 = "TimeArea_Name_XMaxLengthRule_Max_50";
    public static string TimeArea_Name_XNotEmptyRule = "TimeArea_Name_XNotEmptyRule";
    public static string TimeArea_Code_XMaxLengthRule_Max_24 = "TimeArea_Code_XMaxLengthRule_Max_24";
    public static string TimeArea_Code_XNotEmptyRule = "TimeArea_Code_XNotEmptyRule";
    public static string TimeArea_Name_XUniqueRule = "TimeArea_Name_XUniqueRule";
    public static string TimeArea_Code_XUniqueRule = "TimeArea_Code_XUniqueRule";
    public static string RealmSaveCommandHandler_Realm_XNotNullRule = "RealmSaveCommandHandler_Realm_XNotNullRule";
    public static string Realm_Name_XMaxLengthRule_Max_50 = "Realm_Name_XMaxLengthRule_Max_50";
    public static string Realm_Name_XNotEmptyRule = "Realm_Name_XNotEmptyRule";
    public static string Realm_Description_XMaxLengthRule_Max_100 = "Realm_Description_XMaxLengthRule_Max_100";
    public static string Realm_Description_XNotEmptyRule = "Realm_Description_XNotEmptyRule";
    public static string Realm_Name_XUniqueRule = "Realm_Name_XUniqueRule";
    public static string RoleSaveCommandHandler_Role_XNotNullRule = "RoleSaveCommandHandler_Role_XNotNullRule";
    public static string Role_Name_XMaxLengthRule_Max_50 = "Role_Name_XMaxLengthRule_Max_50";
    public static string Role_Name_XNotEmptyRule = "Role_Name_XNotEmptyRule";
    public static string Role_Description_XMaxLengthRule_Max_100 = "Role_Description_XMaxLengthRule_Max_100";
    public static string Role_Description_XNotEmptyRule = "Role_Description_XNotEmptyRule";
    public static string Role_Name_XUniqueRule = "Role_Name_XUniqueRule";
    public static string PolicySaveCommandHandler_Policy_XNotNullRule = "PolicySaveCommandHandler_Policy_XNotNullRule";
    public static string Policy_Name_XMaxLengthRule_Max_50 = "Policy_Name_XMaxLengthRule_Max_50";
    public static string Policy_Name_XNotEmptyRule = "Policy_Name_XNotEmptyRule";
    public static string Policy_Name_XUniqueRule = "Policy_Name_XUniqueRule";

    public static string OrganizationUpdateCommandHandler_Organization_XNotNullRule =
        "OrganizationUpdateCommandHandler_Organization_XNotNullRule";

    public static string Organization_Id_XNotNullRule = "Organization_Id_XNotNullRule";
    public static string UserUpdateCommandHandler_User_XNotNullRule = "UserUpdateCommandHandler_User_XNotNullRule";
    public static string User_Id_XNotNullRule = "User_Id_XNotNullRule";

    public static string MembershipUpdateCommandHandler_Membership_XNotNullRule =
        "MembershipUpdateCommandHandler_Membership_XNotNullRule";

    public static string Membership_Id_XNotNullRule = "Membership_Id_XNotNullRule";


    public static string LanguageUpdateCommandHandler_Language_XNotNullRule =
        "LanguageUpdateCommandHandler_Language_XNotNullRule";

    public static string Language_Id_XNotNullRule = "Language_Id_XNotNullRule";

    public static string LocaleUpdateCommandHandler_Locale_XNotNullRule =
        "LocaleUpdateCommandHandler_Locale_XNotNullRule";

    public static string Locale_Id_XNotNullRule = "Locale_Id_XNotNullRule";

    public static string TimeAreaUpdateCommandHandler_TimeArea_XNotNullRule =
        "TimeAreaUpdateCommandHandler_TimeArea_XNotNullRule";

    public static string TimeArea_Id_XNotNullRule = "TimeArea_Id_XNotNullRule";
    public static string RealmUpdateCommandHandler_Realm_XNotNullRule = "RealmUpdateCommandHandler_Realm_XNotNullRule";
    public static string Realm_Id_XNotNullRule = "Realm_Id_XNotNullRule";
    public static string RoleUpdateCommandHandler_Role_XNotNullRule = "RoleUpdateCommandHandler_Role_XNotNullRule";
    public static string Role_Id_XNotNullRule = "Role_Id_XNotNullRule";

    public static string PolicyUpdateCommandHandler_Policy_XNotNullRule =
        "PolicyUpdateCommandHandler_Policy_XNotNullRule";

    public static string Policy_Id_XNotNullRule = "Policy_Id_XNotNullRule";

    public static string OrganizationDeleteCommandHandler_Id_XNotNullRule =
        "OrganizationDeleteCommandHandler_Id_XNotNullRule";

    public static string UserDeleteCommandHandler_Id_XNotNullRule = "UserDeleteCommandHandler_Id_XNotNullRule";

    public static string MembershipDeleteCommandHandler_Id_XNotNullRule =
        "MembershipDeleteCommandHandler_Id_XNotNullRule";

    public static string LanguageDeleteCommandHandler_Id_XNotNullRule = "LanguageDeleteCommandHandler_Id_XNotNullRule";
    public static string LocaleDeleteCommandHandler_Id_XNotNullRule = "LocaleDeleteCommandHandler_Id_XNotNullRule";
    public static string TimeAreaDeleteCommandHandler_Id_XNotNullRule = "TimeAreaDeleteCommandHandler_Id_XNotNullRule";
    public static string RealmDeleteCommandHandler_Id_XNotNullRule = "RealmDeleteCommandHandler_Id_XNotNullRule";
    public static string RoleDeleteCommandHandler_Id_XNotNullRule = "RoleDeleteCommandHandler_Id_XNotNullRule";
    public static string PolicyDeleteCommandHandler_Id_XNotNullRule = "PolicyDeleteCommandHandler_Id_XNotNullRule";
}